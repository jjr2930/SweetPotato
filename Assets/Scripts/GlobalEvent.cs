using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEvent 
{
    public static Action onOrderFinished;
    public static Action onGameStarted;
    public static Action onTimeOuted;
    public static Action<EvaluateResult> onSweetPotateEvalueated;
    public static Action<int> onScoreChanged;
}
