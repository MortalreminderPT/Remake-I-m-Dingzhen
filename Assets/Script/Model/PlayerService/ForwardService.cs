using System;
using UnityEngine;

namespace Script.Model.PlayerService {
    public class ForwardService : MonoBehaviour {
        // public 
        // Start is called before the first frame update
        private float _speed = 10;
        private float _speedAdd = 0;
        private GameObject _player;
        private bool _isRunning = false;
        void Start() {
            _player = GetComponent<Service>().player;
            _isRunning = GetComponent<Service>().autoForward;
        }

        public void Forward() {
            _isRunning = !_isRunning;
        }

        public float GetRunningSpeed( ) {
            return _speed+_speedAdd;
            //Debug.Log(speed);
        }
        
        public float GetOriginalRunningSpeed( ) {
            return _speed;
            //Debug.Log(speed);
        }

        public void AddSpeed(float add) {
            Debug.Log("加速");
            _speedAdd = _speedAdd + add;
        }
        
        // Update is called once per frame
        void FixedUpdate() {
            float z = _player.transform.position.z;
            _speed = (float)(10*Math.Tanh(0.001*z)+10);
            //Debug.Log("目前速度"+_speed);
            Vector3 val = _player.GetComponent<Rigidbody>().velocity;
            _player.GetComponent<Rigidbody>().velocity = new Vector3(0, val.y, _isRunning ? _speed+_speedAdd : 0);
        }
    }
}
