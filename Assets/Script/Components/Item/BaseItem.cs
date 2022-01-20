using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Components.Item {
    public abstract class BaseItem : MonoBehaviour {
        public int loopTime = -1;
        public Vector3 rotationSpeeed = new Vector3(0,0,0);
        private int _time = 0;
        public Sprite icon;
        public AudioClip SE;
        public bool isCoin = false;
        
        public void Start() {
            _time = loopTime;
        }
        // Start is called before the first frame update
        public virtual void TriggerEvent(GameObject other) {
            
        }

        public virtual void LoopEvent() {
            
        }
        
        void FixedUpdate() {
            transform.Rotate(rotationSpeeed);
            if (loopTime < 0) return;
            if (_time < 0) {
                _time = loopTime;
                LoopEvent();
                return;
            }
            _time--;
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Player")) {
                if (isCoin) {
                    other.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().clip = SE;
                    other.transform.GetChild(1).GetChild(0).GetComponent<AudioSource>().Play();
                }
                else {
                    other.transform.GetChild(1).GetChild(1).GetComponent<AudioSource>().clip = SE;
                    other.transform.GetChild(1).GetChild(1).GetComponent<AudioSource>().Play();
                }
                TriggerEvent(other.gameObject);
                this.gameObject.SetActive(false);
                //Destroy(this);
            }
        }
    }
}
