using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private GameObject cardFront;
    [SerializeField] private GameObject cardBack;
    void Start()
    {
        cardFront.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(HalfRotate);
        cardBack.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(HalfReverseRotate);
    }

    void HalfRotate()
    {
        iTween.RotateTo(cardFront, iTween.Hash(
                "rotation", new Vector3(0, 90, 0),
                "time", 0.1f,
                "easetype", iTween.EaseType.linear,
                "onComplete", "FullRotate",
                "onCompleteTarget", gameObject
                ));
        iTween.RotateTo(cardBack, iTween.Hash(
            "rotation", new Vector3(0, 270, 0),
            "time", 0.1f,
            "easetype", iTween.EaseType.linear
            ));
    }

    void FullRotate()
    {
        cardFront.transform.SetAsFirstSibling();
        iTween.RotateTo(cardFront, iTween.Hash(
                "rotation", new Vector3(0, 180, 0),
                "time", 0.1f,
                "easetype", iTween.EaseType.linear
                ));
        iTween.RotateTo(cardBack, iTween.Hash(
                "rotation", new Vector3(0, 360, 0),
                "time", 0.1f,
                "easetype", iTween.EaseType.linear
                ));
    }

    void HalfReverseRotate()
    {
        iTween.RotateTo(cardFront, iTween.Hash(
                "rotation", new Vector3(0, 90, 0),
                "time", 0.1f,
                "easetype", iTween.EaseType.linear,
                "onComplete", "FullReverseRotate",
                "onCompleteTarget", gameObject
                ));
        iTween.RotateTo(cardBack, iTween.Hash(
            "rotation", new Vector3(0, 270, 0),
            "time", 0.1f,
            "easetype", iTween.EaseType.linear
            ));
    }

    void FullReverseRotate()
    {
        cardBack.transform.SetAsFirstSibling();
        iTween.RotateTo(cardFront, iTween.Hash(
                "rotation", new Vector3(0, 0, 0),
                "time", 0.1f,
                "easetype", iTween.EaseType.linear
                ));
        iTween.RotateTo(cardBack, iTween.Hash(
                "rotation", new Vector3(0, 180, 0),
                "time", 0.1f,
                "easetype", iTween.EaseType.linear
                ));
    }
}
