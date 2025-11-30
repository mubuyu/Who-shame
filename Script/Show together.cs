using UnityEngine;

public class ShowTogether : MonoBehaviour
{
    public GameObject hat;           // 拖入 Hat 组件
    public GameObject otherObject;   // 拖入你想一起出现的组件

    private bool hasAppeared = false;

    void Update()
    {
        // 如果 hat 出现，并且只触发一次
        if (!hasAppeared && hat.activeSelf)
        {
            otherObject.SetActive(true);
            hasAppeared = true;
        }
    }
}
