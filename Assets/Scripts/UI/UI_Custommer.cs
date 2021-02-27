using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum EvaluateResult
{
    Bad,
    Good,
    Perfect,
    Disgusting
}

/// <summary>
/// 구매자 UI
/// TODO : 아... 코멘트 클래스를 만들어야 하나 말아야하나... 일단 코멘트를 클래스로....
/// </summary>
public class UI_Custommer : MonoBehaviour
{
    [SerializeField]
    int count = 0;
    public int Count { get { return count; } }

    [SerializeField]
    GameObject commentRoot = null;

    [SerializeField]
    Text commentText = null;

    [SerializeField]
    float commentVisibleTime = 2f;

    Coroutine showCommentCoroutine = null;
    
    private void Awake()
    {
        count = UnityEngine.Random.Range(1, 10);
    }

    private void Start()
    {
        OnClicked();
    }

    public void OnClicked()
    {
        StartShowCommentCoroutine($"{count} please");
    }

    public void OnDrop(UI_DragAndDropable item)
    {
        if (null == item)
        {
            Debug.Log("item is null");
            return;
        }

        var sweetPotato = item.GetComponent<UI_SweetPotato>();
        --count;
        Destroy(sweetPotato.gameObject);


        if (0.9f <= sweetPotato.BurnQuality)
        {
            GlobalEvent.onSweetPotateEvalueated?.Invoke(EvaluateResult.Perfect);
            StartShowCommentCoroutine("Thanks");
        }
        else
        {
            GlobalEvent.onSweetPotateEvalueated?.Invoke(EvaluateResult.Disgusting);
            StartShowCommentCoroutine("Disgusting");
        }

        if (count <= 0)
        {
            StartShowCommentCoroutine("Bye", () => { Destroy(this.gameObject); });
            GetComponent<UI_DragAndDropReceiver>().enabled = false;
        }
    }

    private void StartShowCommentCoroutine(string comment, Action callback = null)
    {
        if (null != showCommentCoroutine)
            StopCoroutine(showCommentCoroutine);

        StartCoroutine(ShowComment(comment,callback));
    }

    IEnumerator ShowComment(string comment, Action callback)
    {
        commentText.text = comment;
        commentRoot.SetActive(true);
        yield return new WaitForSeconds(commentVisibleTime);
        commentRoot.SetActive(false);

        callback?.Invoke();
    }
}
