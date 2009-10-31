using System;
using System.Data;
using System.Collections.Generic;
namespace GenGenesis
{
    public class Patient
    {
        #region Признаки
        public int patient_id { set; get; } // Номер карты пациента        
        public string surname { set; get; } // Фамилия       
        public string name { set; get; } // Имя
        public string third_name { set; get; } // Отчество                      
        public string sex { set; get; } // Пол        
        public DateTime birthday { get; set; } // Дата рождения  
        public string adress { set; get; } // Адрес      
        public bool isSaved { set; get; } // Сохранён ли пациент
        public bool isExist { set; get; } // Существует ли в базе
        public List<Sign> priznaki { set; get; } // признаки
        public List<Illness> bolezni { set; get; } // болезни
        public List<TCX> TCX { set; get; } // Пробы ТСХ
        public List<Gen> genes { set; get; } // Состояния генов
        #endregion
        // Конструктор
        public Patient()
        {
            this.name = "";
            this.surname = "";
            this.third_name = "";
            this.patient_id = 0;
            this.adress = "";
            this.sex = "";
            this.birthday = DateTime.MinValue;
            this.isSaved = false;
            this.isExist = false;
            priznaki = new List<Sign>();
            bolezni = new List<Illness>();
            TCX = new List<TCX>();
            genes = new List<Gen>();
        }

