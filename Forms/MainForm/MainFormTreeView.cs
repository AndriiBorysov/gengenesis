using System;
using System.Drawing;
using System.Windows.Forms;
namespace GenGenesis
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Заполение дерева
        /// </summary>
        private void FillTreeView()
        {
            Cursor.Current = Cursors.WaitCursor;
            patientTreeView.BeginUpdate(); // Блокировка перерисовки
            patientTreeView.Nodes.Clear(); // Очистка
            
            #region Основные записи
            patientTreeView.Nodes.Add("# " + currentPatient.card_number);
            if (currentPatient.surname.Length != 0)
                patientTreeView.Nodes.Add(currentPatient.surname);
            if (currentPatient.name.Length != 0)
                patientTreeView.Nodes.Add(currentPatient.name);
            if (currentPatient.third_name.Length != 0)
                patientTreeView.Nodes.Add(currentPatient.third_name);
            patientTreeView.Nodes.Add(currentPatient.sex);
            if (currentPatient.birthday != DateTime.MinValue)
                patientTreeView.Nodes.Add(currentPatient.birthday.ToLongDateString() + "р.");
            if (currentPatient.adress.Length != 0)
                patientTreeView.Nodes.Add("Адрес: " + currentPatient.adress);
            #endregion

            TreeViewAddSigns();
            TreeViewAddIllnesses();
            TreeViewAddTCXs();
            //TreeViewAddAnalysis();            
            // Конец изменения
            patientTreeView.EndUpdate();
            // Нормальный курсор
            Cursor.Current = Cursors.Default;                       
        }
        /// <summary>
        /// Добавление данных о анализах
        /// </summary>
        private void TreeViewAddAnalysis()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавление данных о ТСХ
        /// </summary>
        private void TreeViewAddTCXs()
        {
            string TCXstring = "Пробы ТСХ";
            // Добавляем TCX
            TreeNode TCXNode = patientTreeView.Nodes.Add(TCXstring, TCXstring);
            TCXNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
            foreach (TCX oneTCX in currentPatient.TCX)
            {
                TreeNode newNode = new TreeNode();
                // Ищем группу
                TreeNode[] searchedNodes = TCXNode.Nodes.Find(oneTCX.tcx_group_name, false);
                if (searchedNodes.Length > 0)
                {
                    // Если нашли такую группу
                    newNode.Text = oneTCX.tcx_name + "  " + oneTCX.tcx_value.ToString();
                    newNode.Name = oneTCX.tcx_name;
                    if (oneTCX.tcx_value <= 0)
                        newNode.ForeColor = Color.Red;
                    if (oneTCX.tcx_value > 0)
                        newNode.ForeColor = Color.Green;
                    searchedNodes[0].Nodes.Add(newNode);
                }
                else
                {
                    // Если не нашли такую группу
                    TreeNode groupNode = new TreeNode(oneTCX.tcx_group_name);
                    groupNode.Name = oneTCX.tcx_group_name;
                    groupNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
                    TCXNode.Nodes.Add(groupNode);
                    newNode.Text = oneTCX.tcx_name + "  " + oneTCX.tcx_value.ToString();
                    newNode.Name = oneTCX.tcx_name;
                    if (oneTCX.tcx_value <= 0)
                        newNode.ForeColor = Color.Red;
                    else
                        newNode.ForeColor = Color.Green;
                    TCXNode.Nodes[oneTCX.tcx_group_name].Nodes.Add(newNode);
                }
            }
        }

        /// <summary>
        /// Добавление данных о заболеваниях
        /// </summary>
        private void TreeViewAddIllnesses()
        {
            string illnessString = "Заболевания";
            // Добавляем болезни
            TreeNode illnessNode = patientTreeView.Nodes.Add(illnessString);
            illnessNode.ForeColor = Color.FromKnownColor(KnownColor.Sienna);
            // Добавим типы заболеваний
            foreach (directorysDataSet.bolezni_masksRow curRow in directorysDataSet.bolezni_masks)
            {
                illnessNode.Nodes.Add(curRow.mask_bol.ToString(), curRow.name_bol);
            }
            foreach (Illness oneIllness in currentPatient.bolezni)
            {
                TreeNode newNode = new TreeNode();                
                // Ищем группу
                for(int i =0;i< directorysDataSet.bolezni_masks.Count;i++)
                {
                    if ((oneIllness.illness_mask & directorysDataSet.bolezni_masks[i].mask_bol) > 0)
                    {
                        TreeNode[] searchedNodes = illnessNode.Nodes[i].Nodes.Find(oneIllness.group_name, false);
                        if (searchedNodes.Length > 0)
                        {
                            // Если нашли такую группу
                            if(oneIllness.isOncology)
                                newNode.Text = oneIllness.illness_name + " (онкология)";
                            else
                                newNode.Text = oneIllness.illness_name + " (онкология)";
                            newNode.Name = oneIllness.illness_name;
                            newNode.ForeColor = Color.FromKnownColor(KnownColor.Chocolate);
                            searchedNodes[0].Nodes.Add(newNode);
                        }
                        else
                        {
                            // Если не нашли такую группу
                            TreeNode groupNode = new TreeNode(oneIllness.group_name);
                            groupNode.Name = oneIllness.group_name;
                            groupNode.ForeColor = Color.FromKnownColor(KnownColor.Sienna);
                            illnessNode.Nodes[i].Nodes.Add(groupNode);
                            if (oneIllness.isOncology)
                                newNode.Text = oneIllness.illness_name + " (онк)";
                            else
                                newNode.Text = oneIllness.illness_name + " (онк)";                            
                            newNode.Name = oneIllness.illness_name;
                            newNode.ForeColor = Color.FromKnownColor(KnownColor.Chocolate);
                            illnessNode.Nodes[i].Nodes[oneIllness.group_name].Nodes.Add(newNode);
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Добавление данных о признаках
        /// </summary>
        private void TreeViewAddSigns()
        {
            string signsString = "Признаки";
            // Добавляем признаки
            TreeNode signsNode = patientTreeView.Nodes.Add(signsString);
            signsNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
            foreach (Sign oneSign in currentPatient.priznaki)
            {
                TreeNode newNode = new TreeNode();
                // Ищем группу
                TreeNode[] searchedNodes = signsNode.Nodes.Find(oneSign.group_name, false);
                if (searchedNodes.Length > 0)
                {
                    // Если нашли такую группу
                    newNode.Text = oneSign.sign_name;
                    newNode.ForeColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
                    newNode.Name = oneSign.sign_name;
                    searchedNodes[0].Nodes.Add(newNode);
                }
                else
                {
                    // Если не нашли такую группу
                    TreeNode groupNode = new TreeNode(oneSign.group_name);
                    groupNode.Name = oneSign.group_name;
                    groupNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
                    signsNode.Nodes.Add(groupNode);
                    newNode.Text = oneSign.sign_name;
                    newNode.ForeColor = Color.FromKnownColor(KnownColor.DeepSkyBlue);
                    newNode.Name = oneSign.sign_name;
                    signsNode.Nodes[oneSign.group_name].Nodes.Add(newNode);
                }
            }
        }

        /// <summary>
        /// Поиск в дереве
        /// </summary>
        private void FindInTreeView() // Найти в дереве и развернуть
        {
            throw new NotImplementedException();
        }
    }
}