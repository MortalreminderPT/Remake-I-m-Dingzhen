using System;
using System.Collections;
using UnityEngine;

namespace Script.Model {
    public class ReverseMapService : MonoBehaviour {
        public GameObject gameMap;
        private GameObject _player;
        private GameObject _skyBoxCamera;
        private int _mapAngle;
        private int _playerAngle = 0;
        private int _playerVelocityY = 0;
        private int _times;
        private int _canJump = 1;
        
        // Start is called before the first frame update
        void Start() {
            _player = GetComponent<Service>().player;
            gameMap = GetComponent<Service>().gameMap;
            _skyBoxCamera = GetComponent<Service>().skyBoxCamera;
        }

        public void ReverseCommand(int Angle) {
            
            // 改变状态为跳跃
            
            switch (Angle) {
                case 60: SwitchTrack(true);
                    break;
                case -60: SwitchTrack(false);
                    break;
                case 180: ReversePlayer();
                    break;
                default:
                    Debug.Log("非法角度");
                    break;
            }
        }
        
        private void ReversePlayer() {
            if (_canJump > 0) {
                _canJump--;
                _player.GetComponent<Rigidbody>().velocity = new Vector3(0, 7, 0);
                Invoke("_ReverseMap", 0.5f);
                _playerAngle += 30;
            }
        }

        public bool GetCanJump() {
            return _canJump>0;
        }
        
        public void canJump() {
            _canJump = GetComponent<Service>().jumpTimes;
        }
        
        private void _ReverseMap() {
            _mapAngle += 30;
        }

        private void SwitchTrack(bool right) {
            //_player.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            if (right) {
                _mapAngle -= 10;
            }
            else {
                _mapAngle += 10;
            }
        }
        
        // Update is called once per frame
        void FixedUpdate() {
            var times = GetComponent<Service>().reverseMultiple;
            //剩余角度比times小的话直接清除
            if (_playerAngle > 0) {
                var mul = Math.Min(times, _playerAngle);
                _player.transform.Rotate(12*mul, 0, 0);
                _playerAngle-=mul;
            }
            if (_mapAngle > 0) {
                var mul = Math.Min(times, _mapAngle);
                gameMap.transform.Rotate(0, 0, 6*mul);
                _skyBoxCamera.transform.Rotate(0, 0, -6*mul);
                _mapAngle-=mul;
            }
            
            else if (_mapAngle < 0) {
                var mul = Math.Min(times, -_mapAngle);
                gameMap.transform.Rotate(0, 0, -6*mul);
                _skyBoxCamera.transform.Rotate(0, 0, 6*mul);
                _mapAngle+=mul;
            }
            //_times = times;
        }
    }
}
