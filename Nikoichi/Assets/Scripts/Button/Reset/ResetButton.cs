using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject otherPart;
    private Rigidbody2D otherPartRb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            otherPartRb = otherPart.GetComponent<Rigidbody2D>();
            // Rigidbody2Dの速度をリセット
            otherPartRb.velocity = Vector2.zero;
            otherPart.transform.position = new Vector2(5, -2);
        }
    }
}
