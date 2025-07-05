using UnityEngine;
using UnityEngine.UI; // For standard UI
// using TMPro; // If you're using TextMeshPro
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Text timerText;

    public static float elapsedTime = 120f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime -= Time.deltaTime;
            UpdateTimerUI();
            if (elapsedTime <= 0)
            {
                SceneManager.LoadSceneAsync("GameOver");
            }
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
