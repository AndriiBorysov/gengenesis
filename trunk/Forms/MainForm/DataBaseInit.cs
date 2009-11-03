using System;
namespace GenGenesis
{
    partial class MainForm
    {
        // Члены класса
        directorysDataSet directorysDataSet;
        directorysDataSetTableAdapters.TableAdapterManager directorysTableAdapterManager;
        directorysDataSetTableAdapters.analyses_value_typesTableAdapter analyses_value_typesTableAdapter;
        directorysDataSetTableAdapters.analyzes_groupsTableAdapter analyzes_groupsTableAdapter;
        directorysDataSetTableAdapters.analyzes_typesTableAdapter analyzes_typesTableAdapter;
        directorysDataSetTableAdapters.bolezni_masksTableAdapter bolezni_masksTableAdapter;
        directorysDataSetTableAdapters.bolezni_allTableAdapter bolezni_allTableAdapter;        
        directorysDataSetTableAdapters.bolezni_groupsTableAdapter bolezni_groupsTableAdapter;
        directorysDataSetTableAdapters.priznaki_allTableAdapter priznaki_allTableAdapter;
        directorysDataSetTableAdapters.priznaki_groupsTableAdapter priznaki_groupsTableAdapter;
        directorysDataSetTableAdapters.tcx_allTableAdapter tcx_allTableAdapter;
        directorysDataSetTableAdapters.tcx_groupsTableAdapter tcx_groupsTableAdapter;

        patientsDataSet patientsDataSet;        
        patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapterManager;
        patientsDataSetTableAdapters.analyses_linkTableAdapter analyses_linkTableAdapter;
        patientsDataSetTableAdapters.bolezni_linkTableAdapter bolezni_linkTableAdapter;        
        patientsDataSetTableAdapters.patientsTableAdapter patientsTableAdapter;
        patientsDataSetTableAdapters.priznaki_linkTableAdapter priznaki_linkTableAdapter;
        patientsDataSetTableAdapters.tcx_linkTableAdapter tcx_linkTableAdapter;       
        
        /// <summary>
        /// Инициализация классов для работы базы данных 
        /// </summary>
        private void InitializeDB()
        {
            directorysDataSet = new directorysDataSet();
            directorysTableAdapterManager = new GenGenesis.directorysDataSetTableAdapters.TableAdapterManager();
            analyses_value_typesTableAdapter = new GenGenesis.directorysDataSetTableAdapters.analyses_value_typesTableAdapter();
            analyzes_groupsTableAdapter = new GenGenesis.directorysDataSetTableAdapters.analyzes_groupsTableAdapter();
            analyzes_typesTableAdapter = new GenGenesis.directorysDataSetTableAdapters.analyzes_typesTableAdapter();
            bolezni_masksTableAdapter = new GenGenesis.directorysDataSetTableAdapters.bolezni_masksTableAdapter();
            bolezni_allTableAdapter = new GenGenesis.directorysDataSetTableAdapters.bolezni_allTableAdapter();
            bolezni_groupsTableAdapter = new GenGenesis.directorysDataSetTableAdapters.bolezni_groupsTableAdapter();
            priznaki_allTableAdapter = new GenGenesis.directorysDataSetTableAdapters.priznaki_allTableAdapter();
            priznaki_groupsTableAdapter = new GenGenesis.directorysDataSetTableAdapters.priznaki_groupsTableAdapter();
            tcx_allTableAdapter = new GenGenesis.directorysDataSetTableAdapters.tcx_allTableAdapter();
            tcx_groupsTableAdapter = new GenGenesis.directorysDataSetTableAdapters.tcx_groupsTableAdapter();

            patientsDataSet = new patientsDataSet();
            patientsTableAdapterManager = new GenGenesis.patientsDataSetTableAdapters.TableAdapterManager();
            analyses_linkTableAdapter = new GenGenesis.patientsDataSetTableAdapters.analyses_linkTableAdapter();
            bolezni_linkTableAdapter = new GenGenesis.patientsDataSetTableAdapters.bolezni_linkTableAdapter();            
            patientsTableAdapter = new GenGenesis.patientsDataSetTableAdapters.patientsTableAdapter();
            priznaki_linkTableAdapter = new GenGenesis.patientsDataSetTableAdapters.priznaki_linkTableAdapter();
            tcx_linkTableAdapter = new GenGenesis.patientsDataSetTableAdapters.tcx_linkTableAdapter();
            try
            {
                // Заполняем таблицы справочника                
                // Признаки
                this.priznaki_allTableAdapter.Fill(this.directorysDataSet.priznaki_all);
                this.priznaki_groupsTableAdapter.Fill(this.directorysDataSet.priznaki_groups);                
                // Болезни
                this.bolezni_allTableAdapter.Fill(this.directorysDataSet.bolezni_all);                
                this.bolezni_groupsTableAdapter.Fill(this.directorysDataSet.bolezni_groups);
                this.bolezni_masksTableAdapter.Fill(this.directorysDataSet.bolezni_masks);
                // ТСХ
                this.tcx_allTableAdapter.Fill(this.directorysDataSet.tcx_all);
                this.tcx_groupsTableAdapter.Fill(this.directorysDataSet.tcx_groups);
                // Анализы
                this.analyses_value_typesTableAdapter.Fill(this.directorysDataSet.analyses_value_types);
                this.analyzes_groupsTableAdapter.Fill(this.directorysDataSet.analyzes_groups);
                this.analyzes_typesTableAdapter.Fill(this.directorysDataSet.analyzes_types);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message.ToString(), "Невозможно загрузить таблицы справочника");
                this.Close();
            }            
            // Заполняем менеджеры таблиц
            FillPatientTableAdapterManager();
            FillDirectorysTableAdapterManager();
        }

