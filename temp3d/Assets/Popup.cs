using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    [SerializeField] private float popUpDuration;

    private void OnEnable()
    {
        gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(100, 100), popUpDuration, true);
        StartCoroutine(GetChild());
    }

    private IEnumerator GetChild()
    {
        yield return new WaitForSeconds(0.8f * popUpDuration);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(0, 0), 0.2f, true);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
