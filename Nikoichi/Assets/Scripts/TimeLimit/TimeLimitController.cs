using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimitController : MonoBehaviour
{
    [SerializeField] private float timeLimit = 200.0f; // 制限時間（秒）
    public Text timeText; // UIに表示するテキスト
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time: " + Mathf.Max(0, timeLimit - Time.timeSinceLevelLoad).ToString("F2") + "s";
        if (Time.timeSinceLevelLoad >= timeLimit)
        {
            //SceneManager.LoadSceneAsync("GameOverScene");
        }
    }
}
