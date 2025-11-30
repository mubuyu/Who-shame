using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float blinkSpeed = 1f;

    void Update()
    {
        if (canvasGroup != null)
        {
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * blinkSpeed));
            canvasGroup.alpha = alpha;
        }
    }
}
