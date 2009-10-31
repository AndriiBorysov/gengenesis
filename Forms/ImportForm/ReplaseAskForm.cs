using System;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class ReplaseAskForm : Form
    {
        public int Value;
        patientsDataSet.PatientsIDListDataTable dataTable;
        public ReplaseAskForm(string aText, patientsDataSet.PatientsIDListDataTable _dataTable)
        {
            InitializeComponent();                        
            this.textLabel.Text = aText;
            this.dataTable = _dataTable;
        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void replaseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            Value = (int)numericUpDown.Value;
            if (dataTable.FindBypatient_id(Value) != null)
            {
                MessageBox.Show("Номер уже занят! Выберите другой!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.Abort;
            Close();
        }

    }
}
