using UnityEngine;

public class GameObjectiveHint : MonoBehaviour
{
    public GameObject[] npcHints; // “你为什么穿蓝色”等文字
    public GameObject objectiveText; // 屏幕右侧“让自己穿着一样”的提示

    public void ShowHints()
    {
        foreach (GameObject hint in npcHints)
        {
            hint.SetActive(true);
        }

        if (objectiveText != null)
            objectiveText.SetActive(true);
    }
}
