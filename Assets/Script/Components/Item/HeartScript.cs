using Script.State;
using UnityEngine;

namespace Script.Components.Item {
    public class HeartScript : BaseItem
    {
        // Start is called before the first frame update\
        public override void TriggerEvent(GameObject other) {
            int coins = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", coins+1);
            print("拥有金币"+coins);
        }
    }
}
