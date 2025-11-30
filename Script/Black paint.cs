using UnityEngine;

public class PaintTriggerManager : MonoBehaviour
{
    public GameObject blackPaintObject;      // 拖入“黑色油漆”组件
    public GameObject[] npcSmileObjects;     // 拖入 5 个 NPC 的笑容组件（之前是 private，现在 public）
    public GameObject[] npcDialogues;        // 拖入 2 个 NPC 的对话框组件
    public GameObject taskText;              // 拖入 Task 文字组件
    public CountdownTimer timer;             // 拖入倒计时脚本组件

    private bool triggered = false;

    void Update()
    {
        // 只触发一次
        if (!triggered && blackPaintObject.activeSelf)
        {
            triggered = true;

            // 停止倒计时
            if (timer != null)
            {
                timer.enabled = false;
            }

            // 隐藏笑容
            foreach (GameObject npc in npcSmileObjects)
            {
                if (npc != null) npc.SetActive(true);
            }

            // 隐藏对话框
            foreach (GameObject dialogue in npcDialogues)
            {
                if (dialogue != null) dialogue.SetActive(false);
            }

            // 隐藏任务文字
            if (taskText != null)
            {
                taskText.SetActive(false);
            }

            Debug.Log("黑色油漆已触发，倒计时停止，NPC笑容和对话框隐藏，任务文字消失");
        }
    }
}
