using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditor;

public class OpeningSeenCountController : MonoBehaviour
{
    public Flowchart OpeningFlowchart;
    [SerializeField] private static int OpeningSeen = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void IncrementOpeningSeenCounter()
    {
        OpeningSeen++;
    }
}
