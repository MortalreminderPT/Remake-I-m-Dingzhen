using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Model.PlayerService {
    public class PlayerStateService : MonoBehaviour {
        private GameManageService _gameManageService;
        private Service _service;
        public List<State.State> states;
        private GameObject _canvas;
        private GameObject scoreText;
        
        private GameObject eyepiece;
        private GameObject cigarette;

        
        // Start is called before the first frame update
        void Start() {
            _gameManageService = GameManageService.getInstance();
            _service = GetComponent<Service>();
            _service.MenuUI.SetActive(false);
            _canvas = _service.canvas;
            scoreText = GameObject.Find("Score");
            
            cigarette = GameObject.Find("Cigarette");
            eyepiece = GameObject.Find("Eyepiece");
            
            cigarette.SetActive(PlayerPrefs.GetInt("shops0",0)==1);
            eyepiece.SetActive(PlayerPrefs.GetInt("shops1",0)==1);
            
        }

        // Update is called once per frame
        void FixedUpdate() {
            scoreText.GetComponent<Text>().text = ((int)_service.player.transform.position.z).ToString();
            //scoreText.GetComponent<Text>().text = Screen.currentResolution.refreshRate.ToString();
            if (GetComponent<Service>().player.transform.position.y < -20 || GetComponent<Service>().player.transform.position.y > 20) {
                GameOver();
            }
        }

        public void GameOver() {
            Time.timeScale = 0;
            //GetComponent<Service>().forwardService.SetRunningSpeed(0);
            _gameManageService.GameOver((int)_service.player.transform.position.z);
            _service.MenuUI.transform.GetChild(4).GetComponent<Text>().text = "游戏失败了\n你的得分为\n"+(int)_service.player.transform.position.z;
            _service.MenuUI.SetActive(true);
            Destroy(this);
        }
    }
}
