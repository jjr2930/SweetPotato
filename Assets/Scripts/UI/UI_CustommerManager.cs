using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CustommerManager : MonoBehaviour
{
    [SerializeField]
    UI_Custommer custommerPrefab = null;

    [SerializeField]
    Transform content = null;

    Coroutine creatingCroutine = null;
    private void Awake()
    {
        GlobalEvent.onGameStarted += StartGame;
    }
    private void OnDestroy()
    {
        GlobalEvent.onGameStarted -= StartGame;
    }

    private void StartGame()
    {
        if (null != creatingCroutine)
            StopCoroutine(creatingCroutine);
        
        creatingCroutine = StartCoroutine(GenerateCustommer());
    }

    private IEnumerator GenerateCustommer()
    {
        while (true)
        {
            if (content.childCount < 4)
            {
                Instantiate(custommerPrefab, content);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}