using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    [SerializeField]
    Text text = null;
    // Start is called before the first frame update
    void Awake()
    {
        GlobalEvent.onScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        GlobalEvent.onScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        text.text = score.ToString("###,###");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