        /// <summary>
        /// Заполняем менеджер адаптеров таблиц справочника
        /// </summary>
        private void FillDirectorysTableAdapterManager()
        {
            // Заполним менеджер адаптеров
            directorysTableAdapterManager.analyses_value_typesTableAdapter = this.analyses_value_typesTableAdapter;            
            directorysTableAdapterManager.analyzes_groupsTableAdapter = this.analyzes_groupsTableAdapter;
            directorysTableAdapterManager.analyzes_typesTableAdapter = this.analyzes_typesTableAdapter;
            directorysTableAdapterManager.bolezni_allTableAdapter = this.bolezni_allTableAdapter;
            directorysTableAdapterManager.bolezni_groupsTableAdapter = this.bolezni_groupsTableAdapter;
            directorysTableAdapterManager.bolezni_masksTableAdapter = this.bolezni_masksTableAdapter;
            directorysTableAdapterManager.priznaki_allTableAdapter = this.priznaki_allTableAdapter;
            directorysTableAdapterManager.priznaki_groupsTableAdapter = this.priznaki_groupsTableAdapter;
            directorysTableAdapterManager.tcx_allTableAdapter = this.tcx_allTableAdapter;
            directorysTableAdapterManager.tcx_groupsTableAdapter = this.tcx_groupsTableAdapter;            
        }

        /// <summary>
        /// Заполняем менеджер адаптеров таблиц пациента
        /// </summary>
        private void FillPatientTableAdapterManager()
        {
            // Заполним менеджер адаптеров                  
            patientsTableAdapterManager.analyses_linkTableAdapter = this.analyses_linkTableAdapter;            
            patientsTableAdapterManager.bolezni_linkTableAdapter = this.bolezni_linkTableAdapter;
            patientsTableAdapterManager.patientsTableAdapter = this.patientsTableAdapter;
            patientsTableAdapterManager.priznaki_linkTableAdapter = this.priznaki_linkTableAdapter;
            patientsTableAdapterManager.tcx_linkTableAdapter = this.tcx_linkTableAdapter;                                    
        }
    }
}