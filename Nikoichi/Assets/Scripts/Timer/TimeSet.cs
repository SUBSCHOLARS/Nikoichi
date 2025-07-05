using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NotConfidet()
    {
        GameTimer.elapsedTime = 180f;
    }
    public void Confident()
    {
        GameTimer.elapsedTime = 120f;
    }
    public void HighlyConfident()
    {
        GameTimer.elapsedTime = 60f;
    }
}
