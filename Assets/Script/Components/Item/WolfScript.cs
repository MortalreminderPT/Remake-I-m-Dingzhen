using System.Collections;
using System.Collections.Generic;
using Script.Components.Item;
using Script.State;
using UnityEngine;

public class WolfScript : BaseItem
{
    // Start is called before the first frame update
    public int Duration = 5;

    public override void TriggerEvent(GameObject other) {
        Debug.Log("添加状态");
        var state = other.AddComponent<SmashState>();
        state.duration = Duration;
        state.icon = icon;
        state.mType = StateType.Smash;
        state.excludes = new StateType[] {StateType.Smash};
    }
}
