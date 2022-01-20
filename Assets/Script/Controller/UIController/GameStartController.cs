using System;
using System.Collections.Generic;
using System.Linq;
using Script.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Controller {
    public class GameStartController : MonoBehaviour {
        // Start is called before the first frame update
        private GameManageService _gameManageService;
        public AudioSource MainBgm;
        //private int[] highScore;
        public GameObject SkyBoxCamera;

        public GameObject RankBoard;
        public GameObject RankBoardList;

        public GameObject ShopBoard;
        public GameObject ShopBoardList;

        //public GameObject YesButton;
        public GameObject NoButton;

        private GameObject _board;

        public GameObject horse;
        public GameObject eyepiece;
        public GameObject cigarette;

        public GameObject Coins;
        private GameObject _coins;
        
        void Start() {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            
            _gameManageService = GameManageService.getInstance();
            horse = GameObject.Find("Horse");
            eyepiece = GameObject.Find("Eyepiece");
            //highScore = _gameManageService.GetHighScore();
            //PlayerPrefs.SetInt("shops2",0);
            //PlayerPrefs.SetInt("shops0",0);
            //RankBoard = GameObject.Find("Rank");
            //PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("Coins", 999999);
        }

        // Update is called once per frame
        void FixedUpdate() {
            SkyBoxCamera.transform.Rotate(0,0.02f,0);
            cigarette.SetActive(PlayerPrefs.GetInt("shops0",0)==1);
            eyepiece.SetActive(PlayerPrefs.GetInt("shops1",0)==1);
            horse.SetActive(PlayerPrefs.GetInt("shops2",0)==1);
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                if(_board) return;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var isCollider = Physics.Raycast(ray);
                if(isCollider)
                    _gameManageService.StartGame();
            }
        }

        public void DisplayRankBoard() {
            //YesButton.SetActive(true);
            NoButton.SetActive(true);
            int[] highScore = _gameManageService.GetHighScore();
            _board = Instantiate(RankBoard, GameObject.Find("UI").transform);
            _board.transform.localPosition = new Vector3(0,0,0);
            var content = GameObject.Find("Content");
            
            for (int i = 0; i < highScore.Length; i++) {
                var scoreList = Instantiate(RankBoardList, content.transform);
                scoreList.transform.localPosition = new Vector3(0, -250 * i, 0);
                scoreList.transform.GetComponentInChildren<Text>().text = "第" + (i + 1) + "名";
                scoreList.transform.GetChild(1).GetComponent<Text>().text = highScore[i].ToString();
            }
            DisplayChooseButton();
        }

        public void HideBoard() {
            //YesButton.SetActive(false);
            NoButton.SetActive(false);
            try {
                Destroy(_board.gameObject);
            }
            catch {
                // ignored
            }
            try { 
                Destroy(_coins.gameObject);}
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public void DisplayShopBoard() {
            _board = Instantiate(ShopBoard, GameObject.Find("UI").transform);
            _coins = Instantiate(Coins, GameObject.Find("UI").transform);
            _coins.GetComponent<CoinsScript>().SetDetails(PlayerPrefs.GetInt("Coins", 0).ToString());
            //MainBgm.Play(GetComponent<ShopsManagerService>().ShopBgm);
            MainBgm.clip = GetComponent<ShopsManagerService>().ShopBgm;
            MainBgm.Play();
            _board.transform.localPosition = new Vector3(0,0,0);
            var content = GameObject.Find("Content");
            this.GetComponent<ShopsManagerService>().newShopListScript(content,"","");
            for (int i = 0; i < 3; i++) {
                //scoreList.transform.GetComponentInChildren<Text>().text = "第" + (i + 1) + "名";
            }
            DisplayChooseButton();
        }

        public void DisplayChooseButton() {
            //YesButton.SetActive(true);
            NoButton.SetActive(true);
            //YesButton.transform.SetAsLastSibling();
            NoButton.transform.SetAsLastSibling();
        }

        public void OnClick(String id) {
            /*  商店购买，需要重构
                    传入的是存储在ButtonClickHandler中的按钮唯一UI id
                    该函数对应按钮id和真实商品id，进行购买操作
                */
            if (id.Substring(0, 5).Equals("shops")) {
                print(id[5]-'0');
                var bought = GetComponent<ShopsManagerService>().Buy(id[5]-'0');
                if (bought) {
                    
                }
            }
            _coins.GetComponent<CoinsScript>().SetDetails(PlayerPrefs.GetInt("Coins", 0).ToString());
        }
    }
}
