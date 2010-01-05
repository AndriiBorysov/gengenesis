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
        /// Добавление новых проб ТСХ к текущему пациента
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
        /// Добавление анализов к текущему пациенту
        /// </summary>
        private void AddAnalysisToCurentPatient()
        {
            List<Analysis> AnalList = new List<Analysis>();
            // Для каждой страницы (Типа анализа)
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
        /// Обновить данные с формы и добавить к текущему пациенту
        /// </summary>
        private void AddAllPropertysToCurentPatient()
        {
            // Добавим изменения в класс
            AddPropertyToCurentPatient();
            AddIllnessToCurentPatient();
            AddTCXToCurentPatient();
            AddAnalysisToCurentPatient();            
            currentPatient.isSaved = false;            
            // Обновим дерево            
            FillTreeView();
        }
        #endregion


    }
}