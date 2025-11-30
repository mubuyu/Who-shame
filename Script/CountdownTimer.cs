using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownDuration = 60f;
    private float remainingTime;
    private bool isRunning = false;

    public void StartCountdown()
    {
        remainingTime = countdownDuration;
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime < 0f)
            remainingTime = 0f;

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 0f)
        {
            isRunning = false;
            OnCountdownFinished();
        }
    }

    // 🔥【新增】通用减少时间方法（不会导致报错）
    public void ReduceTime(float amount)
    {
        remainingTime -= amount;
        if (remainingTime < 0f)
            remainingTime = 0f;
    }
    public void AddTime(float seconds)
    {
        remainingTime += seconds;
        if (remainingTime > countdownDuration)
        {
            remainingTime = countdownDuration; // 可选限制：不超过初始设定
        }
    }

    // 🔥 计时结束触发事件（你可以在这里拓展）
    private void OnCountdownFinished()
    {
        Debug.Log("倒计时结束，触发事件！");
        SceneManager.LoadScene("Bad end");
    }
}
