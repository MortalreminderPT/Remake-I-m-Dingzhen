using System.Collections;
using System.Collections.Generic;
using Script.Components;
using UnityEngine;

public class Ground : BaseBlock
{
    // Start is called before the first frame update
    public override void CollisionEvent(Collision other) {
        var val = other.rigidbody.velocity;
        other.rigidbody.velocity = new Vector3(val.x, 0, val.z);
    }
}
