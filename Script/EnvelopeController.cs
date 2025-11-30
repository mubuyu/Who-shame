using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnvelopeController : MonoBehaviour
{
    [Header("UI 元素")]
    public Button openButton;            // 信封按钮
    public Image envelopeImage;          // 信封图
    public Image invitationImage;        // 邀请函图
    public GameObject textOpen;          // “open”文字
    public GameObject textClickContinue; // “Click to continue” 文字

    bool invitationOpened = false; // 是否已打开邀请函

    void Start()
    {
        // 初始化状态
        envelopeImage.enabled = true;
        invitationImage.enabled = false;

        textOpen.SetActive(true);
        textClickContinue.SetActive(false);

        openButton.onClick.AddListener(OpenInvitation);
    }

    void Update()
    {
        // 如果已经打开邀请函，点击任意位置进入下一幕
        if (invitationOpened && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Ballroom");
        }
    }

    void OpenInvitation()
    {
        // 隐藏信封界面
        envelopeImage.enabled = false;
        openButton.gameObject.SetActive(false);
        textOpen.SetActive(false);

        // 显示邀请函界面
        invitationImage.enabled = true;
        textClickContinue.SetActive(true);

        // 标记已经进入第二阶段
        invitationOpened = true;
    }
}

