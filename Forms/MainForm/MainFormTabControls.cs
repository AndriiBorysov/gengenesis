using System;
using System.Data;
using System.Windows.Forms;
namespace GenGenesis
{
    public partial class MainForm
    {
        // ������ ��������� ��� ������ �������
        public delegate void SignsCreateCallback(TabPage[] tabPages);
        public delegate void IllnessesCreateCallback(TabPage[] tabPages);
        public delegate void TCXsCreateCallback(TabPage[] tabPages);
        public delegate void GenesesCreateCallback(TabPage[] tabPages);
        public delegate void EnabledButtonsCallback(bool stat);
        public delegate void ShowMessageCallback(string messege);
        // ������ TabControls
        TabControl signsTabControl;
        TabControl diseasesTabControl;
        TabControl tcxTabControl;
        TabControl genesTabControl;
        /// <summary>
        /// ������������� TabControls
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
        /// ���������� ���������
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillSigns(TabPage[] pages)         
        {            
            signsTabControl.TabPages.Clear();
            signsTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillIllnesses(TabPage[] pages)
        {
            diseasesTabControl.TabPages.Clear();
            diseasesTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// ���������� ���
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillTCX(TabPage[] pages)
        {
            tcxTabControl.TabPages.Clear();
            tcxTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// ���������� �����
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillGeneses(TabPage[] pages)
        {
            genesTabControl.TabPages.Clear();
            genesTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// �������� � ���������� ��� ����������
        /// </summary>
        private void FillTabControls()
        {
            // ������ �������
            signsTabControl.Hide();
            diseasesTabControl.Hide();
            tcxTabControl.Hide();
            genesTabControl.Hide();            
            currentTabControl.Hide();
            // ��������� �������� � ����������
            EnableMainButtons(false);
            // ������� ���������� � �������� ����   
            this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum; ;
            // ������� � ����� ������
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
            // ����������
            signThread.Priority = System.Threading.ThreadPriority.Highest;
            illnessThread.Priority = System.Threading.ThreadPriority.Highest;
            tcxThread.Priority = System.Threading.ThreadPriority.Normal;
            genesesThread.Priority = System.Threading.ThreadPriority.Normal;
            // ������ �������
            signThread.Start();
            illnessThread.Start();
            tcxThread.Start();
            genesesThread.Start();
        }

        /// <summary>
        /// ����� ��� ��������� �� �������������
        /// </summary>
        private void ResetAllTabControls()
        {
            // ��������
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
            // �����������
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
            // ���
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
            // �������� ���������//
            ///////////////////////
        }

        #region ���������� ��������� � ������ �������� ��������
        /// <summary>
        /// ���������� �������� � ������������ � ������� ���������   
        /// </summary>
        private void FillControlsByCurentPatient()
        {
            FillSignControlByCurentPatient();
            FillIllnessControlByCurentPatient();
            FillTCXControlByCurentPatient();
            FillGenesControlByCurentPatient();
            ///////////////////////
            // �������� ���������//
            ///////////////////////
        }

        /// <summary>
        /// ���������� ���������
        /// </summary>
        private void FillSignControlByCurentPatient()
        {
            // ��������� ��������
            foreach (TabPage TPage in signsTabControl.TabPages)
            {
                TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                foreach (CheckBox CurControl in CurTLPanel.Controls)
                {
                    // ��� ������� �������� � �������� ��������
                    foreach (Sign tmpSign in currentPatient.priznaki)
                        // ���� ���������� �� ����� �������� � ����� ������ ������� ��������
                        if ((CurControl.Text == tmpSign.sign_name) && (TPage.Name == tmpSign.group_name))
                            CurControl.Checked = true;
                }
            }
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        private void FillIllnessControlByCurentPatient()
        {
            // ��������� �������
            foreach (TabPage TPage in diseasesTabControl.TabPages)
            {
                TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                foreach (CheckBox CurControl in CurTLPanel.Controls)
                {
                    // ��� ������ ������� � �������� ��������
                    foreach (Illness tmpIllness in currentPatient.bolezni)
                        // ���� ���������� �� ����� ������� � ����� ������� ���������
                        if ((CurControl.Text == tmpIllness.illness_name) && (TPage.Name == tmpIllness.group_name))
                            CurControl.Checked = true;
                }
            }
        }

        /// <summary>
        /// ���������� ���
        /// </summary>
        private void FillTCXControlByCurentPatient()
        {
            // �������� ���
            foreach (TabPage TPage in tcxTabControl.TabPages)
            {
                TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                foreach (TCXUserControl CurTCXControl in CurTLPanel.Controls)
                {
                    // ��� ������ ����� � �������� ��������
                    foreach (TCX tmpTCX in currentPatient.TCX)
                        // ���� ���������� �� ����� ����� � ����� ������
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
        /// ���������� �����
        /// </summary>
        private void FillGenesControlByCurentPatient()
        {
            // ��������� ����   
            TableLayoutPanel CurTLPanel = (TableLayoutPanel)genesTabControl.TabPages[0].Controls[0];
            foreach (Control CurControl in CurTLPanel.Controls)
            {
                if (CurControl is GenesUserControl)
                {
                    GenesUserControl CurGenControl = (GenesUserControl)CurControl;
                    // ��� ������� ���� � �������� ��������
                    foreach (Gen tmpGen in currentPatient.genes)
                        // ���� ���������� �� ����� ����
                        if (CurGenControl.Name == tmpGen.gen_name)
                            CurGenControl.Value = tmpGen.gen_stat;
                }

            }
        }
        #endregion


    }
    // ����� ��� ���������� 
    public class GenGenesisTabControlFiller
    {
        #region ���� ������
        Form owner;
        private TabPage[] signsGroups;
        private TabPage[] illnessesGroups;
        private TabPage[] tCXsGroups;
        private TabPage[] genesesGroups;
        private int fillingProcess;
        // ���� ������
        private directorysDataSet directorysDataSet;
        private directorysDataSetTableAdapters.TableAdapterManager directorysTableAdapterManager;
        // �������
        private GenGenesis.MainForm.EnabledButtonsCallback EnabledButtonsCallback;
        private GenGenesis.MainForm.SignsCreateCallback SignsCallBack;
        private GenGenesis.MainForm.IllnessesCreateCallback IllnessCallBack;
        private GenGenesis.MainForm.TCXsCreateCallback TCXsCallback;
        private GenGenesis.MainForm.GenesesCreateCallback GenesCallBack;
        private GenGenesis.MainForm.ShowMessageCallback ShowMessageCallback;
        #endregion

        #region �����������
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
        // �������, ����������� � ����� ������        
        public void GenerateSignsControls()// ��������
        {
            string groupNameString; // ��� ������ ���������
            int groupId; // ID ������
            Sign sign = new Sign();
            int groupCount = 0;
            // ���������� ���������� � ���� ������             
            foreach (directorysDataSet.priznaki_groupRow CurrentGroupRow in directorysDataSet.priznaki_group.Rows)
            {
                groupNameString = CurrentGroupRow.sign_group_name;
                groupId = CurrentGroupRow.sign_group_id;
                TableLayoutPanel TLPanel = CreatePage(groupNameString, signsGroups, groupCount);

                directorysDataSet.priznakiDataTable searchResult = directorysTableAdapterManager.priznakiTableAdapter.GetDataByGroupId(groupId);
                foreach (directorysDataSet.priznakiRow CurrentRow in searchResult)
                // ������� ������� � ������� ��������� ������� �������
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
        public void GenerateIllnessesControls() // �������
        {
            Illness illness = new Illness();
            string groupName; // ��� ������ ���������
            int groupId; // ID ������
            int groupCount = 0;
            // ���������� ���������� � ���� ������             
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
                    illness.illness_type_name = "�����������";
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
            string groupName; // ��� ������ ���
            int groupId; // ID ������
            int groupCount = 0;
            // ���������� ���������� � ���� ������             
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
                    // �������� ������� ��� ���� ��� � ��������� ��� ��������
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
        public void GenerateGenesesControls() // ����
        {
            Gen gen = new Gen();
            string groupNameString = "����";
            TableLayoutPanel TLPanel = CreatePage(groupNameString, genesesGroups, 0);
            TLPanel.ColumnCount = 1;
            TLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            // ���������� ���������� � ���� ������             
            foreach (directorysDataSet.genes_allRow CurGenesRow in directorysDataSet.genes_all.Rows)
            {
                // �������� ������� ��� ����
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
        private void PageFilled() // ���������� �����������
        {
            fillingProcess++;
            if (fillingProcess > 3)
            {
                try
                {
                    owner.Invoke(EnabledButtonsCallback, new object[] { true });
                    owner.Invoke(ShowMessageCallback, new object[] { "������" });
                }
                catch
                {
                    System.Threading.Thread.CurrentThread.Abort();
                }
            }
        }
        #region �������������� �������
        /// <summary>
        /// �������� �������
        /// </summary>
        /// <param name="groupNameString">��� �������</param>
        /// <param name="tabPages">������, ���� ����� �������� ����� �������</param>
        /// <param name="pageCount">����� ��� ���������</param>
        /// <returns>������ �� TLPanel � ����� �������</returns>
        private TableLayoutPanel CreatePage(string groupNameString, TabPage[] tabPages, int pageCount)
        {
            TableLayoutPanel TLPanel; // ���������� ��� ������� �������
            int TLPanelColumnCount = 2; // ���������� ������� � ������� ���������            
            TLPanel = new TableLayoutPanel(); // �������� ������� ��������� ��� �������            
            TLPanel.Dock = System.Windows.Forms.DockStyle.Fill; // ������ ��� ������� ��������� �������� ��� ������� ��������
            TLPanel.ColumnCount = TLPanelColumnCount; // ���� ����������� �������
            TLPanel.AutoScroll = true;
            TLPanel.Name = groupNameString; // ������ ��� ������� ���������
            TabPage tabPageTemp; // ���������� ��� ������� �������            
            tabPageTemp = new TabPage(groupNameString); // �������� ����� �������            
            tabPageTemp.Name = groupNameString; // ������ ��� �������
            tabPageTemp.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Info);
            tabPageTemp.Controls.Add(TLPanel); // ������� ������� ��������� � ��������� �������         
            tabPages[pageCount] = tabPageTemp; // ������� ������� � ����������                        
            return TLPanel;
        }

        /// <summary>
        /// �������� CheckBox
        /// </summary>
        /// <param name="controlText">�����</param>
        /// <param name="structure">����������� ���������</param>
        /// <returns></returns>
        private Control CreateCheckBox(string controlText, object structure)
        {
            CheckBox tmpCheckBox; // ���������� ��� ��������
            System.Drawing.Font checkBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 12f);
            // �������� ��� ����
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