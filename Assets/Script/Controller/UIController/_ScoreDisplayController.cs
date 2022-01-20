using Script.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Controller {
    public class ScoreDisplayController : MonoBehaviour {
        // Start is called before the first frame update
        public GameObject ScoreUI;
        private GameObject _ui;
        private GameObject _scoreBoard;
        private GameManageService _gameManageService;
        
        void Start() {
            _ui = GameObject.Find("UI");
            _gameManageService = GameManageService.getInstance();
            loadScoreBoard(_gameManageService.GetHighScore());
        }

        private void loadScoreBoard(int[] highScore) {
            _scoreBoard = Object.Instantiate(ScoreUI, _ui.transform);
            Debug.Log(highScore.ToString());
            for (int i = 0, j = 0; i < _scoreBoard.transform.childCount; i++) {
                if (_scoreBoard.transform.GetChild(i).GetComponent<Text>() != null) {
                    _scoreBoard.transform.GetChild(i).GetComponent<Text>().text = highScore[j].ToString();
                    
                    if(j==0) _scoreBoard.transform.GetChild(i).GetComponent<Text>().color = Color.red;
                    else if(j==1) _scoreBoard.transform.GetChild(i).GetComponent<Text>().color = Color.yellow;
                    else if(j==2) _scoreBoard.transform.GetChild(i).GetComponent<Text>().color = Color.magenta;
                    
                    j++;
                }
            }
        }

        public void showScoreBoard() {
            _scoreBoard.SetActive(true);
        }

        public void deleteScoreBoard() {
            _scoreBoard.SetActive(false);
        }
        
        // Update is called once per frame
        void Update() { }
    }
}
