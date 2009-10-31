using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class DataBaseEditorForm : Form
    {
        GenGenesis.directorysDataSet directorysDB;
        directorysDataSetTableAdapters.TableAdapterManager _directorysTableAdapterManager;        
        List<directorysSchema> schemaList;
        bool isSaved;
        public DataBaseEditorForm(GenGenesis.directorysDataSet aDirectorysDB, directorysDataSetTableAdapters.TableAdapterManager directorysTableAdapterManager)
        {
            InitializeComponent();
            directorysDB = aDirectorysDB;            
            _directorysTableAdapterManager = directorysTableAdapterManager;            
            schemaList = new List<directorysSchema>();
            // Заполним список
            FillListBox();
            // Выбираем первый            
            tablesListBox.SelectedIndex = 0;
            isSaved = false;

        }
        
        // Заполнение дерева
        public void FillListBox()
        {   
            foreach (DataTable curDataTable in directorysDB.Tables)
            {
                directorysSchema tmpSchema = new directorysSchema();
                tmpSchema.tableName = curDataTable.TableName;
                tmpSchema.dataTable = curDataTable;
                schemaList.Add(tmpSchema);
                tablesListBox.Items.Add(tmpSchema.tableName);
            }            
        }
        private class directorysSchema
        {
            public string tableName;
            public DataTable dataTable;            
        }
        // Выбор какого либо элемента
        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            dataGridView.DataSource = schemaList[tablesListBox.SelectedIndex].dataTable;            
        }

        private void okButton_Click(object sender, EventArgs e)
        {            
            // Сохраняем изменения в базу данных
            _directorysTableAdapterManager.UpdateAll(directorysDB);            
            DialogResult = DialogResult.OK;
            isSaved = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.Cancel;            
            Close();
        }

        private void DataBaseEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if((!isSaved)&&(MessageBox.Show("Сохранить перед выходом?","Внимание",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // Сохраняем изменения в базу данных
                _directorysTableAdapterManager.UpdateAll(directorysDB);
                DialogResult = DialogResult.OK;
            }
        }       
    }
}

