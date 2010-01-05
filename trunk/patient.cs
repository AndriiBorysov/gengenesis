using System;
using System.Data;
using System.Collections.Generic;
namespace GenGenesis
{
    public class Patient
    {
        #region Признаки
        public int patient_id { set; get; } // id пациента
        public int card_number { set; get; } // Номер карты пациента
        public string surname { set; get; } // Фамилия   
        public string name { set; get; } // Имя
        public string third_name { set; get; } // Отчество                      
        public string sex { set; get; } // Пол        
        public DateTime birthday { get; set; } // Дата рождения  
        public DateTime JoinDate { get; set; } // Дата поступления 
        public string adress { set; get; } // Адрес      
        public bool isSaved { set; get; } // Сохранён ли пациент
        public bool isExist { set; get; } // Существует ли в базе
        public List<Sign> priznaki { set; get; } // признаки
        public List<Illness> bolezni { set; get; } // болезни
        public List<TCX> TCX { set; get; } // Пробы ТСХ
         public List<Analysis> analysis { set; get; } // Анализы
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
            this.JoinDate = DateTime.MinValue;
            this.isSaved = false;
            this.isExist = false;
            priznaki = new List<Sign>();
            bolezni = new List<Illness>();
            TCX = new List<TCX>();
            analysis = new List<Analysis>();
        }

