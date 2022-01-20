using Script.State;
using UnityEngine;

namespace Script.State {
    
    [System.Serializable]
    public class MagnetState : State {
        // Start is called before the first frame update
        public float maxMagnetDistance = 30;
        
        public override void StateEnterHook() {
        }

        public override void StateExitHook() {
        }

        public override void UpdateHook() {
            var item = GameObject.FindWithTag("Item");
            if ((item.transform.position - service.player.transform.position).magnitude < maxMagnetDistance) {
                Debug.Log(item.name);
                item.transform.position = Vector3.MoveTowards(item.transform.position, service.player.transform.position, 1f);
            }
        }
    }
}
