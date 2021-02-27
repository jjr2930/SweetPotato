using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField]
    int score = 0;
    private void Awake()
    {
        GlobalEvent.onSweetPotateEvalueated+= onSweetPotateEvalueated;
    }

    private void OnDestroy()
    {
        GlobalEvent.onSweetPotateEvalueated -= onSweetPotateEvalueated;
    }


    private void onSweetPotateEvalueated(EvaluateResult result)
    {
        switch (result)
        {
            case EvaluateResult.Perfect:
                score += 100;
                break;

            case EvaluateResult.Good:
                score += 50;
                break;

            case EvaluateResult.Bad:
                score -= 50;
                break;

            case EvaluateResult.Disgusting:
                score -= 100;
                break;

            default:
                break;
        }

        score = (score < 0) ? 0 : score;
        GlobalEvent.onScoreChanged?.Invoke(score);
    }
    
    private IEnumerator Start()
    {
        yield return null;
        yield return null;
        GlobalEvent.onGameStarted?.Invoke();
    }
}