using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
namespace GenGenesis
{
    public partial class MainForm
    {
        #region Функции обработки пациента

        /// <summary>
        /// Создание нового пациента
        /// </summary>
        private void CreateNewPatient()
        {
            /// Проверим, проведены ли несохранённые изменения в текущем пациенте
            //
            if (currentPatient != null)
                // Если изменения сохранены...            
                if (currentPatient.isSaved)
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

        /// <summary>
        /// Загрузить данные о пациенте из базы данных
        /// </summary>
        private void LoadPatient()
        {
            // существует ли пациент
            if (currentPatient != null)
                // Если изменения сохранены...            
                if (currentPatient.isSaved)
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

        /// <summary>
        /// Сохраняем текущего пациента в базу данных
        /// </summary>
        private void SaveCurentPatient()
        {
            // Сохраняем
            currentPatient.Save(patientsTableAdapterManager);
            // Обновляем таблицу ID пациентов
            this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
        }

        /// <summary>
        /// Изменение полей текущего пациента
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
                MessageBox.Show("Некого изменять! Для начала создайте или найдите в поиске!", "Ошибочка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Удалить текущего пациента из базы данных
        /// </summary>
        private void DeleteCurentPatient() 
        {
            if (MessageBox.Show("Действительно удалить без возможности востановления?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                == DialogResult.OK)
            {
                // Удаляем
                currentPatient.Delete(patientsTableAdapterManager);
                // Обновляем таблицу ID пациентов
                this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);
                // Сделай кнопки не активными
                EnablePatientButtons(false);
                ResetAllTabControls();
                // Чистим дерево
                patientTreeView.Nodes.Clear();
                currentPatient = new Patient();
                currentPatient.isSaved = true;
                SetFormCaption(" ");
            }
        }

        /// <summary>
        /// // Изменение полей текущего пациента
        /// </summary>
        private void ShowNewPatientDialog()
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
                currentPatient = newPatient;
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

        /// <summary>
        /// Добавление новых свойств к текущему пациенту
        /// </summary>
        private void AddPropertyToCurentPatient()
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
            currentPatient.priznaki = signsList;
        }

        /// <summary>
        /// Добавление новых заболеваний к текущему пациенту
        /// </summary>
        private void AddIllnessToCurentPatient()
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
            currentPatient.bolezni = illnessList;
        }

        /// <summary>
        /// Добавление новых проб ТСХ в класс пациента
        /// </summary>
        private void AddTCXToCurentPatient()
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
            currentPatient.TCX = TCXList;
        }

        /// <summary>
        /// Добавление состояния генов
        /// </summary>
        private void AddGenesToCurentPatient()
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
            currentPatient.genes = genList;
        }
        /// <summary>
        /// Обновить данные с формы и добавить к текущему пациенту
        /// </summary>
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
            currentPatient.isSaved = false;            
            // Обновим дерево            
            FillTreeView();
        }
        #endregion


    }
}