using UnityEngine;

namespace Script.State {
    public class SmashState : State
    {
        // Start is called before the first frame update
        public float maxSmashDistance = 160;

        public override void StateEnterHook() {
            var traps = GameObject.FindGameObjectsWithTag("Trap");
            Debug.Log("义眼丁真, 鉴定为假");
            foreach (var trap in traps) {
                if((trap.transform.position-service.player.transform.position).magnitude < maxSmashDistance)
                    Destroy(trap.gameObject);
            }
        }

        public override void StateExitHook() {
        }

        public override void UpdateHook() {
            
        }
    }
}
