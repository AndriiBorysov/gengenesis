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
        public delegate void AnalysisCreateCallback(TabPage[] tabPages);
        public delegate void EnabledButtonsCallback(bool stat);
        public delegate void ShowMessageCallback(string messege);
        // ������ TabControls
        TabControl signsTabControl;
        TabControl IllnessesTabControl;
        TabControl tcxTabControl;
        TabControl analysisTabControl;
        /// <summary>
        /// ������������� TabControls
        /// </summary>
        public void InitializeTabControls()
        {
            signsTabControl = InitTabControle();
            IllnessesTabControl = InitTabControle();
            tcxTabControl = InitTabControle();
            analysisTabControl = InitTabControle();
        }

        /// <summary>
        /// ������ ������ ��� ����������
        /// </summary>
        /// <returns>�������� control</returns>
        private TabControl InitTabControle()
        {
            TabControl tmpControl = new TabControl();
            tmpControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tmpControl.Controls.Add(this.tabPage1);
            tmpControl.Controls.Add(this.tabPage2);
            tmpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tmpControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            tmpControl.HotTrack = true;
            tmpControl.Location = new System.Drawing.Point(0, 0);
            tmpControl.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            tmpControl.Multiline = true;
            tmpControl.Name = "currentTabControl";
            tmpControl.SelectedIndex = 0;
            tmpControl.Size = new System.Drawing.Size(449, 515);
            tmpControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            tmpControl.TabIndex = 0;
            return tmpControl;
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
            IllnessesTabControl.TabPages.Clear();
            IllnessesTabControl.TabPages.AddRange(pages);            
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
        /// ���������� ��������
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillAnalysis(TabPage[] pages)
        {
            analysisTabControl.TabPages.Clear();
            analysisTabControl.TabPages.AddRange(pages);            
            toolStripProgressBar.Value += 1;
        }

        /// <summary>
        /// �������� � ���������� ��� ����������
        /// </summary>
        private void FillTabControls()
        {               
            // ��������� �������� � ����������
            EnableMainButtons(false);
            // ������� ���������� � �������� ����   
            this.toolStripProgressBar.Value = 0;
            // ������� � ����� ������
            GenGenesisTabControlFiller filler = new GenGenesisTabControlFiller(directorysDataSet,
                directorysTableAdapterManager,
                new EnabledButtonsCallback(EnableMainButtons),
                new SignsCreateCallback(FillSigns),
                new IllnessesCreateCallback(FillIllnesses),
                new TCXsCreateCallback(FillTCX),
                new AnalysisCreateCallback(FillAnalysis),
                new ShowMessageCallback(ShowToolBoxMassage),
                this);            
            System.Threading.Thread signThread = new System.Threading.Thread(filler.GenerateSignsControls);
            System.Threading.Thread illnessThread = new System.Threading.Thread(filler.GenerateIllnessesControls);
            System.Threading.Thread tcxThread = new System.Threading.Thread(filler.GenerateTCXControls);
            System.Threading.Thread analysisThread = new System.Threading.Thread(filler.GenerateAnalysisControls);
            // ����������
            signThread.Priority = System.Threading.ThreadPriority.Highest;
            illnessThread.Priority = System.Threading.ThreadPriority.Highest;
            tcxThread.Priority = System.Threading.ThreadPriority.Normal;
            analysisThread.Priority = System.Threading.ThreadPriority.Normal;
            // ������ �������
            signThread.Start();
            //illnessThread.Start();
            //tcxThread.Start();
            //analysisThread.Start();
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
            //foreach (TabPage TPage in IllnessesTabControl.TabPages)
            //{
            //    foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
            //    {
            //        foreach (CheckBox CurControl in CurTLPanel.Controls)
            //        {
            //            CurControl.Checked = false;
            //        }
            //    }
            //}
            //// �C�
            //foreach (TabPage TPage in tcxTabControl.TabPages)
            //{
            //    foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
            //    {
            //        foreach (TCXUserControl tmpTCXControl in CurTLPanel.Controls)
            //        {
            //            tmpTCXControl.Init();
            //            tmpTCXControl.PrintText();
            //        }
            //    }
            //}
            // Analysis
            //foreach (TabPage TPage in AnalysisTabControl.TabPages)
            //{
            //    foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
            //        foreach (Control curControl in CurTLPanel.Controls)
            //        {
            //            if (curControl is GenesUserControl)
            //            {
            //                GenesUserControl tmpControl = (GenesUserControl)curControl;
            //                tmpControl.UncheckAll();
            //            }

            //        }
            //}            
        }

        #region ���������� ��������� � ������ �������� ��������
        /// <summary>
        /// ���������� �������� � ������������ � ������� ���������   
        /// </summary>
        private void FillControlsByCurentPatient()
        {
            FillSignControlByCurentPatient();
            //FillIllnessControlByCurentPatient();
            //FillTCXControlByCurentPatient();
            //FillAnalysisControlByCurentPatient();
            
        }

        /// <summary>
        /// ���������� ��������� � ��������
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
        /// ���������� �������� � ��������
        /// </summary>
        private void FillIllnessControlByCurentPatient()
        {
            // ��������� �������
            foreach (TabPage TPage in IllnessesTabControl.TabPages)
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
        /// ���������� ��� � ��������
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
        /// ���������� �������� � ��������
        /// </summary>
        private void FillAnalysisControlByCurentPatient()
        {
            throw new NotImplementedException();
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
        private TabPage[] analysisGroups;
        private int fillingProcess;
        // ���� ������
        private directorysDataSet directorysDataSet;
        private directorysDataSetTableAdapters.TableAdapterManager directorysTableAdapterManager;
        // �������
        private GenGenesis.MainForm.EnabledButtonsCallback EnabledButtonsCallback;
        private GenGenesis.MainForm.SignsCreateCallback SignsCallBack;
        private GenGenesis.MainForm.IllnessesCreateCallback IllnessCallBack;
        private GenGenesis.MainForm.TCXsCreateCallback TCXsCallback;
        private GenGenesis.MainForm.AnalysisCreateCallback AnalysisCallBack;
        private GenGenesis.MainForm.ShowMessageCallback ShowMessageCallback;
        #endregion

        #region �����������
        public GenGenesisTabControlFiller(directorysDataSet aDataSet,
            directorysDataSetTableAdapters.TableAdapterManager aManager,
            GenGenesis.MainForm.EnabledButtonsCallback enabledButtonsCallback,
            GenGenesis.MainForm.SignsCreateCallback signCallBack,
            GenGenesis.MainForm.IllnessesCreateCallback illnessCallBack,
            GenGenesis.MainForm.TCXsCreateCallback tcxsCallback,
            GenGenesis.MainForm.AnalysisCreateCallback analysisCallBack,
            GenGenesis.MainForm.ShowMessageCallback showMessageCallback,
            Form owner)
        {
            fillingProcess = 0;
            directorysDataSet = aDataSet;
            directorysTableAdapterManager = aManager;
            signsGroups = new TabPage[directorysDataSet.priznaki_groups.Count];
            illnessesGroups = new TabPage[directorysDataSet.bolezni_groups.Count];
            tCXsGroups = new TabPage[directorysDataSet.tcx_groups.Count];
            analysisGroups = new TabPage[1];
            EnabledButtonsCallback = enabledButtonsCallback;
            SignsCallBack = signCallBack;
            IllnessCallBack = illnessCallBack;
            TCXsCallback = tcxsCallback;
            AnalysisCallBack = analysisCallBack;
            ShowMessageCallback = showMessageCallback;
            this.owner = owner;
        }
        #endregion

        #region �������, ����������� � ����� ������
        /// <summary>
        /// ��������� �� ���� ������ ���������� ��� �������� � ��������� TabControl
        /// </summary>
        public void GenerateSignsControls()
        {
            string groupNameString; // ��� ������ ���������
            int groupId; // ID ������
            Sign sign = new Sign();
            int groupCount = 0;
            // ���������� ���������� � ���� ������             
            foreach (directorysDataSet.priznaki_groupsRow CurrentGroupRow in directorysDataSet.priznaki_groups.Rows)
            {
                groupNameString = CurrentGroupRow.sign_group_name;
                groupId = CurrentGroupRow.sign_group_id;
                TableLayoutPanel TLPanel = CreatePage(groupNameString, signsGroups, groupCount);

                directorysDataSet.priznaki_allDataTable searchResult = directorysTableAdapterManager.priznaki_allTableAdapter.GetDataByGroup_id(groupId);
                foreach (directorysDataSet.priznaki_allRow CurrentRow in searchResult)
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
        
        /// <summary>
        /// ��������� �� ���� ������ ���������� ��� ����������� � ��������� TabControl
        /// </summary>
        public void GenerateIllnessesControls()
        {
            //Illness illness = new Illness();
            //string groupName; // ��� ������ ���������
            //int groupId; // ID ������
            //int groupCount = 0;
            //// ���������� ���������� � ���� ������             
            //foreach (directorysDataSet.bolezni_groupRow CurrentGroupRow in this.directorysDataSet.bolezni_group.Rows)
            //{
            //    groupName = CurrentGroupRow.illness_group_name;
            //    groupId = CurrentGroupRow.illness_group_id;
            //    illness.group_id = groupId;
            //    illness.group_name = groupName;
            //    TableLayoutPanel TLPanel = CreatePage(groupName, illnessesGroups, groupCount);
            //    directorysDataSet.bolezniDataTable searchResult = directorysTableAdapterManager.bolezniTableAdapter.GetDataByGroupId(groupId);
            //    foreach (directorysDataSet.bolezniRow currentRow in searchResult.Rows)
            //    {
            //        illness.illness_id = currentRow.illness_id;
            //        illness.illness_name = currentRow.illness_name;
            //        illness.isOncology = currentRow.illness_oncology;
            //        illness.illness_type_id = 0;
            //        illness.illness_type_name = "�����������";
            //        TLPanel.Controls.Add(CreateCheckBox(currentRow.illness_name, illness));
            //    }
            //    groupCount++;
            //}
            //PageFilled();
            //try
            //{
            //    owner.Invoke(IllnessCallBack, new object[] { illnessesGroups });
            //}
            //catch
            //{
            //    System.Threading.Thread.CurrentThread.Abort();
            //}
        }
   
        /// <summary>
        /// ��������� �� ���� ������ ���������� ��� ��� � ��������� TabControl
        /// </summary>
        public void GenerateTCXControls()
        {
            //TCX tcx = new TCX();
            //string groupName; // ��� ������ ���
            //int groupId; // ID ������
            //int groupCount = 0;
            //// ���������� ���������� � ���� ������             
            //foreach (directorysDataSet.tcx_groupRow CurGroupRow in this.directorysDataSet.tcx_group.Rows)
            //{
            //    groupName = CurGroupRow.tcx_group_name;
            //    groupId = CurGroupRow.tcx_group_id;
            //    TableLayoutPanel TLPanel = CreatePage(groupName, tCXsGroups, groupCount);
            //    TLPanel.ColumnCount = 1;
            //    TLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            //    directorysDataSet.tcxDataTable searchResult = directorysTableAdapterManager.tcxTableAdapter.GetDataByGroupId(groupId);
            //    foreach (directorysDataSet.tcxRow CurTCXRow in searchResult.Rows)
            //    {
            //        // �������� ������� ��� ���� ��� � ��������� ��� ��������
            //        TCXUserControl tmpControl = new TCXUserControl(CurTCXRow.tcx_name);
            //        tcx.tcx_group_id = groupId;
            //        tcx.tcx_group_name = groupName;
            //        tcx.tcx_id = CurTCXRow.tcx_id;
            //        tcx.tcx_max = CurTCXRow.tcx_max;
            //        tcx.tcx_min = CurTCXRow.tcx_min;
            //        tcx.tcx_name = CurTCXRow.tcx_name;
            //        tmpControl.Maximum = CurTCXRow.tcx_max;
            //        tmpControl.Minimum = CurTCXRow.tcx_min;
            //        tmpControl.Tag = tcx;
            //        TLPanel.Controls.Add(tmpControl);
            //    }
            //    groupCount++;
            //}
            //PageFilled();
            //try
            //{
            //    owner.Invoke(TCXsCallback, new object[] { tCXsGroups });
            //}
            //catch
            //{
            //    System.Threading.Thread.CurrentThread.Abort();
            //}
        }
        /// <summary>
        /// ��������� �� ���� ������ ���������� ��� ������� � ��������� TabControl
        /// </summary>
        public void GenerateAnalysisControls() 
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ���������� �����������
        /// </summary>
        private void PageFilled()
        {
            fillingProcess++;            
            if (fillingProcess > 0) // �������� ��� ���������� �����
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
        #endregion

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