using System;
using System.Data;
using System.Windows.Forms;
namespace GenGenesis
{
    public partial class MainForm
    {
        // Список делегатов для разных вкладок
        public delegate void SignsCreateCallback(TabPage[] tabPages);
        public delegate void IllnessesCreateCallback(TabPage[] tabPages);
        public delegate void TCXsCreateCallback(TabPage[] tabPages);
        public delegate void GenesesCreateCallback(TabPage[] tabPages);
        public delegate void EnabledButtonsCallback(bool stat);
        public delegate void ShowMessageCallback(string messege);
        // Список TabControls
        TabControl signsTabControl;
        TabControl diseasesTabControl;
        TabControl tcxTabControl;
        TabControl genesTabControl;
        /// <summary>
        /// Инициализация TabControls
        /// </summary>
        public void InitializeTabControls()
        {
            signsTabControl = new TabControl();
            diseasesTabControl = new TabControl();
            tcxTabControl = new TabControl();
            genesTabControl = new TabControl();
            currentTabControl = signsTabControl;
        }
        /// <summary>
        /// Заполнение признаков
        /// </summary>
        /// <param name="pages">Список вкладок для добавления</param>
        private void FillSigns(TabPage[] pages)         
        {            
            signsTabControl.TabPages.Clear();
            signsTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// Заполнение болезней
        /// </summary>
        /// <param name="pages">Список вкладок для добавления</param>
        private void FillIllnesses(TabPage[] pages)
        {
            diseasesTabControl.TabPages.Clear();
            diseasesTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// Заполнение ТСХ
        /// </summary>
        /// <param name="pages">Список вкладок для добавления</param>
        private void FillTCX(TabPage[] pages)
        {
            tcxTabControl.TabPages.Clear();
            tcxTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// Заполнение Генов
        /// </summary>
        /// <param name="pages">Список вкладок для добавления</param>
        private void FillGeneses(TabPage[] pages)
        {
            genesTabControl.TabPages.Clear();
            genesTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// Создание и заполнение таб контроллов
        /// </summary>
        private void FillTabControls()
        {
            // Прячем вкладки
            signsTabControl.Hide();
            diseasesTabControl.Hide();
            tcxTabControl.Hide();
            genesTabControl.Hide();            
            currentTabControl.Hide();
            // Запрещаем действия с пациентами
            EnableMainButtons(false);
            // Убераем заполнения в прогресс баре   
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum; ;
            // Добавим в новом потоке
            GenGenesisTabControlFiller filler = new GenGenesisTabControlFiller(directorysDataSet,
                directorysTableAdapterManager,
                new EnabledButtonsCallback(EnableMainButtons),
                new SignsCreateCallback(FillSigns),
                new IllnessesCreateCallback(FillIllnesses),
                new TCXsCreateCallback(FillTCX),
                new GenesesCreateCallback(FillGeneses),
                new ShowMessageCallback(ShowToolBoxMassage),
                this);
            //System.Threading.Thread thread = new System.Threading.Thread(filler.GenerateControlCollections);
            System.Threading.Thread signThread = new System.Threading.Thread(filler.GenerateSignsControls);
            System.Threading.Thread illnessThread = new System.Threading.Thread(filler.GenerateIllnessesControls);
            System.Threading.Thread tcxThread = new System.Threading.Thread(filler.GenerateTCXControls);
            System.Threading.Thread genesesThread = new System.Threading.Thread(filler.GenerateGenesesControls);
            // Приоритеты
            signThread.Priority = System.Threading.ThreadPriority.Highest;
            illnessThread.Priority = System.Threading.ThreadPriority.Highest;
            tcxThread.Priority = System.Threading.ThreadPriority.Normal;
            genesesThread.Priority = System.Threading.ThreadPriority.Normal;
            // Запуск потоков
            signThread.Start();
            illnessThread.Start();
            tcxThread.Start();
            genesesThread.Start();
        }

        /// <summary>
        /// Сброс таб контролов на незаполненные
        /// </summary>
        private void ResetAllTabControls()
        {
            // Признаки
            foreach (TabPage TPage in signsTabControl.TabPages)
            {
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    foreach (CheckBox CurControl in CurTLPanel.Controls)
                    {
                        CurControl.Checked = false;
                    }
                }
            }
            // Заболевания
            foreach (TabPage TPage in diseasesTabControl.TabPages)
            {
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    foreach (CheckBox CurControl in CurTLPanel.Controls)
                    {
                        CurControl.Checked = false;
                    }
                }
            }
            // ТсХ
            foreach (TabPage TPage in tcxTabControl.TabPages)
            {
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    foreach (TCXUserControl tmpTCXControl in CurTLPanel.Controls)
                    {
                        tmpTCXControl.Init();
                        tmpTCXControl.PrintText();
                    }
                }
            }
            // Genes
            foreach (TabPage TPage in genesTabControl.TabPages)
            {
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                    foreach (Control curControl in CurTLPanel.Controls)
                    {
                        if (curControl is GenesUserControl)
                        {
                            GenesUserControl tmpControl = (GenesUserControl)curControl;
                            tmpControl.UncheckAll();
                        }

                    }
            }
            ///////////////////////
            // Добавить остальные//
            ///////////////////////
        }

        #region Заполнение контролов с данных текущего пациента
        /// <summary>
        /// Выставляем значения в соответствии с текущим пациентом   
        /// </summary>
        private void FillControlsByCurentPatient()
        {
            FillSignControlByCurentPatient();
            FillIllnessControlByCurentPatient();
            FillTCXControlByCurentPatient();
            FillGenesControlByCurentPatient();
            ///////////////////////
            // Добавить остальные//
            ///////////////////////
        }

        /// <summary>
        /// Заполнение признаков
        /// </summary>
        private void FillSignControlByCurentPatient()
        {
            // Заполняем признаки
            foreach (TabPage TPage in signsTabControl.TabPages)
            {
                TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                foreach (CheckBox CurControl in CurTLPanel.Controls)
                {
                    // Для каждого признака у текущего пациента
                    foreach (Sign tmpSign in currentPatient.priznaki)
                        // Ищем совпадение по имени признака и имени группы данного признака
                        if ((CurControl.Text == tmpSign.sign_name) && (TPage.Name == tmpSign.group_name))
                            CurControl.Checked = true;
                }
            }
        }

        /// <summary>
        /// Заполнение болезней
        /// </summary>
        private void FillIllnessControlByCurentPatient()
        {
            // Заполняем болезни
            foreach (TabPage TPage in diseasesTabControl.TabPages)
            {
                TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                foreach (CheckBox CurControl in CurTLPanel.Controls)
                {
                    // Для каждой болезни у текущего пациента
                    foreach (Illness tmpIllness in currentPatient.bolezni)
                        // Ищем совпадение по имени болезни и имени системы организма
                        if ((CurControl.Text == tmpIllness.illness_name) && (TPage.Name == tmpIllness.group_name))
                            CurControl.Checked = true;
                }
            }
        }

        /// <summary>
        /// Заполнение тсх
        /// </summary>
        private void FillTCXControlByCurentPatient()
        {
            // Заполним ТСХ
            foreach (TabPage TPage in tcxTabControl.TabPages)
            {
                TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                foreach (TCXUserControl CurTCXControl in CurTLPanel.Controls)
                {
                    // Для каждой пробы у текущего пациента
                    foreach (TCX tmpTCX in currentPatient.TCX)
                        // Ищем совпадение по имени пробы и имени группы
                        if ((CurTCXControl.Name == tmpTCX.tcx_name) && (TPage.Name == tmpTCX.tcx_group_name))
                        {
                            CurTCXControl.Value = tmpTCX.tcx_value;
                            CurTCXControl.Check();
                            CurTCXControl.PrintText();
                        }
                }
            }
        }

        /// <summary>
        /// Заполнение генов
        /// </summary>
        private void FillGenesControlByCurentPatient()
        {
            // Заполняем гены   
            TableLayoutPanel CurTLPanel = (TableLayoutPanel)genesTabControl.TabPages[0].Controls[0];
            foreach (Control CurControl in CurTLPanel.Controls)
            {
                if (CurControl is GenesUserControl)
                {
                    GenesUserControl CurGenControl = (GenesUserControl)CurControl;
                    // Для каждого гена у текущего пациента
                    foreach (Gen tmpGen in currentPatient.genes)
                        // Ищем совпадение по имени гена
                        if (CurGenControl.Name == tmpGen.gen_name)
                            CurGenControl.Value = tmpGen.gen_stat;
                }

            }
        }
        #endregion


    }
    // Класс для заполнения 
    public class GenGenesisTabControlFiller
    {
        #region Поля класса
        Form owner;
        private TabPage[] signsGroups;
        private TabPage[] illnessesGroups;
        private TabPage[] tCXsGroups;
        private TabPage[] genesesGroups;
        private int fillingProcess;
        // Базы данных
        private directorysDataSet directorysDataSet;
        private directorysDataSetTableAdapters.TableAdapterManager directorysTableAdapterManager;
        // Колбеки
        private GenGenesis.MainForm.EnabledButtonsCallback EnabledButtonsCallback;
        private GenGenesis.MainForm.SignsCreateCallback SignsCallBack;
        private GenGenesis.MainForm.IllnessesCreateCallback IllnessCallBack;
        private GenGenesis.MainForm.TCXsCreateCallback TCXsCallback;
        private GenGenesis.MainForm.GenesesCreateCallback GenesCallBack;
        private GenGenesis.MainForm.ShowMessageCallback ShowMessageCallback;
        #endregion