        #region Методы загрузки с базы данных
        private void LoadGenes(GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Загрузка генов
        {
            patientsDataSet.genesDataTable genesDataTable = patientsTableAdapters.genesTableAdapter.GetDataById(patient_id);
            foreach (GenGenesis.patientsDataSet.genesRow tmpRow in genesDataTable)
            {
                // Создадим новый ген
                Gen newGen;
                // Заполним поля гена
                foreach (GenGenesis.directorysDataSet.genes_allRow tmpGenRow in curDirectorysDB.genes_all.Rows)
                {
                    if (tmpGenRow.gen_id == tmpRow.gen_id)
                    {
                        newGen.gen_name = tmpGenRow.gen_name;
                        newGen.gen_id = tmpGenRow.gen_id;
                        newGen.gen_stat = tmpRow.gen_stat;
                        genes.Add(newGen);
                        break;
                    }                    
                }
            }
        }
        private void LoadTCX(GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Загрузка TCX
        {            
            patientsDataSet.tcx_allDataTable tcx_allDataTable = patientsTableAdapters.tcx_allTableAdapter.GetDataByPatient_ID(patient_id);
            foreach (GenGenesis.patientsDataSet.tcx_allRow tmpRow in tcx_allDataTable)
            {
                // Создадим новую пробу
                TCX newTCX;
                // Заполним поля пробы
                foreach (GenGenesis.directorysDataSet.tcxRow tmpTCXRow in curDirectorysDB.tcx.Rows)
                {
                    if (tmpTCXRow.tcx_id == tmpRow.tcx_id)
                    {
                        newTCX.tcx_name = tmpTCXRow.tcx_name;
                        newTCX.tcx_group_id = tmpTCXRow.tcx_group_id;
                        newTCX.tcx_id = tmpTCXRow.tcx_id;
                        newTCX.tcx_value = tmpRow.tcx_value;
                        newTCX.tcx_max = tmpTCXRow.tcx_max;
                        newTCX.tcx_min = tmpTCXRow.tcx_min;
                        foreach (GenGenesis.directorysDataSet.tcx_groupRow tmpTCXGroupRow in curDirectorysDB.tcx_group.Rows)
                        {
                            if (tmpTCXGroupRow.tcx_group_id == tmpTCXRow.tcx_group_id)
                            {
                                newTCX.tcx_group_name = tmpTCXGroupRow.tcx_group_name;
                                TCX.Add(newTCX);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        private void LoadIllness(GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Загрузка Болезней
        {            
            patientsDataSet.bolezni_tempDataTable bolezni_tempDataTable = patientsTableAdapters.bolezni_tempTableAdapter.GetDataByPatient_ID(patient_id);
            foreach (GenGenesis.patientsDataSet.bolezni_tempRow tmpRow in bolezni_tempDataTable)
            {
                // Создадим новый признак
                Illness newIllness;
                // Заполним поля признакапризнак
                foreach (GenGenesis.directorysDataSet.bolezniRow tmpBolezniRow in curDirectorysDB.bolezni.Rows)
                {
                    if (tmpBolezniRow["illness_id"].ToString() == tmpRow["illness_id"].ToString())
                    {
                        newIllness.illness_name = tmpBolezniRow.illness_name;
                        newIllness.group_id = tmpBolezniRow.illness_group_id;
                        newIllness.illness_id = tmpBolezniRow.illness_id;
                        foreach (GenGenesis.directorysDataSet.bolezni_groupRow tmpBolezniGroupRow in curDirectorysDB.bolezni_group.Rows)
                        {
                            if (tmpBolezniGroupRow.illness_group_id == tmpBolezniRow.illness_group_id)
                            {
                                newIllness.group_name = tmpBolezniGroupRow.illness_group_name;
                                bool pr = false;
                                foreach (DataRow curRow in curDirectorysDB.bolezni.Rows)
                                    if ((curRow["illness_id"].ToString() == newIllness.illness_id.ToString()))
                                    {
                                        pr = true;
                                        break;
                                    }
                                if (pr)
                                    newIllness.isOncology = true;
                                else
                                    newIllness.isOncology = false;
                                // ДОДЕЛАТЬ типы болезней
                                newIllness.illness_type_id = 0;
                                newIllness.illness_type_name = "Собственное";
                                //
                                bolezni.Add(newIllness);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        private void LoadSigns(GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Загрузка признаков
        {
            // Добавим признаки
            //patientsTableAdapters.priznaki_tempTableAdapter.FillByPatient_ID(curPatientDB.priznaki_temp, patient_id);
            patientsDataSet.priznaki_tempDataTable priznaki_tempDataTable = patientsTableAdapters.priznaki_tempTableAdapter.GetDataByPatient_ID(patient_id);
            foreach (GenGenesis.patientsDataSet.priznaki_tempRow tmpRow in priznaki_tempDataTable)
            {
                // Создадим новый признак
                Sign newSign;
                // Заполним поля признака             
                foreach (GenGenesis.directorysDataSet.priznakiRow tmpPriznakiRow in curDirectorysDB.priznaki.Rows)
                {
                    if (tmpPriznakiRow.sign_id == tmpRow.sign_id)
                    {
                        newSign.sign_name = tmpPriznakiRow.sign_name;
                        newSign.group_id = tmpPriznakiRow.sign_group_id;
                        newSign.sign_id = tmpPriznakiRow.sign_id;
                        foreach (GenGenesis.directorysDataSet.priznaki_groupRow tmpPriznakiGroupRow in curDirectorysDB.priznaki_group.Rows)
                        {
                            if (tmpPriznakiGroupRow.sign_group_id == tmpPriznakiRow.sign_group_id)
                            {
                                newSign.group_name = tmpPriznakiGroupRow.sign_group_name;
                                priznaki.Add(newSign);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
        #endregion 

        public void Load(int currentPatientId,  GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Загрузка с базы данных
        {
            // Заполняем таблицу с БД
            patientsDataSet.PatientDataTable patientDataTable = patientsTableAdapters.PatientTableAdapter.GetDataPatient(currentPatientId);
            // Читаем с таблицы в поля объекта пациента
            patient_id = patientDataTable[0].patient_id;
            name = patientDataTable[0].name;
            surname = patientDataTable[0].surname;
            third_name = patientDataTable[0].third_name;
            adress = patientDataTable[0].adress;
            sex = patientDataTable[0].sex;
            birthday = patientDataTable[0].birthday;
            // Призники
            LoadSigns(curDirectorysDB, patientsTableAdapters);
            // Добавим заболевания
            LoadIllness(curDirectorysDB, patientsTableAdapters);
            // Добавим пробы ТСХ
            LoadTCX(curDirectorysDB, patientsTableAdapters);
            // Добавим состояния генов
            LoadGenes(curDirectorysDB, patientsTableAdapters);
            ///////////////////////
            // ДОБАВИТЬ ОСТАЛЬНЫЕ
            ///////////////////////
            // Укажем что БД сохранена и пациент существует
            isSaved = true;
            isExist = true;
            // Заполняем признаки
            // Заполняем болезни
        }
        public bool Save(GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Сохранение в базу данных
        {           
            // Добавим или изменим пациента
            if (isExist)
            {   
                // Изменим существующего                
                // Изменяем поля главной записи                                
                patientsTableAdapters.PatientTableAdapter.Update(surname, name, third_name, sex, birthday, adress, patient_id);                
                /////////////////////
                // Добавим Признаки//
                /////////////////////
                // Сначала очистим все признаки текущего пациета во измбежании повторений
                patientsTableAdapters.priznaki_tempTableAdapter.Delete(patient_id);
                // Для каждого признака
                foreach (Sign tempSign in priznaki)
                   // Добавим признак
                    patientsTableAdapters.priznaki_tempTableAdapter.Insert(tempSign.sign_id, patient_id);
                ////////////////////////
                // Добавим Заболевания//
                ////////////////////////
                // Удаляем все заболевания связанные с данным пациентом
                patientsTableAdapters.bolezni_tempTableAdapter.Delete(patient_id);
                // Для каждого заболевания
                foreach (Illness tempIllness in bolezni)
                   // Добавим заболевание
                    patientsTableAdapters.bolezni_tempTableAdapter.Insert(patient_id, tempIllness.illness_id,tempIllness.illness_type_id);                
                /////////////////
                // Добавим TCX///
                /////////////////
                // Удаляем все пробы
                patientsTableAdapters.tcx_allTableAdapter.Delete(patient_id);
                // Для каждой пробы
                foreach (TCX tempTCX in TCX)
                   // Добавим пробу
                    patientsTableAdapters.tcx_allTableAdapter.Insert(patient_id, tempTCX.tcx_id, tempTCX.tcx_value);
                //////////////////
                // Добавим гены //
                //////////////////
                // Удаляем все гены
                patientsTableAdapters.genesTableAdapter.Delete(patient_id);
                // Для каждого гена
                foreach (Gen tempGen in genes)
                    patientsTableAdapters.genesTableAdapter.Insert(patient_id, tempGen.gen_id, tempGen.gen_stat);
                ///////////////////////
                // Добавить остальные//
                ///////////////////////                
                isSaved = true;                
                return true;
            }            
            else
            {
                // Добавляем пациента в базу данных            
                // Добавим базовые данные
                int res = patientsTableAdapters.PatientTableAdapter.Insert(patient_id, surname, name, third_name, sex, birthday, adress);             
                // Указываем что сохранили пациента
                isSaved = true;
                isExist = true;
                return true;
            }
        }
        public bool Delete(GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)// Удаление с базы данных
        {
            // Если существует
            if (isExist)
            {                
                // Очистим все признаки текущего пациета
                patientsTableAdapters.priznaki_tempTableAdapter.Delete(patient_id);
                // Удаляем все заболевания связанные с данным пациентом
                patientsTableAdapters.bolezni_tempTableAdapter.Delete(patient_id);
                // Удаляем все пробы
                patientsTableAdapters.tcx_allTableAdapter.Delete(patient_id);
                // Удаляем все гены
                patientsTableAdapters.genesTableAdapter.Delete(patient_id);
                ///////////////////////
                // Добавить остальные//
                ///////////////////////   
                // Удалим данные о пациенте
                patientsTableAdapters.PatientTableAdapter.DeleteById(patient_id);
                return true;
            }
            return false;
        }
    }

    #region Структуры базы данных
    /// <summary>
    /// Структура для признака
    /// </summary>
    public struct Sign
    {
        public int sign_id;
        public string sign_name;
        public int group_id;
        public string group_name;
    }
    /// <summary>
    /// Структура для болезни
    /// </summary>
    public struct Illness
    {
        public int illness_id;
        public string illness_name;
        public int group_id;
        public string group_name;
        public int illness_type_id;
        public string illness_type_name;
        public bool isOncology;
    }    
    /// <summary>
    ///  Структура для ТСХ
    /// </summary>
    public struct TCX
    {
        public int tcx_id;
        public int tcx_group_id;
        public int tcx_min;
        public int tcx_max;
        public int tcx_value;
        public string tcx_name;
        public string tcx_group_name;
    }    
    /// <summary>
    /// Cтруктура для обозначения состояния в гене
    /// </summary>
    public struct Gen
    {
        public string gen_name;
        public int gen_id;
        public int gen_stat;
    }
    #endregion
}
