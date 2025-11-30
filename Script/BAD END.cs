using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    public float delay = 5f;           // 延迟 5 秒再开始出现
    public float fadeDuration = 2f;    // 渐变用时 2 秒

    private Image image;
    private float timer = 0f;
    private bool startFade = false;

    void Start()
    {
        image = GetComponent<Image>();
        var color = image.color;
        color.a = 0f;
        image.color = color; // 初始设为透明
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!startFade && timer >= delay)
        {
            startFade = true;
            timer = 0f;
        }

        if (startFade && timer <= fadeDuration)
        {
            float alpha = timer / fadeDuration;
            var color = image.color;
            color.a = Mathf.Clamp01(alpha);
            image.color = color;
        }
    }
}
