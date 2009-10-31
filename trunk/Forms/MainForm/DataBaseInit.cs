using System;
namespace GenGenesis
{
    partial class MainForm
    {
        // Члены класса
        directorysDataSet directorysDataSet;
        directorysDataSetTableAdapters.TableAdapterManager directorysTableAdapterManager;
        directorysDataSetTableAdapters.bolezni_groupTableAdapter bolezni_groupTableAdapter;
        directorysDataSetTableAdapters.bolezni_typesTableAdapter bolezni_typesTableAdapter;
        directorysDataSetTableAdapters.bolezniTableAdapter bolezniTableAdapter;
        directorysDataSetTableAdapters.genes_allTableAdapter genes_allTableAdapter;
        directorysDataSetTableAdapters.priznaki_groupTableAdapter priznaki_groupTableAdapter;
        directorysDataSetTableAdapters.priznakiTableAdapter priznakiTableAdapter;
        directorysDataSetTableAdapters.tcx_groupTableAdapter tcx_groupTableAdapter;
        directorysDataSetTableAdapters.tcxTableAdapter tcxTableAdapter;

        patientsDataSet patientsDataSet;
        patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapterManager;
        patientsDataSetTableAdapters.bolezni_tempTableAdapter bolezni_tempTableAdapter;
        patientsDataSetTableAdapters.genesTableAdapter genesTableAdapter;
        patientsDataSetTableAdapters.PatientsIDListTableAdapter patientsIDListTableAdapter;
        patientsDataSetTableAdapters.PatientTableAdapter patientTableAdapter;
        patientsDataSetTableAdapters.priznaki_tempTableAdapter priznaki_tempTableAdapter;
        patientsDataSetTableAdapters.tcx_allTableAdapter tcx_allTableAdapter;        

        // Инициализация классов для работы базы данных
        private void InitializeDB()
        {
            directorysDataSet = new directorysDataSet();
            directorysTableAdapterManager = new GenGenesis.directorysDataSetTableAdapters.TableAdapterManager();
            bolezni_groupTableAdapter = new GenGenesis.directorysDataSetTableAdapters.bolezni_groupTableAdapter();
            bolezni_typesTableAdapter = new GenGenesis.directorysDataSetTableAdapters.bolezni_typesTableAdapter();
            bolezniTableAdapter = new GenGenesis.directorysDataSetTableAdapters.bolezniTableAdapter();
            genes_allTableAdapter = new GenGenesis.directorysDataSetTableAdapters.genes_allTableAdapter();
            priznaki_groupTableAdapter = new GenGenesis.directorysDataSetTableAdapters.priznaki_groupTableAdapter();
            priznakiTableAdapter = new GenGenesis.directorysDataSetTableAdapters.priznakiTableAdapter();
            tcx_groupTableAdapter = new GenGenesis.directorysDataSetTableAdapters.tcx_groupTableAdapter();
            tcxTableAdapter = new GenGenesis.directorysDataSetTableAdapters.tcxTableAdapter();

            patientsDataSet = new patientsDataSet();            
            bolezni_tempTableAdapter = new GenGenesis.patientsDataSetTableAdapters.bolezni_tempTableAdapter();
            genesTableAdapter = new GenGenesis.patientsDataSetTableAdapters.genesTableAdapter();
            patientsIDListTableAdapter = new GenGenesis.patientsDataSetTableAdapters.PatientsIDListTableAdapter();
            patientTableAdapter = new GenGenesis.patientsDataSetTableAdapters.PatientTableAdapter();
            priznaki_tempTableAdapter = new GenGenesis.patientsDataSetTableAdapters.priznaki_tempTableAdapter();
            tcx_allTableAdapter = new GenGenesis.patientsDataSetTableAdapters.tcx_allTableAdapter();
            patientsTableAdapterManager = new GenGenesis.patientsDataSetTableAdapters.TableAdapterManager();
            try
            {
                // Заполняем таблицы справочника                
                // Признаки
                this.priznaki_groupTableAdapter.Fill(this.directorysDataSet.priznaki_group);                
                this.priznakiTableAdapter.Fill(this.directorysDataSet.priznaki);                
                // Болезни
                this.bolezni_groupTableAdapter.Fill(this.directorysDataSet.bolezni_group);                
                this.bolezniTableAdapter.Fill(this.directorysDataSet.bolezni);
                // ТСХ
                this.tcx_groupTableAdapter.Fill(this.directorysDataSet.tcx_group);
                this.tcxTableAdapter.Fill(this.directorysDataSet.tcx);
                // Genes
                this.genes_allTableAdapter.Fill(this.directorysDataSet.genes_all);
                this.genesTableAdapter.Fill(this.patientsDataSet.genes);

                // Список номеров пациентов
                this.patientsIDListTableAdapter.Fill(this.patientsDataSet.PatientsIDList);

                // Заполняем менеджеры таблиц
                FillPatientTableAdapterManager();
                FillDirectorysTableAdapterManager();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString(),"Невозможно загрузить таблицы справочника");                
                this.Close();
            }

        }
        // Заполняем менеджер адаптеровТаблиц справочника
        private void FillDirectorysTableAdapterManager()
        {
            // Заполним менеджер адаптеров
            directorysTableAdapterManager.bolezni_groupTableAdapter = this.bolezni_groupTableAdapter;            
            directorysTableAdapterManager.bolezni_typesTableAdapter = this.bolezni_typesTableAdapter;
            directorysTableAdapterManager.bolezniTableAdapter = this.bolezniTableAdapter;
            directorysTableAdapterManager.genes_allTableAdapter = this.genes_allTableAdapter;
            directorysTableAdapterManager.priznaki_groupTableAdapter = this.priznaki_groupTableAdapter;
            directorysTableAdapterManager.priznakiTableAdapter = this.priznakiTableAdapter;
            directorysTableAdapterManager.tcx_groupTableAdapter = this.tcx_groupTableAdapter;
            directorysTableAdapterManager.tcxTableAdapter = this.tcxTableAdapter;            
        }
        // Заполняем менеджер адаптеровТаблиц пациента
        private void FillPatientTableAdapterManager()
        {
            // Заполним менеджер адаптеров                  
            patientsTableAdapterManager.PatientTableAdapter = this.patientTableAdapter;            
            patientsTableAdapterManager.priznaki_tempTableAdapter = this.priznaki_tempTableAdapter;
            patientsTableAdapterManager.bolezni_tempTableAdapter = this.bolezni_tempTableAdapter;
            patientsTableAdapterManager.tcx_allTableAdapter = this.tcx_allTableAdapter;
            patientsTableAdapterManager.genesTableAdapter = this.genesTableAdapter;
            ///////////////////////
            // Добавить остальные//
            ///////////////////////            
        }
    }
}