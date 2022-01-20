using Script.State;
using UnityEngine;

namespace Script.Components.Item {
    public class EyepieceScript : BaseItem {
        // Start is called before the first frame update
        public int Duration = 600;

        public override void TriggerEvent(GameObject other) {
            Debug.Log("添加状态");
            var state = other.AddComponent<QuantumState>();
            state.duration = Duration;
            state.icon = icon;
            state.frequency = 1;
            state.mType = StateType.Magnet;
            state.excludes = new StateType[] {StateType.Magnet};
        }
    }
}
