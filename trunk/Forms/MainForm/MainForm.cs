using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using OutlookStyleControls;

namespace GenGenesis
{
    public partial class MainForm : Form
    {
        private Patient currentPatient; // Текущий пациент        

        public MainForm() //Конструктор
        {
            // Инициализация компонентов
            InitializeComponent();
            InitializeDB();
            InitializeToolTips();
            InitializeIcons();
            InitializeClassPaneBar();
            InitializeTabControls();
            Show(); // Отображение формы 
            FillTabControls(); // Заполняем табконтролы            
        }
        
        /// <summary>
        /// Инициализация картинок для формы
        /// </summary>
        private void InitializeIcons()
        {
            newPatientButton.Image = buttonsImageList.Images["New"];
            loadPatientButton.Image = buttonsImageList.Images["Load"];
            savePatientButton.Image = buttonsImageList.Images["Save"];
            changePatientButton.Image = buttonsImageList.Images["Change"];
            deletePatientButton.Image = buttonsImageList.Images["Delete"];
            addPropertyButton.Image = buttonsImageList.Images["Add"];
            cancelButton.Image = buttonsImageList.Images["Cancel"];
        }

        /// <summary>
        /// Инициализация одного SBControle
        /// </summary>
        private StackBarControl InitializeStackBarControle()
        {
            StackBarControl newSTC = new StackBarControl();
            newSTC.BackColor = System.Drawing.SystemColors.Highlight;
            newSTC.ButtonHeight = 30;
            newSTC.Cursor = System.Windows.Forms.Cursors.Hand;
            newSTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newSTC.GradientButtonHoverDark = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(192)))), ((int)(((byte)(91)))));
            newSTC.GradientButtonHoverLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            newSTC.GradientButtonNormalDark = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(193)))), ((int)(((byte)(140)))));
            newSTC.GradientButtonNormalLight = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(207)))));
            newSTC.GradientButtonSelectedDark = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(166)))), ((int)(((byte)(225)))));
            newSTC.GradientButtonSelectedLight = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));            
            newSTC.Location = new System.Drawing.Point(1,1);
            newSTC.Name = "newSTC";
            newSTC.SelectedButton = null;
            newSTC.Dock = DockStyle.Fill;
            return newSTC;
        }
        /// <summary>
        /// Инициализация списка групп
        /// </summary>
        private void InitializeClassPaneBar()
        {            
            BarTender.GroupPane tmpPane = classPaneBar.Add(null, "Признаки", null);
            tmpPane.Click += new EventHandler(ShowTabControl);
            tmpPane.CanExpand = false;

            StackBarControl currentSTC = InitializeStackBarControle();
            foreach (directorysDataSet.bolezni_masksRow currentRow in directorysDataSet.bolezni_masks)
                currentSTC.Buttons.Add(currentRow.name_bol);
            currentSTC.Click +=new StackBarControl.ButtonClickEventHandler(IllnessSTC_Click);
            classPaneBar.Add(currentSTC, "Заболевания", null, true);

            tmpPane = classPaneBar.Add(null, "ТСХ", null);
            tmpPane.Click += new EventHandler(ShowTabControl);
            tmpPane.CanExpand = false;

            currentSTC = InitializeStackBarControle();                        
            foreach (directorysDataSet.analyzes_typesRow currentRow in directorysDataSet.analyzes_types)
                currentSTC.Buttons.Add(currentRow.type_name);            
            classPaneBar.Add(currentSTC, "Анализы", null, true);
            
            // Свернём все вкладки
            classPaneBar.CollapseAll();
        }       

        /// <summary>
        /// Меняем состояние кнопок управления пациентом
        /// </summary>
        /// <param name="stat">Задаёт новое состояние</param>
        private void EnablePatientButtons(bool stat)
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

        /// <summary>
        /// Меняем состояние кнопок открытия и создания папиента
        /// </summary>
        /// <param name="stat">Задаёт новое состояние</param>
        private void EnableMainButtons(bool stat)
        {
            newPatientButton.Enabled = stat;
            newPatientToolStripMenuItem.Enabled = stat;
            loadPatientButton.Enabled = stat;
            openPatientToolStripMenuItem.Enabled = stat;           
        }

        /// <summary>
        /// Показывает сообщение в statusStripe
        /// </summary>
        /// <param name="msg">Текст сообщения</param>
        private void ShowToolBoxMassage(string msg)
        {
            eventToolStripStatusLabel.Text = msg;
        }

        /// <summary>
        /// Установка заголовка формы
        /// </summary>
        /// <param name="text">Текст заголовка</param>
        private void SetFormCaption(string text)
        {
            if (text == string.Empty)
                this.Text = "GenGenesis: " + currentPatient.surname + " " + currentPatient.name + " " + currentPatient.third_name;
            else
                this.Text = "GenGenesis: " + text;
        }

        /// <summary>
        /// Показать статистику
        /// </summary>
        private void ShowStat()
        {
            string outString;
            outString =
                "Количество пациентов: " + patientsTableAdapter.GetAll().Count + "\n" +
                "....";
            MessageBox.Show(outString, "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /// <summary>
        /// Показывает форму поиска нового пациента
        /// </summary>
        private void ShowFindPatientDialog()
        {
            FindPatientForm FPForm = new FindPatientForm(patientsTableAdapterManager);
            FPForm.ShowDialog();
            if (FPForm.DialogResult == DialogResult.OK)
            {
                // Создадим нового пациента
                Patient newPatient = new Patient();
                newPatient.Load(FPForm.curPatient, this.directorysDataSet, patientsTableAdapterManager);
                currentPatient = newPatient;
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
        
        /// <summary>
        /// Отображает форму редактора БД
        /// </summary>
        private void ShowEditorForm()
        {
            if (currentPatient != null)
            {
                if (!currentPatient.isSaved)
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
                currentPatient = null;
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
        
        /// <summary>
        /// Експортирование базы данных
        /// </summary>
        private void ExportingPatientDataBase()
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

        #region Обработчики формы

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnablePatientButtons(false);
        }

        #region Обработчики меню выбора типа
        /// <summary>
        /// Нажатие на одну из групп болезней
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IllnessSTC_Click(object sender, StackBarControl.ButtonClickEventArgs e)
        {
            StackBarControl currentSTC = sender as StackBarControl;
            if (currentSTC == null)
                return;
            int idx = currentSTC.Buttons.IndexOf(e.SelectedButton);
            currentTabControl = illnessesTabControls[idx];
            tabControlPanel.Controls.Clear();
            tabControlPanel.Controls.Add(currentTabControl);
        }

        /// <summary>
        /// Устанавливается как обработчик на нажатие, отображает нужный tabControle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ShowTabControl(object sender, EventArgs e)
        {
            BarTender.GroupPane pane = sender as BarTender.GroupPane;
            if (pane != null)
            {
                switch (pane.Text)
                {
                    case ("Признаки"):
                        currentTabControl = signsTabControl;
                        tabControlPanel.Controls.Clear();
                        tabControlPanel.Controls.Add(currentTabControl);
                        break;
                    case("ТСХ"):
                        currentTabControl = tcxTabControl;
                        tabControlPanel.Controls.Clear();
                        tabControlPanel.Controls.Add(currentTabControl);
                        break;
                }


            }
            else
            {
                MessageBox.Show("Вызов от неизвестного отправителя!");
            }
        }

        #endregion

        /// <summary>
        /// Выход c программы
        /// </summary>        
        private void doExit(object sender, FormClosingEventArgs e)
        {
            // Если форма существует
            if (currentPatient != null)
                // Сохранены ли изменения
                if (currentPatient.isSaved)
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
        private void ShowAboutBox(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();
            About.ShowDialog();
        }
        #endregion

        /// <summary>
        /// Реализуем,Чтоб остальные сворачивались
        /// </summary>        
        private void classPaneBar_GroupPaneExpanding(object sender, BarTender.GroupPaneCancelEventArgs eventArgs)
        {
            classPaneBar.CollapseAll(true);
        }
        #endregion        
    }
}
