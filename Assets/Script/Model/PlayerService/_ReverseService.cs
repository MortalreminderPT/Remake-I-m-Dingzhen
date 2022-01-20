using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Script.Model {
    public class ReverseService : MonoBehaviour {
        // Start is called before the first frame update
        private GameObject _player;
        private GameObject _mainCamera;
        
        private int _playerAngle = 0;
        private int _cameraAngle = 0;
        
        private float _g = -0.2f;

        private Rigidbody _playerRigidbody;

        private double[][] direct = {
            new double[]{0, 1}, 
            new double[]{ -Math.Sqrt(3)/2, 0.5 }, 
            new double[]{ -Math.Sqrt(3)/2, -0.5 },
            new double[]{0, -1}, 
            new double[]{ Math.Sqrt(3)/2, -0.5 }, 
            new double[]{ Math.Sqrt(3)/2, 0.5 }
        };

        private float[][] target = { new float[]{0,-3,0}, 
            new float[]{2.6183f,-1.4649f,0}, 
            new float[]{2.5734f, 1.5426f, 0},
            new float[]{0,3,0}, 
            new float[]{-2.5778f,1.5350f,0}, 
            new float[]{-2.6227f, -1.4573f, 0} };
        
        private int state = 0;

        void Start() {
            _player = GetComponent<Service>().player;
            _mainCamera = GetComponent<Service>().mainCamera;
            _playerRigidbody = _player.GetComponent<Rigidbody>(); 
            _playerRigidbody.velocity = new Vector3(0, 0, 0);
        }

        public void ReversePlayer() {
            _playerAngle += 15;
            _cameraAngle += 15;
            state = (state + 3) % 6;
            _player.transform.Rotate(0, 180, 0);
        }

        public void SwitchTrack(bool right) {
            if (right) {
                _cameraAngle += 5;
                state = (++state) % 6;
                _player.transform.Rotate(0, 0, 60);
                _player.transform.position = new Vector3(target[state][0], target[state][1], _player.transform.position.z);
            }
            else {
                _cameraAngle -= 5;
                state = --state < 0 ? 5 : state;
                _player.transform.Rotate(0, 0, -60);
                _player.transform.position = new Vector3(target[state][0], target[state][1], _player.transform.position.z);
            }
        }
        // Update is called once per frame
        void FixedUpdate() {
            // 旋转玩家
            if (_playerAngle > 0) {
                _player.transform.Rotate(12, 0, 0);
                _playerAngle--;
            }else if (_playerAngle < 0) {
                _player.transform.Rotate(-12, 0, 0);
                _playerAngle++;
            }
            // 旋转相机
            if (_cameraAngle > 0) {
                _mainCamera.transform.Rotate(0, 0, 12);
                _cameraAngle--;
            }
            else if (_cameraAngle < 0) {
                _mainCamera.transform.Rotate(0, 0, -12);
                _cameraAngle++;
            }
            // 改变重力加速度
            var val = _playerRigidbody.velocity;
            _playerRigidbody.velocity = new Vector3((float)(val.x + direct[state][0] * _g), (float)(val.y + direct[state][1] * _g), val.z);
        }
    }
}
