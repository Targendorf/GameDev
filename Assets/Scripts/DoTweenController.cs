using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenController : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform Rot1,Rot2,Rot3,Rot4;
    public Button GetLeader;

    void Start()
    {
        Button btn1 = GetLeader.GetComponent<Button>();
        btn1.onClick.AddListener(hide);
    }

    public void hide()
    {
        Rot1.DOAnchorPos(Vector2.zero, 0.25f);
        Rot2.DOAnchorPos(Vector2.zero, 0.25f);
        Rot3.DOAnchorPos(Vector2.zero, 0.25f);
        Rot4.DOAnchorPos(Vector2.zero, 0.25f);
    }
}
