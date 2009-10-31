using System;
using System.Windows.Forms;
namespace GenGenesis
{
    public partial class NewPatientForm : Form
    {
        Patient curPatient;
        // Стандартный
        public NewPatientForm(ref Patient cp)
        {            
            InitializeComponent();
            curPatient = cp;            
        }
        // Конструктор на изменение
        public NewPatientForm(ref Patient cp, bool exist)
        {            
            InitializeComponent();
            curPatient = cp;
            this.idTextBox.Enabled = false;
            this.Text = "Изменение данных пациента";
            this.idTextBox.Text = curPatient.patient_id.ToString();            
            this.surnameTextBox.Text = curPatient.surname;
            this.nameTextBox.Text= curPatient.name;
            this.sexComboBox.Text = curPatient.sex;
            this.third_nameTextBox.Text = curPatient.third_name;
            if(curPatient.birthday == DateTime.MinValue)
            {
                this.dateTimePicker.Value = DateTime.Now;
            }
            else
                this.dateTimePicker.Value = curPatient.birthday;
            this.adressTextBox.Text = curPatient.adress;
        }
        // Сохранить результат
        private void OKButton_Click(object sender, System.EventArgs e)
        {
            // Создадим екземпляр обьекта пациента                        
            int id;
            if (!int.TryParse(this.idTextBox.Text, out id))
            {
                ShowErrMessage("Проверьте вводимый параметр!");
                return;
            }
            curPatient.patient_id = id;
            curPatient.surname = this.surnameTextBox.Text;
            curPatient.name = this.nameTextBox.Text;
            curPatient.third_name = this.third_nameTextBox.Text;
            curPatient.sex = this.sexComboBox.Text;
            curPatient.birthday = this.dateTimePicker.Value;
            curPatient.adress = this.adressTextBox.Text;
            curPatient.isSaved = false;
            // Передадим основной форме нового пациента            
            DialogResult = DialogResult.OK;
            this.Close();
        }
        // Отменить введённые изменения
        private void NoButton_Click(object sender, System.EventArgs e)
        {            
            this.Close();
        }
        private void ShowErrMessage(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        private void NewPatientForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    OKButton_Click(sender, null);
                    break;
                case (char)Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
