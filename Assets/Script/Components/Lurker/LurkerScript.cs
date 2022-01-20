using UnityEngine;

namespace Script.Components.Lurker {
    public class LurkerScript : BaseBlock
    {
        // 撞上了
        public override void CollisionEvent(Collision other) {
            //print(other);
            //print("Hello Lurker");
        }

        public override void LoopEvent() {
            print("loop");
        }
    }
}
