using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHoleInYoloBro : BlackHole
{
    private GameObject wormHoleOut;

    void Start()
    {
        if (wormHoleOut == null)
        {
            wormHoleOut = GameObject.FindWithTag("WormHoleOut");

            if (wormHoleOut == null)
            {
                Debug.LogWarning("No GameObject with tag 'WormHoleOut' found in scene.");
            }
        }
    }

    protected override void OnContact(GameObject obj)
    {
        if (wormHoleOut != null)
        {
            Debug.Log("Object entered wormhole: " + obj.name);
            obj.transform.position = obj.transform.position = new Vector3(
            wormHoleOut.transform.position.x,
            wormHoleOut.transform.position.y,
                0); // force z = 0

        }
        else
        {
            Debug.LogWarning("WormHoleOut not set or not found. Cannot teleport object.");
        }
    }
}
