using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject backToStartButton;
    public float delayBeforeButtons = 6f;

    void Start()
    {
        // 初始隐藏按钮
        if (exitButton != null) exitButton.SetActive(false);
        if (backToStartButton != null) backToStartButton.SetActive(false);

        // 一段时间后显示按钮
        Invoke("ShowButtons", delayBeforeButtons);
    }

    void ShowButtons()
    {
        if (exitButton != null) exitButton.SetActive(true);
        if (backToStartButton != null) backToStartButton.SetActive(true);
    }

    // 挂在按钮上的点击方法
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Open"); // 改成你的起始场景名
    }
}