        #region Методы загрузки с базы данных
        /// <summary>
        /// Загрузка с базы данных информации о анализах
        /// </summary>
        /// <param name="curDirectorysDB"></param>
        /// <param name="patientsTableAdapters"></param>
        private void LoadAnalysis(GenGenesis.directorysDataSet curDirectorysDB,
            GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {
            patientsDataSet.analyses_linkDataTable analyses_linkDataTable = patientsTableAdapters.analyses_linkTableAdapter.GetDataByPatient_ID(patient_id);
            
            foreach (GenGenesis.patientsDataSet.analyses_linkRow tmpRow in analyses_linkDataTable)
            {
                Analysis newAnal;
                
                foreach (GenGenesis.directorysDataSet.analyzes_groupsRow tmpAnalRow in curDirectorysDB.analyzes_groups.Rows)
                    if (tmpAnalRow.id_analizes == tmpRow.id_analizes)
                    {
                        newAnal.analysis_name = tmpAnalRow.analize_name;
                        newAnal.analizes_id = tmpAnalRow.id_analizes;
                        newAnal.analazes_type_id = tmpAnalRow.analyse_type_id;
                        newAnal.analyses_value_type_id = tmpAnalRow.analyse_value_type_id;
                        newAnal.analizes_value = tmpRow.value;
                        newAnal.analyses_value_type_name = "";
                        newAnal.analazes_type_name = "";
                        foreach (GenGenesis.directorysDataSet.analyses_value_typesRow analyses_value_typesRow in curDirectorysDB.analyses_value_types.Rows)
                            if (analyses_value_typesRow.id_value_types == newAnal.analyses_value_type_id)
                            {
                                newAnal.analyses_value_type_name = analyses_value_typesRow.type_name;
                                break;
                            }
                        foreach (GenGenesis.directorysDataSet.analyzes_typesRow analyzes_typesRow in curDirectorysDB.analyzes_types.Rows)
                            if (analyzes_typesRow.id_analazes_type == newAnal.analazes_type_id)
                            {
                                newAnal.analazes_type_name = analyzes_typesRow.type_name;
                                analysis.Add(newAnal);
                                break;
                            }
                        break;
                    }
            }
        }

        /// <summary>
        /// Загрузка с базы данных информации о ТСХ
        /// </summary>
        /// <param name="curDirectorysDB"></param>
        /// <param name="patientsTableAdapters"></param>
        private void LoadTCX(GenGenesis.directorysDataSet curDirectorysDB
            , GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {
            patientsDataSet.tcx_linkDataTable tcx_linkDataTable = patientsTableAdapters.tcx_linkTableAdapter.GetDataByPatient_ID(patient_id);
            foreach (GenGenesis.patientsDataSet.tcx_linkRow tmpPatRow in tcx_linkDataTable)
            {
                TCX newTCX;
                foreach (GenGenesis.directorysDataSet.tcx_allRow tmpDirRow in curDirectorysDB.tcx_all.Rows)
                {
                    if (tmpDirRow.tcx_id == tmpPatRow.tcx_id)
                    {
                        newTCX.tcx_name = tmpDirRow.tcx_name;
                        newTCX.tcx_id = tmpDirRow.tcx_id;
                        newTCX.tcx_group_id = tmpPatRow.id_tcx_group;                        
                        newTCX.tcx_value = tmpPatRow.tcx_value;
                        foreach (GenGenesis.directorysDataSet.tcx_groupsRow tmpTCXGroupRow in curDirectorysDB.tcx_groups.Rows)
                        {
                            if (tmpTCXGroupRow.id_tcx_group == tmpPatRow.id_tcx_group)
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

        /// <summary>
        /// Загрузка с базы данных информации о болезнях
        /// </summary>
        /// <param name="curDirectorysDB"></param>
        /// <param name="patientsTableAdapters"></param>
        private void LoadIllness(GenGenesis.directorysDataSet curDirectorysDB, 
            GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {
            patientsDataSet.bolezni_linkDataTable bolezni_linkDataTable = patientsTableAdapters.bolezni_linkTableAdapter.GetDataByPatient_ID(patient_id);
            foreach (GenGenesis.patientsDataSet.bolezni_linkRow tmpRow in bolezni_linkDataTable)
            {                
                Illness newIllness;             
                foreach (GenGenesis.directorysDataSet.bolezni_allRow tmpBolezniRow in curDirectorysDB.bolezni_all.Rows)
                    if (tmpBolezniRow.illness_id == tmpRow.illness_id)
                    {
                        newIllness.illness_name = tmpBolezniRow.illness_name;
                        newIllness.group_id = tmpBolezniRow.illness_group_id;
                        newIllness.illness_id = tmpBolezniRow.illness_id;
                        newIllness.illness_mask = tmpRow.mask_bol;
                        newIllness.isOncology = tmpBolezniRow.illness_oncology;
                        foreach (GenGenesis.directorysDataSet.bolezni_groupsRow tmpBolezniGroupRow in curDirectorysDB.bolezni_groups.Rows)
                            if (tmpBolezniGroupRow.illness_group_id == tmpBolezniRow.illness_group_id)
                            {
                                newIllness.group_name = tmpBolezniGroupRow.illness_group_name;                                                               
                                bolezni.Add(newIllness);
                                break;
                            }
                        break;
                    }
            }
        }

        /// <summary>
        /// Загрузка с базы данных информации о признаках
        /// </summary>
        /// <param name="curDirectorysDB"></param>
        /// <param name="patientsTableAdapters"></param>
        private void LoadSigns(GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {   
            patientsDataSet.priznaki_linkDataTable priznaki_linkDataTable = patientsTableAdapters.priznaki_linkTableAdapter.GetDataByPatient_ID(patient_id);
            foreach (GenGenesis.patientsDataSet.priznaki_linkRow tmpPatRow in priznaki_linkDataTable)
            {                
                Sign newSign;             
                foreach (GenGenesis.directorysDataSet.priznaki_allRow tmpDirRow in curDirectorysDB.priznaki_all.Rows)
                    if (tmpDirRow.sign_id == tmpPatRow.sign_id)
                    {
                        newSign.sign_name = tmpDirRow.sign_name;
                        newSign.group_id = tmpDirRow.sign_group_id;
                        newSign.sign_id = tmpDirRow.sign_id;
                        foreach (GenGenesis.directorysDataSet.priznaki_groupsRow tmpPriznakiGroupRow in curDirectorysDB.priznaki_groups.Rows)
                            if (tmpPriznakiGroupRow.sign_group_id == tmpDirRow.sign_group_id)
                            {
                                newSign.group_name = tmpPriznakiGroupRow.sign_group_name;
                                priznaki.Add(newSign);
                                break;
                            }
                        break;
                    }
            }
        }
        #endregion 

        /// <summary>
        /// Загрузка пациента с базы данных
        /// </summary>
        /// <param name="currentPatientId"></param>
        /// <param name="curDirectorysDB"></param>
        /// <param name="patientsTableAdapters"></param>
        public void Load(int currentPatientId,  GenGenesis.directorysDataSet curDirectorysDB, GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {
            // Заполняем таблицу с БД
            patientsDataSet.patientsDataTable patientsDataTable = patientsTableAdapters.patientsTableAdapter.GetDataPatient(currentPatientId);
            // Читаем с таблицы в поля объекта пациента
            patient_id = patientsDataTable[0].patient_id;
            card_number = patientsDataTable[0].card_number;
            name = patientsDataTable[0].name;
            surname = patientsDataTable[0].surname;
            third_name = patientsDataTable[0].third_name;
            adress = patientsDataTable[0].adress;
            sex = patientsDataTable[0].sex;
            birthday = patientsDataTable[0].birthday;
            JoinDate = patientsDataTable[0].JoinDate;
            // Призники
            LoadSigns(curDirectorysDB, patientsTableAdapters);
            // Добавим заболевания
            LoadIllness(curDirectorysDB, patientsTableAdapters);
            //// Добавим пробы ТСХ
            LoadTCX(curDirectorysDB, patientsTableAdapters);
            //// Добавим анализы
            LoadAnalysis(curDirectorysDB, patientsTableAdapters);
            
            // Укажем что БД сохранена и пациент существует
            isSaved = true;
            isExist = true;            
        }

        /// <summary>
        /// Сохранение в базу данных
        /// </summary>
        /// <param name="patientsTableAdapters"></param>
        /// <returns></returns>
        public bool Save(GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {           
            // Добавим или изменим пациента
            if (isExist)
            {   
                // Изменим существующего                
                // Изменяем поля главной записи                                
                patientsTableAdapters.patientsTableAdapter.Update(card_number, surname, name, third_name, sex, birthday, adress,JoinDate, patient_id);
                
                // Сначала очистим все признаки текущего пациета во измбежании повторений
                patientsTableAdapters. priznaki_linkTableAdapter.Delete(patient_id);
                // Для каждого признака
                foreach (Sign tempSign in priznaki)
                   // Добавим признак
                    patientsTableAdapters.priznaki_linkTableAdapter.Insert(tempSign.sign_id, patient_id);
                //// Удаляем все заболевания связанные с данным пациентом
                patientsTableAdapters.bolezni_linkTableAdapter.Delete(patient_id);
                //// Для каждого заболевания
                foreach (Illness tempIllness in bolezni)
                   // Добавим заболевание
                   patientsTableAdapters.bolezni_linkTableAdapter.Insert(patient_id, tempIllness.illness_id,tempIllness.illness_mask);
                // Удаляем все TCX
                patientsTableAdapters.tcx_linkTableAdapter.Delete(patient_id);
                //// Для каждой пробы TCX
                foreach (TCX tempTCX in TCX)                   
                    patientsTableAdapters.tcx_linkTableAdapter.Insert(patient_id, tempTCX.tcx_id, tempTCX.tcx_value,tempTCX.tcx_group_id);
                // Удаляем анализы
                patientsTableAdapters.analyses_linkTableAdapter.Delete(patient_id);
                // Добавляем анализы
                foreach (Analysis tempAnal in analysis)
                    patientsTableAdapters.analyses_linkTableAdapter.Insert(patient_id, tempAnal.analizes_id, tempAnal.analizes_value);
                isSaved = true;                
                return true;
            }            
            else
            {
                // Добавляем пациента в базу данных            
                // Добавим базовые данные
                patientsTableAdapters.patientsTableAdapter.Insert(card_number, surname, name, third_name, sex, birthday, adress,JoinDate);
                patient_id = (int)patientsTableAdapters.patientsTableAdapter.GetMaxID();
                // Указываем что сохранили пациента
                isSaved = true;
                isExist = true;
                return true;
            }
        }

        /// <summary>
        /// Удаление пациента с базы данных
        /// </summary>
        /// <param name="patientsTableAdapters"></param>
        /// <returns></returns>
        public bool Delete(GenGenesis.patientsDataSetTableAdapters.TableAdapterManager patientsTableAdapters)
        {
            // Если существует
            if (isExist)
            {                
                // Очистим все признаки текущего пациета
                patientsTableAdapters.priznaki_linkTableAdapter.Delete(patient_id);
                //// Удаляем все заболевания связанные с данным пациентом
                patientsTableAdapters.bolezni_linkTableAdapter.Delete(patient_id);
                //// Удаляем все пробы
                patientsTableAdapters.tcx_linkTableAdapter.Delete(patient_id);
                // Удалим анализы
                patientsTableAdapters.analyses_linkTableAdapter.Delete(patient_id);
                // Удалим данные о пациенте
                patientsTableAdapters.patientsTableAdapter.DeleteById(patient_id);
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
        public int illness_mask;
        public bool isOncology;        
    }    
    /// <summary>
    ///  Структура для ТСХ
    /// </summary>
    public struct TCX
    {
        public int tcx_id;
        public int tcx_group_id;        
        public int tcx_value;
        public string tcx_name;
        public string tcx_group_name;
    }    
    /// <summary>
    /// Cтруктура для обозначения Анализа
    /// </summary>
    public struct Analysis
    {
        public string analysis_name;
        public int analizes_id;
        public int analazes_type_id;
        public string analazes_type_name;        
        public int analyses_value_type_id;
        public string analyses_value_type_name;
        public double analizes_value;
    }
    #endregion
}
