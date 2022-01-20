using UnityEngine;

namespace Script.Components {
    public abstract class BaseBlock : MonoBehaviour {
        // Start is called before the first frame update
        public int loopTime = -1;
        public Vector3 rotationSpeeed = new Vector3(0,0,0);
        public int trapDamage = 0;
        private int _time = 0;
        void Start() {
            _time = loopTime;
        }

        // Update is called once per frame
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

        public virtual void CollisionEvent(Collision other) { }
        
        public virtual void LoopEvent() { }
        
        void OnCollisionEnter(Collision other) {
            if (other.gameObject.CompareTag("Player"))
                CollisionEvent(other);
        }
    }
}
