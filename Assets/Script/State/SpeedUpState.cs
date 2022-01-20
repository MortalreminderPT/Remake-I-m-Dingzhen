using UnityEngine;

namespace Script.State {
    public class SpeedUpState : State {
        public float add = 5;
        // Start is called before the first frame update
        public override void StateEnterHook() {
            service.forwardService.AddSpeed(add);
        }

        public override void StateExitHook() {
            service.forwardService.AddSpeed(-add);
        }

        public override void UpdateHook() {
            //Debug.Log(service.forwardService.GetRunningSpeed());
        }
    }
}
