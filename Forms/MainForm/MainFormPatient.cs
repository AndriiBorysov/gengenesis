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
            // ��������� ������� ID ���������
            this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
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
                // ��������� ������� ID ���������
                this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
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
                // ���������, ������ �� id_patient � ���� ������, �� ��������� ����������                            
                while (patientsDataSet.PatientsIDList.FindBypatient_id(newPatient.patient_id) != null)
                {
                    if (newPatForm.DialogResult != DialogResult.OK)
                        return;
                    MessageBox.Show("����� ����� ����� ��� �����������!\n�������� ����� �����!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newPatForm.ShowDialog();
                }
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
            foreach (TabPage TPage in diseasesTabControl.TabPages)
            {
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    foreach (CheckBox CurControl in CurTLPanel.Controls)
                    {
                        if (CurControl.Checked)
                            illnessList.Add((Illness)CurControl.Tag);
                    }
                }
            }
            currentPatient.bolezni = illnessList;
        }

        /// <summary>
        /// ���������� ����� ���� ��� � ����� ��������
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
        /// ���������� ��������� �����
        /// </summary>
        private void AddGenesToCurentPatient()
        {
            List<Gen> genList = new List<Gen>();
            // ��� ������ ������� ���������
            TableLayoutPanel CurTLPanel = (TableLayoutPanel)genesTabControl.TabPages[0].Controls[0];
            // ��� ������� �������� �� �������
            foreach (Control CurControl in CurTLPanel.Controls)
                if (CurControl is GenesUserControl)
                {
                    GenesUserControl CurGenesControl = (GenesUserControl)CurControl;
                    if (CurGenesControl.Checked)
                    {
                        Gen gen = (Gen)CurGenesControl.Tag;
                        gen.gen_stat = CurGenesControl.Value;
                        genList.Add(gen);
                    }
                }
            currentPatient.genes = genList;
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
            AddGenesToCurentPatient();
            ///////////////////////
            // �������� ���������//
            ///////////////////////
            currentPatient.isSaved = false;            
            // ������� ������            
            FillTreeView();
        }
        #endregion


    }
}