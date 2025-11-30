using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera sideCamera;

    public GameObject btnToSide;
    public GameObject btnToMain;

    void Start()
    {
        // 初始激活主视角
        mainCamera.enabled = true;
        sideCamera.enabled = false;

        btnToSide.SetActive(true);
        btnToMain.SetActive(false);
    }

    public void SwitchToSide()
    {
        mainCamera.enabled = false;
        sideCamera.enabled = true;

        btnToSide.SetActive(false);
        btnToMain.SetActive(true);
    }

    public void SwitchToMain()
    {
        mainCamera.enabled = true;
        sideCamera.enabled = false;

        btnToSide.SetActive(true);
        btnToMain.SetActive(false);
    }
}
