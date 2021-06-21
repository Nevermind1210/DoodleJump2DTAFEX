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
        private string FilePath2 => Application.streamingAssetsPath + "/doingyourmom";
        private SaveData _gameData;
        private SaveData _loadedGameData;

        private void Awake()
        {
            // This prevents nullreferences and allows saves to be found.
            if (!Directory.Exists(Application.streamingAssetsPath))
                Directory.CreateDirectory(Application.streamingAssetsPath);
            SaveGame();
        }
        
        public void DisplayHighScore()
        {
            foreach (Transform child in scoreContent) // this deletes preview content for scene editors.
            {
                Destroy(child.gameObject);
            }
            
            foreach (HighScore _highScore in _loadedGameData.highScores) // This should iterate through the list and show the list BUG: how ever it isn't
            {
                TextMeshProUGUI scoreText = Instantiate(scorePrefab, scoreContent);
                scoreText.text = _highScore.name + " - " + _highScore.score.ToString("0");
            }
        }
        
        public void SaveGame()
        {
            Debug.Log("Saving Data");
            _gameData = new SaveData(UIScoreHandler.highScores);

            using (FileStream stream = new FileStream(FilePath + ".bin", FileMode.OpenOrCreate)) // OpenOrCreate and the using "using" should basically create the file and or if it exists open it!
            {
                // the using will basically open and close it similar to how a "type".Close(); will function just in one line!
                BinaryFormatter bf = new BinaryFormatter();
                
                bf.Serialize(stream, _gameData);
            }
        }

        public void LoadGame()
        {
            // This should find the file and return it
            if (File.Exists(FilePath + ".bin"))
            {
                Debug.Log("Loaded Save File");
            }
            else
            {
                Debug.Log("No Save Found!!");
            }

            using (FileStream stream = new FileStream(FilePath + ".bin", FileMode.Open)) // similarly to what we did in SaveGame()
            {
                // we Open it and close it after we Deserialize it.
                BinaryFormatter bf = new BinaryFormatter();
                _loadedGameData = bf.Deserialize(stream) as SaveData;
                UIScoreHandler.highScores = _loadedGameData.highScores;
               // _loadedGameData.Sort(); // and sort by score!
            }
        }
    }
}