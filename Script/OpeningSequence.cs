using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections; // 这一行是必须的！

public class OpeningSequence : MonoBehaviour
{
    public Image envelopeImage;
    public Image invitationImage;
    public float transitionTime = 2f;

    void Start()
    {
        StartCoroutine(PlayOpening());
    }

    IEnumerator PlayOpening()
    {
        yield return new WaitForSeconds(2f);

        envelopeImage.gameObject.SetActive(false);
        invitationImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f); // 展示邀请函

        SceneManager.LoadScene("Ballroom"); // 进入主场景
    }
}
