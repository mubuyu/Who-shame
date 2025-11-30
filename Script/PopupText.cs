using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float floatSpeed = 20f;
    public float fadeDuration = 2f;

    private float timer;

    void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        timer = fadeDuration;
    }

    void Update()
    {
        // 文字往上移动
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

        // 文字渐变消失
        timer -= Time.deltaTime;
        if (textMeshPro != null)
        {
            Color color = textMeshPro.color;
            color.a = Mathf.Clamp01(timer / fadeDuration);
            textMeshPro.color = color;
        }

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
