using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
namespace GenGenesis
{
    public partial class MainForm
    {
        #region Функции обработки пациента
        private void CreateNewPatient() // Создание нового пациента
        {
            /// Проверим, проведены ли несохранённые изменения в текущем пациенте
            //
            if (curentPatient != null)
                // Если изменения сохранены...            
                if (curentPatient.isSaved)
                {
                    ShowNewPatientDialog();
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
                // Если нет указателя на пациента, создадим его
                ShowNewPatientDialog();
        }
        private void LoadPatient() // Октрыть пациента
        {
            // существует ли пациент
            if (curentPatient != null)
                // Если изменения сохранены...            
                if (curentPatient.isSaved)
                {
                    ShowFindPatientDialog();
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
        private void SaveCurentPatient() // Сохраняем текущего пациента в базу данных
        {
            // Сохраняем
            curentPatient.Save(patientsTableAdapterManager);
            // Обновляем таблицу ID пациентов
            this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
        }
        private void ChangeCurentPatient()// Изменение полей пациента
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
                MessageBox.Show("Некого изменять! Для начала создайте или найдите в поиске!", "Ошибочка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteCurentPatient() // Удалить текущего пациента
        {
            if (MessageBox.Show("Действительно удалить без возможности востановления?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                // Удаляем
                curentPatient.Delete(patientsTableAdapterManager);
                // Обновляем таблицу ID пациентов
                this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
                // Сделай кнопки не активными
                EnablePatientButtons(false);
                ResetAllTabControls();
                // Чистим дерево
                patientTreeView.Nodes.Clear();
                curentPatient = new Patient();
                curentPatient.isSaved = true;
                SetFormCaption(" ");
            }
        }
        private void ShowNewPatientDialog() // Показывает диалог создания нового пациента
        {
            Patient newPatient = new Patient();
            NewPatientForm newPatForm = new NewPatientForm(ref newPatient);
            DialogResult res = newPatForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                // Проверяем, входит ли id_patient в базу данных, во избежание повторений                            
                while (patientsDataSet.PatientsIDList.FindBypatient_id(newPatient.patient_id) != null)
                {
                    if (newPatForm.DialogResult != DialogResult.OK)
                        return;
                    MessageBox.Show("Такой номер карты уже встречается!\nИзмените номер карты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newPatForm.ShowDialog();
                }
                curentPatient = newPatient;
                // Делаем Кноаки активными 
                EnablePatientButtons(true);
                ResetAllTabControls();
                FillTreeView();
                SetFormCaption("");
                // Создадим и сразу добавим нового пациента в базу данных
                SaveCurentPatient();
            }
        }
        #endregion

        #region Добавление различных свойств к пациенту
        private void AddPropertyToCurentPatient() // Добавление новых свойств в класс пациента
        {
            // Для свойств
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
        private void AddIllnessToCurentPatient() // Добавление новых заболеваний в класс пациента
        {
            // Для заболеваний
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
        private void AddTCXToCurentPatient() // Добавление новых проб ТСХ в класс пациента
        {
            List<TCX> TCXList = new List<TCX>();
            // Для каждой страницы (Типа)
            foreach (TabPage TPage in tcxTabControl.TabPages)
            {
                // Для каждой таблицы контролов
                foreach (TableLayoutPanel CurTLPanel in TPage.Controls)
                {
                    // Для каждого контрола на таблице
                    foreach (TCXUserControl CurControl in CurTLPanel.Controls)
                    {
                        if (CurControl.Checked)
                            TCXList.Add((TCX)CurControl.Tag);
                    }
                }
            }
            curentPatient.TCX = TCXList;
        }
        private void AddGenesToCurentPatient() // Добавление состояния генов
        {
            List<Gen> genList = new List<Gen>();
            // Для каждой таблицы контролов
            TableLayoutPanel CurTLPanel = (TableLayoutPanel)genesTabControl.TabPages[0].Controls[0];
            // Для каждого контрола на таблице
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
            // Добавим изменения в класс
            AddPropertyToCurentPatient();
            AddIllnessToCurentPatient();
            AddTCXToCurentPatient();
            AddGenesToCurentPatient();
            ///////////////////////
            // Добавить остальные//
            ///////////////////////
            curentPatient.isSaved = false;
            //this.patientTreeView.
            // Обновим дерево            
            FillTreeView();
        }
        #endregion


    }
}