using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

namespace Saving_Stuff
{
    [System.Serializable]
    public class HighScoreSystem : MonoBehaviour
    {
        [Header("Score Display Objects")] [SerializeField]
        private TextMeshProUGUI scorePrefab;
        [SerializeField] private Transform scoreContent;
        
        [SerializeField] private TextMeshProUGUI nameDisplay;
        [SerializeField] private TextMeshProUGUI scoreDisplay;
        
        private HighScoreSystem instance;
        
        // Cool Saving Stuff~!
        private string FilePath => Application.streamingAssetsPath + "/save";
        private SaveData _gameSave;
        private SaveData _loadedGameData;

        private void Awake()
        {
            if (!instance)
            {
                Destroy(instance);
            }
            else
            {
                instance = this;
            }
            DisplayHighScore();
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
                scoreText.text = _highScores.name + " - " + _highScores.score;
            }
        }
        public void SaveGame()
        {
            _gameSave = new SaveData(UIScoreHandler.highScores);

            using (FileStream stream = new FileStream(FilePath + ".bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                
                bf.Serialize(stream, _gameSave);
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
                if (_loadedGameData != null) _loadedGameData.Sort();
            }
        }
    }
}