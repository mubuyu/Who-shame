using UnityEngine;

public class ClickToPopup : MonoBehaviour
{
    public string popupMessage = "Default message.";
    public GameObject popupTextPrefab;
    public Canvas popupCanvas;

    void OnMouseDown()
    {
        GameObject popup = Instantiate(popupTextPrefab, popupCanvas.transform);
        popup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = popupMessage;
    }
}

