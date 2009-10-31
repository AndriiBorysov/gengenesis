using System;
using System.Drawing;
using System.Windows.Forms;
namespace GenGenesis
{
    public partial class MainForm : Form
    {
        private void FillTreeView() // Заполение дерева
        {
            Cursor.Current = Cursors.WaitCursor;
            patientTreeView.BeginUpdate(); // Блокировка перерисовки
            patientTreeView.Nodes.Clear(); // Очистка
            
            #region Основные записи
            patientTreeView.Nodes.Add("# " + curentPatient.patient_id);
            if (curentPatient.surname.Length != 0)
                patientTreeView.Nodes.Add(curentPatient.surname);
            if (curentPatient.name.Length != 0)
                patientTreeView.Nodes.Add(curentPatient.name);
            if (curentPatient.third_name.Length != 0)
                patientTreeView.Nodes.Add(curentPatient.third_name);
            patientTreeView.Nodes.Add(curentPatient.sex);
            if (curentPatient.birthday != DateTime.MinValue)
                patientTreeView.Nodes.Add(curentPatient.birthday.ToLongDateString() + "р.");
            if (curentPatient.adress.Length != 0)
                patientTreeView.Nodes.Add("Адрес: " + curentPatient.adress);
            #endregion

            TreeViewAddSigns();
            TreeViewAddIllnesses();
            TreeViewAddTCXs();
            TreeViewAddGenes();
            ///////////////////////
            // Добавить остальные//
            ///////////////////////
            // Конец изменения
            patientTreeView.EndUpdate();
            // Нормальный курсор
            Cursor.Current = Cursors.Default;                       
        }
        private void TreeViewAddGenes()
        {
            string genesString = "Состояние генов";
            // Добавим гены
            TreeNode GenNode = patientTreeView.Nodes.Add(genesString);
            GenNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
            foreach (Gen oneGen in curentPatient.genes)
            {
                TreeNode newNode = new TreeNode();
                switch (oneGen.gen_stat)
                {
                    case -1:
                        newNode.ForeColor = Color.Red;
                        newNode.Text = oneGen.gen_name + "  -";
                        GenNode.Nodes.Add(newNode);
                        break;
                    case 0:
                        newNode.Text = oneGen.gen_name + "  0";
                        GenNode.Nodes.Add(newNode);
                        break;
                    case 1:
                        newNode.ForeColor = Color.Green;
                        newNode.Text = oneGen.gen_name + "  +";
                        GenNode.Nodes.Add(newNode);
                        break;
                }
            }
        }
        private void TreeViewAddTCXs()
        {
            string TCXstring = "Пробы ТСХ";
            // Добавляем TCX
            TreeNode TCXNode = patientTreeView.Nodes.Add(TCXstring, TCXstring);
            TCXNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
            foreach (TCX oneTCX in curentPatient.TCX)
            {
                TreeNode newNode = new TreeNode();
                // Ищем группу
                TreeNode[] searchedNodes = TCXNode.Nodes.Find(oneTCX.tcx_group_name, false);
                if (searchedNodes.Length > 0)
                {
                    // Если нашли такую группу
                    newNode.Text = oneTCX.tcx_name + "  " + oneTCX.tcx_value.ToString();
                    newNode.Name = oneTCX.tcx_name;
                    if (oneTCX.tcx_value < 0)
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
        private void TreeViewAddIllnesses()
        {
            string illnessString = "Заболевания";
            // Добавляем болезни
            TreeNode illnessNode = patientTreeView.Nodes.Add(illnessString);
            illnessNode.ForeColor = Color.FromKnownColor(KnownColor.Sienna);
            foreach (Illness oneIllness in curentPatient.bolezni)
            {
                TreeNode newNode = new TreeNode();
                // Ищем группу
                TreeNode[] searchedNodes = illnessNode.Nodes.Find(oneIllness.group_name, false);
                if (searchedNodes.Length > 0)
                {
                    // Если нашли такую группу
                    newNode.Text = oneIllness.illness_name;
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
                    illnessNode.Nodes.Add(groupNode);
                    newNode.Text = oneIllness.illness_name;
                    newNode.Name = oneIllness.illness_name;
                    newNode.ForeColor = Color.FromKnownColor(KnownColor.Chocolate);
                    illnessNode.Nodes[oneIllness.group_name].Nodes.Add(newNode);
                }
            }
        }
        private void TreeViewAddSigns()
        {
            string signsString = "Признаки";
            // Добавляем признаки
            TreeNode signsNode = patientTreeView.Nodes.Add(signsString);
            signsNode.ForeColor = Color.FromKnownColor(KnownColor.HotTrack);
            foreach (Sign oneSign in curentPatient.priznaki)
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
        private void FindInTreeView() // Найти в дереве и развернуть
        {

        }
    }
}