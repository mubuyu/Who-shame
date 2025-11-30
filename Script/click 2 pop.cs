using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour
{
    public GameObject popupPrefab;
    public GameObject textPrefab;
    public Transform canvasTransform;

    public enum ActionType
    {
        ReduceTime,
        AddTime,
        ShowUIText,
        LoadNextScene,
        ShowObject,
        HideObject
    }

    public ActionType[] actions;
    public GameObject showTargetObject;
    public GameObject hideTargetObject;
    public string popupMessage = "Do you want to continue?";
    public string newUIText = "Success!";
    public string winSceneName = "WinScene";

    private void OnMouseDown()
    {
        var popup = Instantiate(popupPrefab, canvasTransform);
        var popupDialog = popup.GetComponent<PopupDialog>();
        popupDialog.Show(popupMessage, OnConfirm, OnCancel);
    }

    void OnConfirm()
    {
        foreach (var action in actions)
        {
            switch (action)
            {
                case ActionType.ReduceTime:
                    FindObjectOfType<CountdownTimer>()?.ReduceTime(5);
                    break;
                case ActionType.AddTime:
                    FindObjectOfType<CountdownTimer>()?.AddTime(5);
                    break;
                case ActionType.ShowUIText:
                    if (textPrefab != null && canvasTransform != null)
                    {
                        GameObject popupText = Instantiate(textPrefab, canvasTransform);
                        TMPro.TextMeshProUGUI tmp = popupText.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                        if (tmp != null)
                            tmp.text = newUIText;
                    }
                    break;
                case ActionType.LoadNextScene:
                    StartCoroutine(LoadSceneAfterDelay(3f)); // ✅ 延迟3秒后加载场景
                    break;
                case ActionType.ShowObject:
                    if (showTargetObject != null)
                        showTargetObject.SetActive(true);
                    break;
                case ActionType.HideObject:
                    if (hideTargetObject != null)
                        hideTargetObject.SetActive(false);
                    break;
            }
        }
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ✅ 延迟等待
        SceneManager.LoadScene(winSceneName);   // ✅ 加载新场景
    }

    void OnCancel()
    {
        Debug.Log("Cancelled.");
    }
}
