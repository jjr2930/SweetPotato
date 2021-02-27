using UnityEngine;

public class UI_DragAndDropManager : UI_MonoSingle<UI_DragAndDropManager>
{
    public UI_DragAndDropable Item { get; set; }
    public UI_DragAndDropReceiver Receiver { get; set; }

    protected override void Awake()
    {
        base.Awake();
        var canvas = FindObjectOfType<Canvas>();
        
        RectTransform rt = transform as RectTransform;

        rt.SetParent(canvas.transform);
        rt.localScale = Vector3.one;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
    }

    public void OnDragEnd()
    {
        if (null == Item)
        {
            Debug.LogWarning("item is null");
            return;
        }

        if(null == Receiver)
        {
            Item.ToOrigin();
        }
        else
        {
            Item.transform.SetParent(Receiver.transform);
            Receiver.CallOnDropped(Item);
        }

        Item = null;
        Receiver = null;
    }
}