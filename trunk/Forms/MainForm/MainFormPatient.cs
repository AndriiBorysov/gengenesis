using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
namespace GenGenesis
{
    public partial class MainForm
    {
        #region ������� ��������� ��������
        private void CreateNewPatient() // �������� ������ ��������
        {
            /// ��������, ��������� �� ������������ ��������� � ������� ��������
            //
            if (curentPatient != null)
                // ���� ��������� ���������...            
                if (curentPatient.isSaved)
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
        private void LoadPatient() // ������� ��������
        {
            // ���������� �� �������
            if (curentPatient != null)
                // ���� ��������� ���������...            
                if (curentPatient.isSaved)
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
        private void SaveCurentPatient() // ��������� �������� �������� � ���� ������
        {
            // ���������
            curentPatient.Save(patientsTableAdapterManager);
            // ��������� ������� ID ���������
            this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
        }
        private void ChangeCurentPatient()// ��������� ����� ��������
        {
            if (curentPatient != null)
            {
                Patient newPatient = curentPatient;
                NewPatientForm newPatForm = new NewPatientForm(ref newPatient, true);
                DialogResult res = newPatForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    curentPatient = newPatient;
                    FillTreeView();
                }
            }
            else
            {
                MessageBox.Show("������ ��������! ��� ������ �������� ��� ������� � ������!", "��������!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteCurentPatient() // ������� �������� ��������
        {
            if (MessageBox.Show("������������� ������� ��� ����������� �������������?", "��������", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                // �������
                curentPatient.Delete(patientsTableAdapterManager);
                // ��������� ������� ID ���������
                this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
                // ������ ������ �� ���������
                EnablePatientButtons(false);
                ResetAllTabControls();
                // ������ ������
                patientTreeView.Nodes.Clear();
                curentPatient = new Patient();
                curentPatient.isSaved = true;
                SetFormCaption(" ");
            }
        }
        private void ShowNewPatientDialog() // ���������� ������ �������� ������ ��������
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
                curentPatient = newPatient;
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
        private void AddPropertyToCurentPatient() // ���������� ����� ������� � ����� ��������
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
            curentPatient.priznaki = signsList;
        }
        private void AddIllnessToCurentPatient() // ���������� ����� ����������� � ����� ��������
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
            curentPatient.bolezni = illnessList;
        }
        private void AddTCXToCurentPatient() // ���������� ����� ���� ��� � ����� ��������
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
            curentPatient.TCX = TCXList;
        }
        private void AddGenesToCurentPatient() // ���������� ��������� �����
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
            curentPatient.genes = genList;
        }
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
            curentPatient.isSaved = false;
            //this.patientTreeView.
            // ������� ������            
            FillTreeView();
        }
        #endregion


    }
}