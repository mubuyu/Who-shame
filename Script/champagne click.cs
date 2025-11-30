using UnityEngine;

public class ChampagneClick : MonoBehaviour
{
    public GameObject popupTextPrefab;
    public Canvas popupCanvas;

    void OnMouseDown()
    {
        GameObject popup = Instantiate(popupTextPrefab, popupCanvas.transform);
        popup.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Feels like it'll topple if I touch it. Better leave it alone.";
    }
}
