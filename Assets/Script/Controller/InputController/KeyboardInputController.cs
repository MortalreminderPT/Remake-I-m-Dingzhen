using System;
using Script.Model;
using UnityEngine;

namespace Script.Controller.InputController {
    public class KeyboardInputController : MonoBehaviour {
        //public GameObject player; 
        public String reverse = "w";
        public String forward = "q";
        public String right = "d";
        public String left = "a";
        public String down = "s";
        public String pause = "e";
        public Service service;
        //public GameKey[] gameKeys;
        private GameManageService _gameManageService;

        // Start is called before the first frame update
        void Start() {
            _gameManageService = GameManageService.getInstance();
        }

        // Update is called once per frame
        void Update() {
            if (_gameManageService.GetGameState() != 0)
                return;

            if (Input.GetKeyDown(reverse)) {
                if(!service.reverseMapService.GetCanJump()) return;
                service.reverseMapService.ReverseCommand(180); //ReversePlayer();
                GetComponentInChildren<PlayerAnimController>().PlayJump();
                GetComponentInChildren<PlayerAudioController>().PlayJumpSE();
            }
            if (Input.GetKeyDown(forward))
                service.forwardService.Forward();
            if (Input.GetKeyDown(right)) {
                service.reverseMapService.ReverseCommand(60); //SwitchTrack(true);
                GetComponentInChildren<PlayerAudioController>().PlayMoveSE();
            }
            if (Input.GetKeyDown(left)) {
                service.reverseMapService.ReverseCommand(-60); //SwitchTrack(false);
                GetComponentInChildren<PlayerAudioController>().PlayMoveSE();
            }
            if (Input.GetKeyDown(down)) {
                service.playerSlideService.OnSlide();
                GetComponentInChildren<PlayerAudioController>().PlayDownSE();
            }
            //GetComponentInChildren<PlayerAnimController>().PlayRunning();
            if (Input.GetKeyDown(pause))
                Time.timeScale = 1 - Time.timeScale;
        }
    }
}
