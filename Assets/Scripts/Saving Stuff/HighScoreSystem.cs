using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

namespace Saving_Stuff
{
    [System.Serializable]
    public class HighScoreSystem : MonoBehaviour
    {
        [Header("Score Display Objects")] [SerializeField]
        private TextMeshProUGUI scorePrefab;
        [SerializeField] private Transform scoreContent;

        // Cool Saving Stuff~!
        private string FilePath => Application.streamingAssetsPath + "/save";
        private SaveData _gameData;
        private SaveData _loadedGameData;

        private void Start()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
                Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        
        public void DisplayHighScore()
        {
            
            foreach (Transform child in scoreContent)
            {
                Destroy(child.gameObject);
            }

            foreach (HighScores _highScores in _loadedGameData.highScores)
            {
                TextMeshProUGUI scoreText = Instantiate(scorePrefab, scoreContent);
                scoreText.text = _highScores.name + " - " + _highScores.score.ToString("0");
            }
        }
        public void SaveGame()
        {
            _gameData = new SaveData(UIScoreHandler.highScores);

            using (FileStream stream = new FileStream(FilePath + ".bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                
                bf.Serialize(stream, _gameData);
            }
        }

        public void LoadGame()
        {
            if (File.Exists(FilePath + ".bin"))
            {
                Debug.Log("Loaded Save File");
                return;
            }
            else
            {
                Debug.Log("No Save Found!!");
            }

            using (FileStream stream = new FileStream(FilePath + ".bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                
                _loadedGameData = bf.Deserialize(stream) as SaveData;
                _loadedGameData.Sort();
            }
        }
    }
}