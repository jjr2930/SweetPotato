using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField]
    Image mask = null;

    [SerializeField]
    Text timerText = null;

    /// <summary>
    /// seconds....
    /// </summary>
    [SerializeField]
    float time;

    [SerializeField]
    float elapsedTime;
    Coroutine startTimerCoroutine = null;
    public void SetTimerTime(float seconds)
    {
        time = seconds;
    }

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        if (null != startTimerCoroutine)
            StopCoroutine(startTimerCoroutine);

        startTimerCoroutine = StartCoroutine(StartTimeCoroutine());
    }

    IEnumerator StartTimeCoroutine()
    {
        elapsedTime = 0.0f;
        while(elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            mask.fillAmount = elapsedTime / time;
            float remainTime = time - elapsedTime;
            timerText.text = ((int)(remainTime+1)).ToString();
            yield return null;
        }

        GlobalEvent.onTimeOuted?.Invoke();
    }
}
