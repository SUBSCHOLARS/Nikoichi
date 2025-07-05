using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHoleInYoloBro : BlackHole
{
    public GameObject wormHoleOut;
    protected override void OnContact(GameObject obj)
    {
        // Custom behavior for wormhole
        Debug.Log("Object entered wormhole: " + obj.name);

        // Example: teleport somewhere instead of destroying
        obj.transform.position = new Vector3(wormHoleOut.transform.position.x, wormHoleOut.transform.position.y, 0); // Teleport to some location

        // Optionally: base.OnContact(obj); if you still want default destruction
    }
}
