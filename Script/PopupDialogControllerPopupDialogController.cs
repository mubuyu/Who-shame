using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupDialog : MonoBehaviour
{
    public TMP_Text dialogText;
    public Button yesButton;
    public Button noButton;

    public void Show(string message, UnityAction onYes, UnityAction onNo)
    {
        dialogText.text = message;
        gameObject.SetActive(true);

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => {
            onYes?.Invoke();
            gameObject.SetActive(false);
        });

        noButton.onClick.AddListener(() => {
            onNo?.Invoke();
            gameObject.SetActive(false);
        });
    }
}
