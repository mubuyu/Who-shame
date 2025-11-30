using System.Collections;
using UnityEngine;

public class CharacterEntrance : MonoBehaviour
{
    public Transform targetPosition;  // 目标位置（房间中间）
    public float moveSpeed = 2f;      // 移动速度
    public GameObject doorOpen;       // 门开启图
    public GameObject doorClose;      // 门关闭图
    public GameObject[] smiles;       // 所有 smile 表情物体
    public GameObject timerText;      // 倒计时文本
    public GameObjectiveHint objectiveHint;
    public GameObject playerSmile;  // 主角笑容组件

    void Start()
    {
        StartCoroutine(EnterScene());
    }

    IEnumerator EnterScene()
    {
        // 移动主角
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // 等0.5秒再执行后续事件
        yield return new WaitForSeconds(0.5f);

        if (playerSmile != null) playerSmile.SetActive(false);

        // 关门：隐藏门开启图，显示关闭图
        if (doorOpen != null) doorOpen.SetActive(false);
        if (doorClose != null) doorClose.SetActive(true);

        // 笑容消失
        foreach (var smile in smiles)
        {
            if (smile != null) smile.SetActive(false);
        }

        // 启动倒计时
        if (timerText != null) timerText.SetActive(true);
        timerText.GetComponent<CountdownTimer>().StartCountdown();

        // 触发任务提示
        if (objectiveHint != null) objectiveHint.ShowHints();
    }
}
