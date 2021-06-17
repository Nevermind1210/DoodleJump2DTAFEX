using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Saving_Stuff
{
    public class HighScoreSystem : MonoBehaviour, IComparer<SaveData>
    {
        private static HighScoreSystem instance;
        private string filePath;
        public List<SaveData> dataToSave = new List<SaveData>();
        
        [Header("Data Holder")]
        [SerializeField] private int scoreToSave;
        private int positionToSave;
        [SerializeField] private string nameToSave;
        
        [Header("PlayerFeedBack")]
        [SerializeField] private GameObject failedDeletion;
        [SerializeField] private GameObject successDeletion;

        private void Awake()
        {
            if (!instance)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            filePath = Application.persistentDataPath + "/save.bin";
            SaveGame();
        }

        public SaveData SaveGame()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + 
                                          "/save.bin");

            SaveData data = new SaveData();
            data.savedHighScore = scoreToSave;
            data.savedPosition = positionToSave;
            data.savedPName = nameToSave;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game data saved!");
            return null;
        }

        public SaveData LoadGame()
        {
            if(File.Exists(Application.persistentDataPath 
                            + "/save.bin"))
            {
                //file existence
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                    File.Open(Application.persistentDataPath
                              + "Save.bin", FileMode.Open);
                SaveData data = (SaveData) bf.Deserialize(file);
                file.Close();
                scoreToSave = data.savedHighScore;
                positionToSave = data.savedPosition;
                nameToSave = data.savedPName;
                return data;
            }
            else
            {
                Debug.LogError("THERE ISN'T A SAVE DOOFUS");
                return null;
            }
        }

        public SaveData ResetData()
        {
            if (File.Exists(Application.persistentDataPath
                            + "save.bin"))
            {
                File.Delete(Application.persistentDataPath
                            + "save.bin");
                 scoreToSave = 0;
                 positionToSave = 0;
                 nameToSave = "";
                 successDeletion.SetActive(true);
                 Debug.Log("Data Reset Complete");
                 StartCoroutine(successDelete());
            }
            else
                failedDeletion.SetActive(true);
                Debug.LogError("No save data to delete!!");
                StartCoroutine(failedDelete());
                return null;
        }

        IEnumerator failedDelete()
        {
            yield return new WaitForSeconds(3);
            failedDeletion.SetActive(false);
        }
        
        IEnumerator successDelete()
        {
            yield return new WaitForSeconds(3);
            successDeletion.SetActive(false);
        }

        public int Compare(SaveData x, SaveData y)
        {
            return x.savedPosition - y.savedPosition;
        }
    }
    
    [Serializable]
    public class SaveData
    {
        public int savedHighScore;
        public int savedPosition;
        public string savedPName;
    }
}