using Script.State;
using UnityEngine;

namespace Script.Components.Item {
    public class CigaretteScript : BaseItem {
        // Start is called before the first frame update
        public int Duration = 600;
        public override void TriggerEvent(GameObject other) {
            Debug.Log("添加状态");
            var state = other.AddComponent<MagnetState>();
            state.duration = Duration;
            state.frequency = 1;
            state.icon = icon;
            print(icon.name);
            state.mType = StateType.Quantum;
            state.excludes = new StateType[] {StateType.Magnet};
        }
    }
}