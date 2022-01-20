using System;
using UnityEngine;

namespace Script.Model.PlayerService {
    public class PlayerSlideService : MonoBehaviour {
        private bool _isGround = false;
        private GameObject _player;
        private float _playerHeight;
        // Start is called before the first frame update

        private void Start() {
            _player = GetComponent<Service>().player;
            _playerHeight = _player.transform.localScale.y;
        }

        public void OnSlide() {
            GetComponent<Service>().reverseMultiple = 5;
            ToGround();
            //Invoke("ToGround", 0.1f);
        }

        private void ToGround() {
            Vector3 val= _player.GetComponent<Rigidbody>().velocity;
            _player.GetComponent<Rigidbody>().velocity = new Vector3(val.x, val.y-5, val.z);
        }
        
        private void FixedUpdate() {
            // 判断是否在地面
            bool ray = Physics.Raycast(_player.transform.position, Vector3.down, 0.05f+_playerHeight);
            _isGround = ray;
            Debug.DrawLine(_player.transform.position, _player.transform.position-new Vector3(0,0.05f+_playerHeight,0), Color.red);
            if (_isGround) {
                GetComponent<Service>().reverseMultiple = 1;
                GetComponent<Service>().reverseMapService.canJump();
            }
        }

        public bool GetIsGround() {
            return _isGround;
        }
    }
}
