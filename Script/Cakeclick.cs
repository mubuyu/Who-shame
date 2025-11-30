using UnityEngine;

public class CakeClick : MonoBehaviour
{
    public GameObject popupTextPrefab;
    public Canvas popupCanvas;

    void OnMouseDown()
    {
        GameObject popup = Instantiate(popupTextPrefab, popupCanvas.transform);
        popup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Don't want to eat";
    
    }
}
