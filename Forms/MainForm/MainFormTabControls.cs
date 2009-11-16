using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
namespace GenGenesis
{
    public partial class MainForm
    {
        // ������ ��������� ��� ������ �������
        public delegate void SignsCreateCallback(TabPage[] tabPages);        
        public delegate void IllnessesCreateCallback(TabPage[] tabPages, int i);
        public delegate void TCXsCreateCallback(TabPage[] tabPages);
        public delegate void AnalysisCreateCallback(TabPage[] tabPages);
        public delegate void EnabledButtonsCallback(bool stat);
        public delegate void ShowMessageCallback(string messege);
        // ������ TabControls
        TabControl signsTabControl;
        TabControl[] illnessesTabControls;
        TabControl IllnessesTabControl;
        TabControl tcxTabControl;
        TabControl analysisTabControl;
        /// <summary>
        /// ������������� TabControls
        /// </summary>
        public void InitializeTabControls()
        {
            signsTabControl = InitTabControl();
            illnessesTabControls = new TabControl[directorysDataSet.bolezni_masks.Count];
            for(int i = 0; i< directorysDataSet.bolezni_masks.Count; i++)
            {
                illnessesTabControls[i] = InitTabControl();
            }
            IllnessesTabControl = InitTabControl();
            tcxTabControl = InitTabControl();
            analysisTabControl = InitTabControl();
        }

        /// <summary>
        /// ������ ������ ��� ����������
        /// </summary>
        /// <returns>�������� control</returns>
        private TabControl InitTabControl()
        {
            TabControl tmpControl = new TabControl();
            tmpControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;            
            tmpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tmpControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            tmpControl.HotTrack = true;
            tmpControl.Location = new System.Drawing.Point(0, 0);
            tmpControl.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            tmpControl.Multiline = true;
            tmpControl.SelectedIndex = 0;
            tmpControl.Size = new System.Drawing.Size(449, 515);
            tmpControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;            
            return tmpControl;
        }
        /// <summary>
        /// ���������� ���������
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillSigns(TabPage[] pages)         
        {            
            signsTabControl.TabPages.Clear();
            toolStripProgressBar.Value += 1;
            signsTabControl.TabPages.AddRange(pages);                        
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>        
        private void FillIllnesses(TabPage[] pages, int i)
        {            
            toolStripProgressBar.Value += 1;
            illnessesTabControls[i].TabPages.Clear();
            illnessesTabControls[i].TabPages.AddRange(pages);
        }

        /// <summary>
        /// ���������� ���
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillTCX(TabPage[] pages)
        {
            toolStripProgressBar.Value += 1;
            tcxTabControl.TabPages.Clear();
            tcxTabControl.TabPages.AddRange(pages);                        
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        /// <param name="pages">������ ������� ��� ����������</param>
        private void FillAnalysis(TabPage[] pages)
        {
            toolStripProgressBar.Value += 1;
            analysisTabControl.TabPages.Clear();
            analysisTabControl.TabPages.AddRange(pages);                        
        }

        /// <summary>
        /// �������� � ���������� ��� ����������
        /// </summary>
        private void FillTabControls()
        {               
            // ��������� �������� � ����������
            EnableMainButtons(false);
            ShowToolBoxMassage("�������� ���� ������...");
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
            illnessThread.Start();
            tcxThread.Start();
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
            foreach (TabControl curTControl in illnessesTabControls)
            {
                foreach (TabPage TPage in curTControl.TabPages)
                {
                    foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                    {
                        foreach (CheckBox CurControl in CurTLPanel.Controls)
                        {
                            CurControl.Checked = false;
                        }
                    }
                }
            }
            // �C�
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
            FillIllnessControlByCurentPatient();
            FillTCXControlByCurentPatient();
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
            //// ��������� �������
            foreach (TabControl curTControl in illnessesTabControls)
                foreach (TabPage TPage in curTControl.TabPages)
                {
                    TableLayoutPanel CurTLPanel = (TableLayoutPanel)TPage.Controls[0];
                    foreach (CheckBox CurControl in CurTLPanel.Controls)
                    {
                        Illness controlIllness = (Illness)CurControl.Tag;
                        // ��� ������ ������� � �������� ��������
                        foreach (Illness tmpIllness in currentPatient.bolezni)
                            // ���� ���������� �� ����� ������� � ����� ������� ���������
                            if ((controlIllness.illness_name == tmpIllness.illness_name) 
                                && (controlIllness.group_name == tmpIllness.group_name)
                                && ((tmpIllness.illness_mask & controlIllness.illness_mask) > 0))
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
            Illness illness = new Illness();
            string groupName; // ��� ������ ���������
            int groupId; // ID ������                       
            for (int i = 0; i < directorysDataSet.bolezni_masks.Count; i++)
            {
                int groupCount = 0;
                // ���������� ���������� � ���� ������             
                foreach (directorysDataSet.bolezni_groupsRow CurrentGroupRow in this.directorysDataSet.bolezni_groups.Rows)
                {
                    groupName = CurrentGroupRow.illness_group_name;
                    groupId = CurrentGroupRow.illness_group_id;
                    illness.group_id = groupId;
                    illness.group_name = groupName;
                    TableLayoutPanel TLPanel = CreatePage(groupName, illnessesGroups, groupCount);
                    directorysDataSet.bolezni_allDataTable searchResult = directorysTableAdapterManager.bolezni_allTableAdapter.GetDataByGroupId(groupId);
                    foreach (directorysDataSet.bolezni_allRow currentRow in searchResult.Rows)
                    {
                        illness.illness_id = currentRow.illness_id;
                        illness.illness_name = currentRow.illness_name;
                        illness.isOncology = currentRow.illness_oncology;
                        illness.illness_mask = directorysDataSet.bolezni_masks[i].mask_bol;
                        TLPanel.Controls.Add(CreateCheckBox(currentRow.illness_name, illness));
                    }
                    groupCount++;
                }
                try
                {                                        
                    owner.Invoke(IllnessCallBack, new object[] { illnessesGroups, i });
                }
                catch
                {
                    System.Threading.Thread.CurrentThread.Abort();
                }
            }
            PageFilled();
        }
   
        /// <summary>
        /// ��������� �� ���� ������ ���������� ��� ��� � ��������� TabControl
        /// </summary>
        public void GenerateTCXControls()
        {
            TCX tcx = new TCX();
            string groupName; // ��� ������ ���
            int groupId; // ID ������
            int groupCount = 0;
            // ���������� ���������� � ���� ������             
            foreach (directorysDataSet.tcx_groupsRow CurGroupRow in this.directorysDataSet.tcx_groups.Rows)
            {
                groupName = CurGroupRow.tcx_group_name;
                groupId = CurGroupRow.id_tcx_group;
                TableLayoutPanel TLPanel = CreatePage(groupName, tCXsGroups, groupCount);
                TLPanel.ColumnCount = 1;
                TLPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;                
                foreach (directorysDataSet.tcx_allRow CurTCXRow in directorysDataSet.tcx_all.Rows)
                {
                    // �������� ������� ��� ���� ��� � ��������� ��� ��������
                    TCXUserControl tmpControl = new TCXUserControl(CurTCXRow.tcx_name);
                    tcx.tcx_group_id = groupId;
                    tcx.tcx_group_name = groupName;
                    tcx.tcx_id = CurTCXRow.tcx_id;                    
                    tcx.tcx_name = CurTCXRow.tcx_name;
                    tmpControl.Maximum = 5;
                    tmpControl.Minimum = -5;
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
            if (fillingProcess == 3) // �������� ��� ���������� �����
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