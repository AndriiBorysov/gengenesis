using System;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class FindPatientForm : Form
    {
        // Переменные
        public int curPatient; // Возвращаемый пациент                
        GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters; // Набор таблиц
        // Конструктор
        public FindPatientForm(GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {
            InitializeComponent();            
            this.patientsTableAdapters = patientsTableAdapters;
        }
        private void OKbutton_Click(object sender, EventArgs e)// Кнопка подтверждения 
        {
            SelectOne();
        }
        private void SelectOne()
        {
            if (dataGridView.CurrentRow == null)
                return;
            this.DialogResult = DialogResult.OK;
            curPatient = (int)dataGridView.CurrentRow.Cells["patient_id"].Value;
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)        // Кнопка отмены
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void findButton_Click(object sender, EventArgs e)// Нажатие на кнопку поиска по БД
        {
            GenGenesis.patientsDataSet.patientsDataTable tmpTable = patientsTableAdapters.patientsTableAdapter.GetDataByIDorSurname((int)patientNumericUpDown.Value, surNameTextBox.Text);
            dataGridView.DataSource = tmpTable;
            dataGridView.Columns[0].Visible = false;
            // Названия столбцов
            dataGridView.Columns[1].HeaderCell.Value = (object)"Номер карточки";
            dataGridView.Columns[2].HeaderCell.Value = (object)"Фамилия";
            dataGridView.Columns[3].HeaderCell.Value = (object)"Имя";
            dataGridView.Columns[4].HeaderCell.Value = (object)"Отчество";
            dataGridView.Columns[5].HeaderCell.Value = (object)"Пол";
            dataGridView.Columns[6].HeaderCell.Value = (object)"Дата рождения";
            dataGridView.Columns[7].HeaderCell.Value = (object)"Адрес";
            dataGridView.Columns[8].HeaderCell.Value = (object)"Дата поступления";
        }
        private void findAllButton_Click(object sender, EventArgs e)// Вывод всех 
        {
            GenGenesis.patientsDataSet.patientsDataTable tmpTable = patientsTableAdapters.patientsTableAdapter.GetAll();
            dataGridView.DataSource = tmpTable;
            dataGridView.Columns[0].Visible = false;
            // Названия столбцов
            dataGridView.Columns[1].HeaderCell.Value = (object)"Номер карточки";
            dataGridView.Columns[2].HeaderCell.Value = (object)"Фамилия";
            dataGridView.Columns[3].HeaderCell.Value = (object)"Имя";
            dataGridView.Columns[4].HeaderCell.Value = (object)"Отчество";
            dataGridView.Columns[5].HeaderCell.Value = (object)"Пол";
            dataGridView.Columns[6].HeaderCell.Value = (object)"Дата рождения";
            dataGridView.Columns[7].HeaderCell.Value = (object)"Адрес";
            dataGridView.Columns[8].HeaderCell.Value = (object)"Дата поступления";
        }
        private void dataGridView_DoubleClick(object sender, EventArgs e)// Двойное нажатие на таблице
        {
            SelectOne();
        }
        private void FindPatientForm_KeyPress(object sender, KeyPressEventArgs e)// Обработчики нажатий
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    findButton_Click(sender, null);
                    break;
                case (char)Keys.Escape:
                    Close();
                    break;
            }
        }
        
    }
}
