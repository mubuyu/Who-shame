using System.Collections;
using UnityEngine;

public class GoodEndingSequence : MonoBehaviour
{
    public GameObject[] scenes; // 拖入四个CG GameObject
    public float displayTime = 4f;

    private void Start()
    {
        StartCoroutine(PlaySceneSequence());
    }

    IEnumerator PlaySceneSequence()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            // 显示当前CG
            scenes[i].SetActive(true);

            // 隐藏前一个CG（如果不是第一个）
            if (i > 0)
                scenes[i - 1].SetActive(false);

            // 等待一段时间
            yield return new WaitForSeconds(displayTime);
        }

        // 如果你希望最后一个CG也消失，可以添加这一句：
        // scenes[scenes.Length - 1].SetActive(false);
    }
}
