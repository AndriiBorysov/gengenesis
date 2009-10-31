using System;
using System.Windows.Forms;
using System.Threading;

namespace GenGenesis
{
    public partial class ImportingDataBaseForm : Form
    {
        #region Поля класса
        private bool inProgress = false; // Отображает статус слияния        
        private string filePath; // Путь к открытому файлу 
        private patientsDataSetTableAdapters.TableAdapterManager originalManager; // Менеджер используемой БД
        private patientsDataSetTableAdapters.TableAdapterManager importManager; // Менеджер импортируемой БД        
        private patientsDataSet originalPatientsDataSet; // Импортируемая база данных        
        private directorysDataSet directorysDataSet; // Справочник
        private delegate void RefreshStatDelegate(int done, int replased, int ignored, int renamed); // класс делегата обновления
        private delegate void ThreadStopDelegate(); // Класс делегата  остановки потока слияния
        private RefreshStatDelegate refreshStatDelegate; // Обьект делегата
        private ThreadStopDelegate threadStopDelegate; // Обьект делегата
        Thread newThread; // Поток для выполнения операции
        #endregion

        // Конструктор        
        public ImportingDataBaseForm(patientsDataSet aPatientsDataSet, directorysDataSet aDirectorysDataSet, patientsDataSetTableAdapters.TableAdapterManager aManager)
        {
            InitializeComponent();
            originalManager = aManager;
            originalPatientsDataSet = aPatientsDataSet;
            directorysDataSet = aDirectorysDataSet;
            refreshStatDelegate = new RefreshStatDelegate(SetStats);
            threadStopDelegate = new ThreadStopDelegate(WhenThreadIsFinished);
        }       
        private void ShowOpenFileDialog() // Показывает и обрабатывает диалог открытия файла
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "База данных GenGenesis (*.ggb)|*.ggb";
            openDialog.FilterIndex = 1;
            openDialog.RestoreDirectory = true;
            openDialog.Multiselect = false;
            openDialog.Title = "Укажите базу данных для импорта...";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {                
                    fileNameTextBox.Text = openDialog.FileName;             
            }
        }        
        private void StartImportProcess() // Запуск процесса слияния
        {
            #region Проверки пути
            // Правельное ли имя пути
            if (!System.IO.Path.IsPathRooted(fileNameTextBox.Text))
            {   
                ShowInfoMessege("НЕВЕРНОЕ ИМЯ ФАЙЛА");                
                return;
            }
            // Существует ли файл
            if (!System.IO.File.Exists(fileNameTextBox.Text))
            {
                ShowInfoMessege("ФАЙЛ НЕ СУЩЕСТВУЕТ");                
                return;                
            }
            filePath = fileNameTextBox.Text;
            // Не импортировался ли файл уже
            if(importListBox.Items.Contains(System.IO.Path.GetFileNameWithoutExtension(filePath)))
            {
                ShowInfoMessege("ФАЙЛ УЖЕ БЫЛ ИМПОРТИРОВАН");
                return;
            }
            #endregion
            inProgress = true;
            // Блокируем кнопки до окончания выполнения процесса
            processButton.Enabled = false;
            openFileButton.Enabled = false;
            ifCloneGroupBox.Enabled = false;
            
            // Создаём связь с импортируемой базой данных            
            // Определяем количество пациентов в импортируемой БД
            int patientsCount = EstablishedConnection(filePath);            
            // Настройка ProgressBar
            progressBar.Minimum = 0;
            progressBar.Maximum = patientsCount;            
            // Настройка таблицы состояния
            allTextBox.Text = patientsCount.ToString();
            lastTextBox.Text = patientsCount.ToString();
            doneTextBox.Text = "0";
            // Инициализация и запуск потока
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(ImportProcess);
            newThread = new Thread(parameterizedThreadStart);            
            newThread.Start(GetOptions());
        }        
        private void ImportProcess(object ifExistOption) // Функция слияния,выполняемая в паралельном потоке
        {
            int i = 0; // Счетчик
            int replased = 0;
            int ignored = 0;
            int renamed = 0;
            Patient existPatient = new Patient(); // Существующий Пациент
            Patient importPatient = new Patient(); // Импортируемый пациент
            patientsDataSet.PatientDataTable importedPatientDataTable = importManager.PatientTableAdapter.GetAllData();            
            foreach (patientsDataSet.PatientRow currentPatientRow in importedPatientDataTable)            
            {
                if (originalPatientsDataSet.PatientsIDList.FindBypatient_id(currentPatientRow.patient_id) != null)
                    switch ((int)ifExistOption)
                    {
                        case 0: // Заменяем                                                   
                            existPatient.Load(currentPatientRow.patient_id, directorysDataSet, originalManager);
                            existPatient.Delete(originalManager);
                            importPatient.Load(currentPatientRow.patient_id, directorysDataSet, importManager);
                            importPatient.isExist = false;
                            importPatient.Save(originalManager);
                            importPatient.Save(originalManager);
                            replased++;
                            break;
                        case 1: // Пропустить    
                            ignored++;
                            break;
                        case 2: // Спросить    
                            existPatient.Load(currentPatientRow.patient_id, directorysDataSet, originalManager);
                            importPatient.Load(currentPatientRow.patient_id, directorysDataSet, importManager);
                            string tmpStr = "В импортируемой базе данных: №" + "\n" + 
                                importPatient.patient_id.ToString() + " " +
                                importPatient.surname + " " +
                                importPatient.name + " " +
                                importPatient.third_name+ "\n" +
                                "В оригинальной базе данных: №" + "\n" +
                                existPatient.patient_id.ToString() + " " +
                                existPatient.surname + " " +
                                existPatient.name + " " +
                                existPatient.third_name + "\n";
                            ReplaseAskForm RAF = new ReplaseAskForm(tmpStr, originalPatientsDataSet.PatientsIDList);
                            switch(RAF.ShowDialog())
                            {
                                case DialogResult.Yes: // Не заменять
                                    ignored++;
                                    break;
                                case DialogResult.No: // Заменять 
                                    existPatient.Delete(originalManager);
                                    importPatient.isExist = false;
                                    importPatient.Save(originalManager);
                                    importPatient.Save(originalManager);
                                    replased++;
                                    break;
                                case DialogResult.Abort: // Сохранить с другим номером
                                    importPatient.patient_id = RAF.Value;
                                    importPatient.isExist = false;
                                    importPatient.Save(originalManager);
                                    importPatient.Save(originalManager);
                                    renamed++;
                                    break;
                            }                             
                            break;                        
                    }
                else // Если совпадение не найдено
                {
                    importPatient.Load(currentPatientRow.patient_id, directorysDataSet, importManager);
                    importPatient.isExist = false;                    
                    importPatient.Save(originalManager);
                    importPatient.Save(originalManager);
                }
                i++;
                this.Invoke(refreshStatDelegate, new Object[] { i,replased,ignored,renamed });
            }            
            this.Invoke(threadStopDelegate);
        }
        private void SetStats(int done, int replased, int ignored, int renamed) // Установка статистики
        {
            progressBar.Value = done;
            progressBar.Refresh();
            lastTextBox.Text = (progressBar.Maximum - done).ToString();
            doneTextBox.Text = done.ToString();
            replasedTextBox.Text = replased.ToString();
            ignoredTextBox.Text = ignored.ToString();
            renamedTextBox.Text = renamed.ToString();
        }
        private void WhenThreadIsFinished() // Вызывается в завершении потока
        {
            inProgress = false;
            openFileButton.Enabled = true;
            processButton.Enabled = true;
            ifCloneGroupBox.Enabled = true;
            fileNameTextBox.Text = String.Empty;
            fileNameTextBox.Enabled = true;
            importListBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(filePath));
            ShowInfoMessege("База успешно импортирована!");
            messageTimer.Enabled = false;            
        }
        private void ShowInfoMessege(string message) // 1 секунду показывает строку информацию 
        {
            messageLabel.Text = message;
            messageLabel.Visible = true;
            messageTimer.Enabled = true;
        }
        private int GetOptions() // Возвращает номер модели поведения при совпадении
        {
            if (replaceRadioButton.Checked)
                return 0;
            if (skipRadioButton.Checked)
                return 1;
            if (askRadioButton.Checked)
                return 2;            
            return 0;
        }
        private int EstablishedConnection(string dataBaseName) // Установка связи с импортированой базой данных
        {
            importManager = new GenGenesis.patientsDataSetTableAdapters.TableAdapterManager();
            importManager.bolezni_tempTableAdapter = new GenGenesis.patientsDataSetTableAdapters.bolezni_tempTableAdapter();
            importManager.bolezni_tempTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            importManager.genesTableAdapter = new GenGenesis.patientsDataSetTableAdapters.genesTableAdapter();
            importManager.genesTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            importManager.PatientTableAdapter = new GenGenesis.patientsDataSetTableAdapters.PatientTableAdapter();
            importManager.PatientTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            importManager.priznaki_tempTableAdapter = new GenGenesis.patientsDataSetTableAdapters.priznaki_tempTableAdapter();
            importManager.priznaki_tempTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            importManager.tcx_allTableAdapter = new GenGenesis.patientsDataSetTableAdapters.tcx_allTableAdapter();
            importManager.tcx_allTableAdapter.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            GenGenesis.patientsDataSetTableAdapters.PatientsIDListTableAdapter tmp = new GenGenesis.patientsDataSetTableAdapters.PatientsIDListTableAdapter();
            tmp.Connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath;
            return tmp.GetData().Count;
        }

        #region ОБРАБОТЧИКИ
        private void openFileButton_Click(object sender, EventArgs e)
        {
            ShowOpenFileDialog();
        }        
        private void ImportingDataBaseForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    //
                    break;
                case (char)Keys.Escape:
                    Close();
                    break;
            }
        }
        private void ImportingDataBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inProgress)
            {
                messageTimer.Enabled = true;
                messageLabel.Visible = true;
                messageLabel.Text = "Уведомление: ДОЖДИТЕСЬ ОКОНЧАНИЯ ПРОЦЕССА!";
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }
        private void messegeTimer_Tick(object sender, EventArgs e)
        {
            if (messageLabel.Visible == true)
                messageLabel.Visible = false;
            messageTimer.Enabled = false;
        }
        private void processButton_Click(object sender, EventArgs e)
        {                       
            StartImportProcess();
        }
        #endregion
    }
    
}
