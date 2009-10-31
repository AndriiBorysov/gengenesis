using System.Windows.Forms;
namespace GenGenesis
{
    public partial class MainForm : Form
    {
        // Часть, которая обеспечивает функциональность toolTips
        ToolTip mainToolTip;
        private void InitializeToolTips()
        {
            mainToolTip = new ToolTip();            
            mainToolTip.AutomaticDelay = 100;
            mainToolTip.AutoPopDelay = 0;
            mainToolTip.ShowAlways = true;
            mainToolTip.SetToolTip(expandButton, "Развернуть все вкладки");
            mainToolTip.SetToolTip(collapseButton, "Свернуть все вкладки");
            newPatientButton.Text = "Создать нового пациента";
            savePatientButton.Text = "Сохранить пациента в базу данных";
            loadPatientButton.Text = "Загрузить данные о пациенте с базы данных";
            changePatientButton.Text =  "Изменить данные текущего пациента";
            deletePatientButton.Text =  "Удалить текущего пациента";
            addPropertyButton.Text = "Добавить внесенные изменения к пациенту";
            cancelButton.Text = "Отменить введённые значения";
        }
    }
}