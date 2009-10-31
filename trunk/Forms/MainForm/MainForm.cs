using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections.Generic;

namespace GenGenesis
{
    public partial class MainForm : Form
    {
        private Patient curentPatient; // Текущий пациент        

        public MainForm() //Конструктор
        {
            // Инициализация компонентов
            InitializeComponent();
            InitializeDB();
            InitializeToolTips();
            InitializeIcons();            
            // Отображение формы 
            Show();            
            // Заполнение формы
            //FillDataGridView(); // Заполняем таблицу
            FillTabControls(); // Заполняем табконтролы            
        }
        private void InitializeIcons() // Инициализация картинок для формы
        {
            newPatientButton.Image = buttonsImageList.Images["New"];
            loadPatientButton.Image = buttonsImageList.Images["Load"];
            savePatientButton.Image = buttonsImageList.Images["Save"];
            changePatientButton.Image = buttonsImageList.Images["Change"];
            deletePatientButton.Image = buttonsImageList.Images["Delete"];
            addPropertyButton.Image = buttonsImageList.Images["Add"];
            cancelButton.Image = buttonsImageList.Images["Cancel"];
        }        
        private void EnablePatientButtons(bool stat) // Меняем состояние кнопок управления пациентом
        {
            savePatientButton.Enabled = stat;
            savePatientToolStripMenuItem.Enabled = stat;
            changePatientButton.Enabled = stat;
            changePatientToolStripMenuItem.Enabled = stat;
            deletePatientButton.Enabled = stat;
            deletePatientToolStripMenuItem.Enabled = stat;
            addPropertyButton.Enabled = stat;
            cancelButton.Enabled = stat;
        }
        private void EnableMainButtons(bool stat) // Меняем состояние кнопок открытия и создания папиента
        {
            newPatientButton.Enabled = stat;
            newPatientToolStripMenuItem.Enabled = stat;
            loadPatientButton.Enabled = stat;
            openPatientToolStripMenuItem.Enabled = stat;           
        }
        private void ShowToolBoxMassage(string msg) // Показывает сообщение в тоолСтрипе
        {
            eventToolStripStatusLabel.Text = msg;
        }
        private void SetFormCaption(string text) // Установка заголовка формы
        {
            if (text == string.Empty)
                this.Text = "GenGenesis: " + curentPatient.surname + " " + curentPatient.name + " " + curentPatient.third_name;
            else
                this.Text = "GenGenesis: " + text;
        }
        private void ShowStat() // Показать статистику
        {
            string outString;
            outString =
                "Количество пациентов: " + patientsDataSet.PatientsIDList.Count + "\n" +
                "....";
            MessageBox.Show(outString, "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ShowFindPatientDialog() // Показывает форму поиска нового пациента
        {
            FindPatientForm FPForm = new FindPatientForm(patientsTableAdapterManager);
            FPForm.ShowDialog();
            if (FPForm.DialogResult == DialogResult.OK)
            {
                // Создадим нового пациента
                Patient newPatient = new Patient();
                newPatient.Load(FPForm.curPatient, this.directorysDataSet, patientsTableAdapterManager);
                curentPatient = newPatient;
                // Сделаем кнопки активными
                EnablePatientButtons(true);
                // Чистим галочки
                ResetAllTabControls();
                // Заполняем
                FillControlsByCurentPatient();
                // Заполним дерево
                FillTreeView();
                SetFormCaption("");
            }
        }
        private void ShowEditorForm() // Отображает форму редактора БД
        {
            if (curentPatient != null)
            {
                if (!curentPatient.isSaved)
                    switch (MessageBox.Show("Текущий пациент будет закрыт! Сохранить?", "Внимание",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            SaveCurentPatient();

                            break;
                        case DialogResult.No:
                            break;
                        default:
                            return;
                    }
                ResetAllTabControls();
                EnablePatientButtons(false);
                patientTreeView.Nodes.Clear();
                curentPatient = null;
                Form DBEditor = new DataBaseEditorForm(directorysDataSet, directorysTableAdapterManager);
                if (DBEditor.ShowDialog() == DialogResult.OK)
                {
                    InitializeDB();// Откроем базы данных
                    FillTabControls();// Пересоздадим табконтроллы
                }
            }
            else
            {
                Form DBEditor = new DataBaseEditorForm(directorysDataSet, directorysTableAdapterManager);
                if (DBEditor.ShowDialog() == DialogResult.OK)
                {
                    InitializeDB();// Откроем базы данных
                    FillTabControls();// Пересоздадим табконтроллы
                }
            }
        }
        private void ExportingPatientDataBase() // Експортирование базы данных
        {
            // Получение имени пользователя
            string[] userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "patients(" + DateTime.Now.ToShortDateString() + ") от " + userName[userName.Length - 1];
            saveFile.Filter = "База данных GenGenesis(*.ggb)|*.ggb";
            saveFile.FilterIndex = 1;
            saveFile.RestoreDirectory = true;
            saveFile.Title = "Укажите, куда следует сохранить базу данных...";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(Application.StartupPath + "\\DB\\patients.mdb", saveFile.FileName);
            }
        }
        private void ImportingPatientDataBase() // Импорт базы данных пациентов
        {
            ImportingDataBaseForm iDBForm = new ImportingDataBaseForm(patientsDataSet, directorysDataSet, patientsTableAdapterManager);
            iDBForm.ShowDialog();
        }

        #region Обработчики формы
        private void MainForm_Load(object sender, EventArgs e)// Загрузка формы
        {
            EnablePatientButtons(false);
        }
        private void doExit(object sender, FormClosingEventArgs e)// Выход c программы
        {
            // Если форма существует
            if (curentPatient != null)
                // Сохранены ли изменения
                if (curentPatient.isSaved)
                {
                    // Подтверждаем закрытие
                    e.Cancel = false;
                }
                else
                {
                    // ..Если не сохранены, предлагаем сохранить..
                    DialogResult res = MessageBox.Show("Изменения не были сохранены в базу данных, сохранить?", "Внимание!",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:
                            // СОХРАНЯЕМ В БАЗУ
                            SaveCurentPatient();
                            // Подтверждаем закрытие
                            e.Cancel = false;
                            break;
                        case DialogResult.No:
                            // Подтверждаем закрытие
                            e.Cancel = false;
                            break;
                        case DialogResult.Cancel:
                            // Отменяем закрытие
                            e.Cancel = true;
                            break;
                    }
                }
        }
        private void classViewControl_CheckedChanget(object sender, GenGenesis.Controls.StackViewControl.CheckedChangedEventArgs e)  // Смена отображаемой панели       
        {
            switch (e.currentPosition)
            {
                case " Признаки":
                    this.signsPanel.BringToFront();
                    break;
                case " Болезни":
                    this.illnessesPanel.BringToFront();
                    break;
                case " Пробы ТСХ":
                    this.tcxPanel.BringToFront();
                    break;
                case " Состояния генов":
                    this.genesPanel.BringToFront();
                    break;
                case " Скрининг тесты":
                    this.scriningPanel.BringToFront();
                    break;
                case " Биохимия":
                    this.biochemPanel.BringToFront();
                    break;
            }
        }
        
        #region Buttons
        private void newPatientButton_Click(object sender, EventArgs e)
        {
            CreateNewPatient();
        }
        private void loadPatientButton_Click(object sender, EventArgs e)
        {
            LoadPatient();
        }
        private void savePatientButton_Click(object sender, EventArgs e)
        {
            SaveCurentPatient();
        }
        private void changePatientButton_Click(object sender, EventArgs e)
        {
            ChangeCurentPatient();
        }
        private void deletePatientButton_Click(object sender, EventArgs e)
        {
            DeleteCurentPatient();
        }
        private void addPropertyButton_Click(object sender, EventArgs e)
        {
            AddAllPropertysToCurentPatient();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            ResetAllTabControls();
            FillControlsByCurentPatient();
        }
        private void expandButton_Click(object sender, EventArgs e)
        {
            patientTreeView.ExpandAll();
        }
        private void collapseButton_Click(object sender, EventArgs e)
        {
            patientTreeView.CollapseAll();
        }
        private void findButton_Click(object sender, EventArgs e)
        {
            FindInTreeView();
        }
        #endregion
        #region MenuStripe
        private void statStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStat();
        }
        private void exportStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportingPatientDataBase();
        }
        private void importStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportingPatientDataBase();
        }
        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditorForm();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewPatient();
        }
        private void openPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPatient();
        }
        private void savePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurentPatient();
        }
        private void changePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCurentPatient();
        }
        private void deletePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurentPatient();
        }
        private void ShowAbouteBox(object sender, EventArgs e)
        {
            AboutBox Aboute = new AboutBox();
            Aboute.ShowDialog();
        }
        #endregion
        #endregion        
    }
}