        #region Конструктор
        public GenGenesisTabControlFiller(directorysDataSet aDataSet,
            directorysDataSetTableAdapters.TableAdapterManager aManager,
            GenGenesis.MainForm.EnabledButtonsCallback enabledButtonsCallback,
            GenGenesis.MainForm.SignsCreateCallback signCallBack,
            GenGenesis.MainForm.IllnessesCreateCallback illnessCallBack,
            GenGenesis.MainForm.TCXsCreateCallback tcxsCallback,
            GenGenesis.MainForm.GenesesCreateCallback genesCallBack,
            GenGenesis.MainForm.ShowMessageCallback showMessageCallback,
            Form owner)
        {
            fillingProcess = 0;
            directorysDataSet = aDataSet;
            directorysTableAdapterManager = aManager;
            signsGroups = new TabPage[directorysDataSet.priznaki_group.Count];
            illnessesGroups = new TabPage[directorysDataSet.bolezni_group.Count];
            tCXsGroups = new TabPage[directorysDataSet.tcx_group.Count];
            genesesGroups = new TabPage[1];
            EnabledButtonsCallback = enabledButtonsCallback;
            SignsCallBack = signCallBack;
            IllnessCallBack = illnessCallBack;
            TCXsCallback = tcxsCallback;
            GenesCallBack = genesCallBack;
            ShowMessageCallback = showMessageCallback;
            this.owner = owner;
        }
        #endregion
        // Функция, выполняемая в новом потоке        
        public void GenerateSignsControls()// Признаки
        {
            string groupNameString; // Имя группы признаков
            int groupId; // ID группы
            Sign sign = new Sign();
            int groupCount = 0;
            // Заполнение контролами с базы данных             
            foreach (directorysDataSet.priznaki_groupRow CurrentGroupRow in directorysDataSet.priznaki_group.Rows)
            {
                groupNameString = CurrentGroupRow.sign_group_name;
                groupId = CurrentGroupRow.sign_group_id;
                TableLayoutPanel TLPanel = CreatePage(groupNameString, signsGroups, groupCount);

                directorysDataSet.priznakiDataTable searchResult = directorysTableAdapterManager.priznakiTableAdapter.GetDataByGroupId(groupId);
                foreach (directorysDataSet.priznakiRow CurrentRow in searchResult)
                // Добавим контрол в таблицу контролов текущей вкладки
                {
                    sign.group_id = CurrentGroupRow.sign_group_id;
                    sign.group_name = CurrentGroupRow.sign_group_name;
                    sign.sign_id = CurrentRow.sign_id;
                    sign.sign_name = CurrentRow.sign_name;
                    TLPanel.Controls.Add(CreateCheckBox(CurrentRow.sign_name, sign));
                }
                groupCount++;
            }
            PageFilled();
            try
            {
                owner.Invoke(SignsCallBack, new object[] { signsGroups });
            }
            catch
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        public void GenerateIllnessesControls() // Болезни
        {
            Illness illness = new Illness();
            string groupName; // Имя группы признаков
            int groupId; // ID группы
            int groupCount = 0;
            // Заполнение контролами с базы данных             
            foreach (directorysDataSet.bolezni_groupRow CurrentGroupRow in this.directorysDataSet.bolezni_group.Rows)
            {
                groupName = CurrentGroupRow.illness_group_name;
                groupId = CurrentGroupRow.illness_group_id;
                illness.group_id = groupId;
                illness.group_name = groupName;
                TableLayoutPanel TLPanel = CreatePage(groupName, illnessesGroups, groupCount);
                directorysDataSet.bolezniDataTable searchResult = directorysTableAdapterManager.bolezniTableAdapter.GetDataByGroupId(groupId);
                foreach (directorysDataSet.bolezniRow currentRow in searchResult.Rows)
                {
                    illness.illness_id = currentRow.illness_id;
                    illness.illness_name = currentRow.illness_name;
                    illness.isOncology = currentRow.illness_oncology;
                    illness.illness_type_id = 0;
                    illness.illness_type_name = "Собственное";
                    TLPanel.Controls.Add(CreateCheckBox(currentRow.illness_name, illness));
                }
                groupCount++;
            }
            PageFilled();
            try
            {
                owner.Invoke(IllnessCallBack, new object[] { illnessesGroups });
            }
            catch
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        public void GenerateTCXControls() // TCX
        {
            TCX tcx = new TCX();
            string groupName; // Имя группы ТСХ
            int groupId; // ID группы
            int groupCount = 0;
            // Заполнение контролами с базы данных             
            foreach (directorysDataSet.tcx_groupRow CurGroupRow in this.directorysDataSet.tcx_group.Rows)
            {
                groupName = CurGroupRow.tcx_group_name;
                groupId = CurGroupRow.tcx_group_id;
                TableLayoutPanel TLPanel = CreatePage(groupName, tCXsGroups, groupCount);
                TLPanel.ColumnCount = 1;
                TLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
                directorysDataSet.tcxDataTable searchResult = directorysTableAdapterManager.tcxTableAdapter.GetDataByGroupId(groupId);
                foreach (directorysDataSet.tcxRow CurTCXRow in searchResult.Rows)
                {
                    // Создадим контрол для проб тсх и определим его значения
                    TCXUserControl tmpControl = new TCXUserControl(CurTCXRow.tcx_name);
                    tcx.tcx_group_id = groupId;
                    tcx.tcx_group_name = groupName;
                    tcx.tcx_id = CurTCXRow.tcx_id;
                    tcx.tcx_max = CurTCXRow.tcx_max;
                    tcx.tcx_min = CurTCXRow.tcx_min;
                    tcx.tcx_name = CurTCXRow.tcx_name;
                    tmpControl.Maximum = CurTCXRow.tcx_max;
                    tmpControl.Minimum = CurTCXRow.tcx_min;
                    tmpControl.Tag = tcx;
                    TLPanel.Controls.Add(tmpControl);
                }
                groupCount++;
            }
            PageFilled();
            try
            {
                owner.Invoke(TCXsCallback, new object[] { tCXsGroups });
            }
            catch
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        public void GenerateGenesesControls() // Гены
        {
            Gen gen = new Gen();
            string groupNameString = "Гены";
            TableLayoutPanel TLPanel = CreatePage(groupNameString, genesesGroups, 0);
            TLPanel.ColumnCount = 1;
            TLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            // Заполнение контролами с базы данных             
            foreach (directorysDataSet.genes_allRow CurGenesRow in directorysDataSet.genes_all.Rows)
            {
                // Создадим контрол для гена
                GenesUserControl tmpControl = new GenesUserControl(CurGenesRow.gen_name);
                gen.gen_id = CurGenesRow.gen_id;
                gen.gen_name = CurGenesRow.gen_name;
                tmpControl.Tag = gen;
                TLPanel.Controls.Add(tmpControl);
                tmpControl.DoResize();
            }
            TLPanel.Controls.Add(new Control());
            System.Threading.Thread.Sleep(1000);
            PageFilled();
            try
            {
                owner.Invoke(GenesCallBack, new object[] { genesesGroups });
            }
            catch
            {

                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        private void PageFilled() // Заполнение произведено
        {
            fillingProcess++;
            if (fillingProcess > 3)
            {
                try
                {
                    owner.Invoke(EnabledButtonsCallback, new object[] { true });
                    owner.Invoke(ShowMessageCallback, new object[] { "Готово" });
                }
                catch
                {
                    System.Threading.Thread.CurrentThread.Abort();
                }
            }
        }
        #region Дополнительные функции
        /// <summary>
        /// Создание вкладки
        /// </summary>
        /// <param name="groupNameString">Имя вкладки</param>
        /// <param name="tabPages">Список, куда будет помещена новая вкладка</param>
        /// <param name="pageCount">Номер для помещения</param>
        /// <returns>Ссылку на TLPanel в новой вкладке</returns>
        private TableLayoutPanel CreatePage(string groupNameString, TabPage[] tabPages, int pageCount)
        {
            TableLayoutPanel TLPanel; // Переменная для текущей таблицы
            int TLPanelColumnCount = 2; // Количество колонок в таблице елементов            
            TLPanel = new TableLayoutPanel(); // Создадим таблицу контролов для вкладки            
            TLPanel.Dock = System.Windows.Forms.DockStyle.Fill; // Укажем что таблица контролов занимает всю полость родителя
            TLPanel.ColumnCount = TLPanelColumnCount; // макс колличество колонок
            TLPanel.AutoScroll = true;
            TLPanel.Name = groupNameString; // Укажем имя таблицы контролов
            TabPage tabPageTemp; // Переменная для текущей вкладки            
            tabPageTemp = new TabPage(groupNameString); // Создадим новую вкладку            
            tabPageTemp.Name = groupNameString; // Укажем имя вкладки
            tabPageTemp.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Info);
            tabPageTemp.Controls.Add(TLPanel); // Добавим таблицу контролов в коллекцию вкладки         
            tabPages[pageCount] = tabPageTemp; // Добавим вкладку в ТабКонтрол                        
            return TLPanel;
        }

        /// <summary>
        /// Создание CheckBox
        /// </summary>
        /// <param name="controlText">Текст</param>
        /// <param name="structure">Описываемая структура</param>
        /// <returns></returns>
        private Control CreateCheckBox(string controlText, object structure)
        {
            CheckBox tmpCheckBox; // Переменная для чекбокса
            System.Drawing.Font checkBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12f);
            // Создидим чек бокс
            tmpCheckBox = new CheckBox();
            tmpCheckBox.AutoSize = true;
            tmpCheckBox.Name = controlText;
            tmpCheckBox.Text = controlText;
            tmpCheckBox.Font = checkBoxFont;
            tmpCheckBox.UseVisualStyleBackColor = true;
            tmpCheckBox.Tag = structure;
            return tmpCheckBox;
        }
        #endregion
    }
}