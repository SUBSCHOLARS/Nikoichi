using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject RedScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RedScreenAudiSourceControll()
    {
        audioSource = RedScreen.GetComponent<AudioSource>();
        audioSource.volume = 0.5f; // 音量を0.5に設定
    }
}
