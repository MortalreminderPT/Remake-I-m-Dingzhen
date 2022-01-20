using UnityEngine;

namespace Script.Components.Laser {
    public class LaserScript : BaseBlock {
        private bool laserActive = true;
        // Start is called before the first frame update
        public override void CollisionEvent(Collision other) {
            print("Hello Laser");
        }
        
        public override void LoopEvent() {
            transform.GetChild(1).gameObject.SetActive(laserActive = !laserActive);
            //Invoke("closeLaser", 0.5f);
        }

        
        /*private void closeLaser() {
            transform.GetChild(1).gameObject.SetActive(false);
        }*/
    }
}
