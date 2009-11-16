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
            this.Text = "Изменение данных пациента";
            this.idTextBox.Text = curPatient.card_number.ToString();            
            this.surnameTextBox.Text = curPatient.surname;
            this.nameTextBox.Text= curPatient.name;
            this.sexComboBox.Text = curPatient.sex;
            this.third_nameTextBox.Text = curPatient.third_name;            
            if(curPatient.birthday == DateTime.MinValue)
            {
                this.bDateTimePicker.Value = DateTime.Now;
            }
            else
                this.bDateTimePicker.Value = curPatient.birthday;
            this.adressTextBox.Text = curPatient.adress;
            if (curPatient.JoinDate == DateTime.MinValue)
            {
                this.joinDateTimePicker.Value = DateTime.Now;
            }
            else
                this.joinDateTimePicker.Value = curPatient.JoinDate;
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
            curPatient.card_number= id;
            curPatient.surname = this.surnameTextBox.Text;
            curPatient.name = this.nameTextBox.Text;
            curPatient.third_name = this.third_nameTextBox.Text;
            curPatient.sex = this.sexComboBox.Text;
            curPatient.birthday = this.bDateTimePicker.Value;
            curPatient.adress = this.adressTextBox.Text;
            curPatient.JoinDate = this.joinDateTimePicker.Value;
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
