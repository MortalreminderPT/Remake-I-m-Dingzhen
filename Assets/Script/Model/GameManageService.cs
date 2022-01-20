using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Model {
    public class GameManageService {
        // Start is called before the first frame update
        private static GameManageService _gameManageService;
        private int[] _highScore;
        private int[] _highDistance;
        private int _gameState = 0;
        // 0代表正常游戏, 1代表游戏暂停, 2代表游戏失败

        public static GameManageService getInstance() {
            if (_gameManageService == null) {
                _gameManageService = new GameManageService();
                _gameManageService._highScore = GetIntArray("HighScore", 0, 10);
            }
            return _gameManageService;
        }

        public void RemakeGame() {
            if (SceneManager.GetActiveScene().name == "GameScene") {
                _gameState = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene("GameScene");
            }
        }

        public void StartGame() {
            _gameState = 0;
            Time.timeScale = 1;
            if (SceneManager.GetActiveScene().name == "StartScene") {
                SceneManager.LoadScene("GameScene");
            }
        }

        public void ExitGame() {
            _gameState = 3;
            Time.timeScale = 1;
            if (SceneManager.GetActiveScene().name == "GameScene") {
                SceneManager.LoadScene("StartScene");
            }
        }

        public void PauseGame() {
            if (_gameState == 0) {
                _gameState = 1;
                Time.timeScale = 0;
            }
            else if (_gameState == 1) {
                _gameState = 0;
                Time.timeScale = 1;
            }
        }

        public int GetGameState() {
            return _gameState;
        }

        public void GameOver(int score) {
            //Time.timeScale = 0;
            if (_gameState == 2) return;
            Debug.Log("游戏失败，你的得分是" + score);
            for (int i = 0; i < 10; i++)
                if (score > _highScore[i])
                    (_highScore[i], score) = (score, _highScore[i]);
            _gameState = 2;
            //print("游戏失败，你的得分是"+_highScore);
            SetIntArray("HighScore", _highScore);
        }

        public int[] GetHighScore() {
            return _highScore;
        }

        // 可以抽象出Util类
        public static int[] GetIntArray(string key) {
            if (PlayerPrefs.HasKey(key)) {
                string[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
                int[] intArray = new int[stringArray.Length];
                for (int i = 0; i < stringArray.Length; i++)
                    intArray[i] = Convert.ToInt32(stringArray[i]);
                return intArray;
            }
            return new int[0];
        }

        public static int[] GetIntArray(string key, int defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key))
                return GetIntArray(key);
            int[] intArray = new int[defaultSize];
            for (int i = 0; i < defaultSize; i++)
                intArray[i] = defaultValue;
            return intArray;
        }

        public static bool SetIntArray(string key, params int[] intArray) {
            if (intArray.Length == 0) return false;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < intArray.Length - 1; i++)
                sb.Append(intArray[i]).Append("|");
            sb.Append(intArray[intArray.Length - 1]);

            try { PlayerPrefs.SetString(key, sb.ToString()); }
            catch { return false; }
            return true;
        }
    }
}