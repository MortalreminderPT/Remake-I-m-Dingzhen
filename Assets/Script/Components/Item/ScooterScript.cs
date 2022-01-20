using System.Collections;
using System.Collections.Generic;
using Script.Components.Item;
using Script.State;
using UnityEngine;

public class ScooterScript : BaseItem
{
    // Start is called before the first frame update
    public int Duration = 600;

    public override void TriggerEvent(GameObject other) {
        SpeedUpState state = other.AddComponent<SpeedUpState>();
        state.duration = Duration;
        state.mType = StateType.SpeedUp;
        state.frequency = 1;
        state.icon = icon;
        state.add = 5;
        print(icon.name);
        state.excludes = new StateType[]{StateType.SpeedUp};
    }
}
