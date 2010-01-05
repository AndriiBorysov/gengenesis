using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
namespace GenGenesis
{
    public partial class MainForm
    {
        #region ������� ��������� ��������

        /// <summary>
        /// �������� ������ ��������
        /// </summary>
        private void CreateNewPatient()
        {
            /// ��������, ��������� �� ������������ ��������� � ������� ��������
            //
            if (currentPatient != null)
                // ���� ��������� ���������...            
                if (currentPatient.isSaved)
                {
                    ShowNewPatientDialog();
                }
                else
                {
                    // ..���� �� ���������, ���������� ���������..
                    DialogResult res = MessageBox.Show("��������� �� ���� ��������� � ���� ������, ���������?", "��������!",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:
                            // ��������� � ����
                            SaveCurentPatient();
                            ShowNewPatientDialog();
                            break;
                        case DialogResult.No:
                            ShowNewPatientDialog();
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            else
                // ���� ��� ��������� �� ��������, �������� ���
                ShowNewPatientDialog();
        }

        /// <summary>
        /// ��������� ������ � �������� �� ���� ������
        /// </summary>
        private void LoadPatient()
        {
            // ���������� �� �������
            if (currentPatient != null)
                // ���� ��������� ���������...            
                if (currentPatient.isSaved)
                {
                    ShowFindPatientDialog();
                }
                else
                {
                    // ..���� �� ���������, ���������� ���������..
                    DialogResult res = MessageBox.Show("��������� �� ���� ��������� � ���� ������, ���������?", "��������!",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (res)
                    {
                        case DialogResult.Yes:
                            // ��������� � ����
                            SaveCurentPatient();
                            ShowFindPatientDialog();
                            break;
                        case DialogResult.No:
                            ShowFindPatientDialog();
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            else
                ShowFindPatientDialog();
        }

        /// <summary>
        /// ��������� �������� �������� � ���� ������
        /// </summary>
        private void SaveCurentPatient()
        {
            // ���������
            currentPatient.Save(patientsTableAdapterManager);            
        }

        /// <summary>
        /// ��������� ����� �������� ��������
        /// </summary>
        private void ChangeCurentPatient()
        {
            if (currentPatient != null)
            {
                Patient newPatient = currentPatient;
                NewPatientForm newPatForm = new NewPatientForm(ref newPatient, true);
                DialogResult res = newPatForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    currentPatient = newPatient;
                    FillTreeView();
                }
            }
            else
            {
                MessageBox.Show("������ ��������! ��� ������ �������� ��� ������� � ������!", "��������!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ������� �������� �������� �� ���� ������
        /// </summary>
        private void DeleteCurentPatient() 
        {
            if (MessageBox.Show("������������� ������� ��� ����������� �������������?", "��������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                // �������
                currentPatient.Delete(patientsTableAdapterManager);                
                // ������ ������ �� ���������
                EnablePatientButtons(false);
                ResetAllTabControls();
                // ������ ������
                patientTreeView.Nodes.Clear();
                currentPatient = new Patient();
                currentPatient.isSaved = true;
                SetFormCaption(" ");
            }
        }

        /// <summary>
        /// // ��������� ����� �������� ��������
        /// </summary>
        private void ShowNewPatientDialog()
        {
            Patient newPatient = new Patient();
            NewPatientForm newPatForm = new NewPatientForm(ref newPatient);
            DialogResult res = newPatForm.ShowDialog();
            if (res == DialogResult.OK)
            {                
                currentPatient = newPatient;
                // ������ ������ ��������� 
                EnablePatientButtons(true);
                ResetAllTabControls();
                FillTreeView();
                SetFormCaption("");
                // �������� � ����� ������� ������ �������� � ���� ������
                SaveCurentPatient();
            }
        }

        #endregion

        #region ���������� ��������� ������� � ��������

        /// <summary>
        /// ���������� ����� ������� � �������� ��������
        /// </summary>
        private void AddPropertyToCurentPatient()
        {
            // ��� �������
            List<Sign> signsList = new List<Sign>();
            foreach (TabPage TPage in signsTabControl.TabPages)
            {
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    foreach (CheckBox CurControl in CurTLPanel.Controls)
                    {
                        if (CurControl.Checked)
                            signsList.Add((Sign)CurControl.Tag);
                    }
                }
            }
            currentPatient.priznaki = signsList;
        }

        /// <summary>
        /// ���������� ����� ����������� � �������� ��������
        /// </summary>
        private void AddIllnessToCurentPatient()
        {
            // ��� �����������
            List<Illness> illnessList = new List<Illness>();
            foreach (TabControl curTControl in illnessesTabControls)
                foreach (TabPage TPage in curTControl.TabPages)
                    foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                        foreach (CheckBox CurControl in CurTLPanel.Controls)
                        {
                            if (CurControl.Checked)
                            {
                                bool pr = false;
                                Illness curIll = (Illness)CurControl.Tag;
                                for(int i=0;i< illnessList.Count;i++)
                                {
                                    if ((illnessList[i].illness_name == curIll.illness_name)
                                        && (illnessList[i].group_name == curIll.group_name))
                                    {
                                        pr = true;
                                        curIll.illness_mask = illnessList[i].illness_mask | curIll.illness_mask;
                                        illnessList[i] = curIll;
                                        break;
                                    }

                                }
                                if (!pr) illnessList.Add(curIll);
                            }
                        }
            currentPatient.bolezni = illnessList;
        }

        /// <summary>
        /// ���������� ����� ���� ��� � �������� ��������
        /// </summary>
        private void AddTCXToCurentPatient()
        {
            List<TCX> TCXList = new List<TCX>();
            // ��� ������ �������� (����)
            foreach (TabPage TPage in tcxTabControl.TabPages)
            {
                // ��� ������ ������� ���������
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    // ��� ������� �������� �� �������
                    foreach (TCXUserControl CurControl in CurTLPanel.Controls)
                    {
                        if (CurControl.Checked)
                            TCXList.Add((TCX)CurControl.Tag);
                    }
                }
            }
            currentPatient.TCX = TCXList;
        }

        /// <summary>
        /// ���������� �������� � �������� ��������
        /// </summary>
        private void AddAnalysisToCurentPatient()
        {
            List<Analysis> AnalList = new List<Analysis>();
            // ��� ������ �������� (���� �������)
            for (int i = 0; i < analysisTabControls.Length; i++)
                foreach (TabPage tPage in analysisTabControls[i].TabPages)
                    foreach (TableLayoutPanel CurTLPanel in tPage.Controls)
                        foreach (Control CurControl in CurTLPanel.Controls)
                        {
                            CheckBox chkB = CurControl as CheckBox;
                            if (chkB != null)
                            {
                                if (chkB.Checked)
                                {
                                    Analysis T = (Analysis)chkB.Tag;
                                    T.analizes_value = 1;
                                    AnalList.Add(T);
                                }
                            }
                            AnalysisNumericUpDownControl tmpUpDownControl = CurControl as AnalysisNumericUpDownControl;
                            if (tmpUpDownControl != null)
                            {
                                if(tmpUpDownControl.Checked)
                                    AnalList.Add((Analysis)tmpUpDownControl.Tag);
                            }
                            AnalysisNumericUserControl tempNumControl = CurControl as AnalysisNumericUserControl;
                            if (tempNumControl != null)
                            {
                                if(tempNumControl.Checked)
                                    AnalList.Add((Analysis)tempNumControl.Tag);
                            }
                            AnalysisGenesUserControl tempGenControl = CurControl as AnalysisGenesUserControl;
                            if (tempGenControl != null)
                            {
                                if(tempGenControl.Checked)
                                    AnalList.Add((Analysis)tempGenControl.Tag);
                            }
                        }
            currentPatient.analysis = AnalList;
        }

        /// <summary>
        /// �������� ������ � ����� � �������� � �������� ��������
        /// </summary>
        private void AddAllPropertysToCurentPatient()
        {
            // ������� ��������� � �����
            AddPropertyToCurentPatient();
            AddIllnessToCurentPatient();
            AddTCXToCurentPatient();
            AddAnalysisToCurentPatient();            
            currentPatient.isSaved = false;            
            // ������� ������            
            FillTreeView();
        }
        #endregion


    }
}