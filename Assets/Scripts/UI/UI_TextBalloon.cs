using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_TextBalloon : MonoBehaviour
{
    [SerializeField]
    Text text = null;

    private void Awake()
    {
        gameObject.SetActive(false);

        GlobalEvent.onTimeOuted += OnTimeOuted;
    }

    private void OnDestroy()
    {
        GlobalEvent.onTimeOuted -= OnTimeOuted;
    }

    private void OnTimeOuted()
    {
        text.text = "Time out!!!";
        gameObject.SetActive(true);
    }
}
