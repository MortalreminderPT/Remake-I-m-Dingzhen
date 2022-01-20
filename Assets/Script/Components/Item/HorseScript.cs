using Script.Model;
using Script.State;
using UnityEngine;

namespace Script.Components.Item {
    public class HorseScript : BaseItem
    {
        public int Duration = 600;

        public override void TriggerEvent(GameObject other) {
            SpeedUpState state = other.AddComponent<SpeedUpState>();
            state.duration = Duration;
            state.frequency = 1;
            state.icon = icon;
            state.add = 0.5f*GameObject.Find("Service").GetComponent<Service>().forwardService.GetOriginalRunningSpeed();
            
            state.mType = StateType.SpeedUp;
            //state.excludes = new StateType[] {StateType.Quantum};
        }
    }
}
