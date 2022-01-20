using Script.Components;
using UnityEngine;

namespace Script.Model.PlayerService {
    public class PlayerCollisionService : MonoBehaviour {
        // Start is called before the first frame update
        public void TrapCollision(GameObject other) {
            other.GetComponent<BaseBlock>().trapDamage = 1;
            print("踩到了"+other.name+"陷阱");
        }
    }
}
