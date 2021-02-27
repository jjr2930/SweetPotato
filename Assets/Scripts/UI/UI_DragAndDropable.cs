using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class UI_DragAndDropable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform rectTransfrom = null;

    Transform originParent = null;

    Vector3 originPosition = Vector3.one;

    Quaternion originRotation = Quaternion.identity;

    Vector3 originScale = Vector3.one;

    int originSibling = 0;

    Rect originRect = new Rect();

    Vector3 originAchorMin = Vector3.zero;

    Vector3 originAchorMax = Vector3.zero;

    Vector2 originOffsetMin = Vector3.zero;

    Vector2 originOffsetMax = Vector3.zero;

    CanvasGroup group = null;

    private void Awake()
    {
        rectTransfrom = transform as RectTransform;
        group = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originParent = rectTransfrom.parent;
        originPosition = rectTransfrom.position;
        originRotation = rectTransfrom.rotation;
        originScale = rectTransfrom.localScale;
        originSibling = rectTransfrom.GetSiblingIndex();
        originRect = rectTransfrom.rect;
        originAchorMax = rectTransfrom.anchorMax;
        originAchorMin = rectTransfrom.anchorMin;
        originOffsetMin = rectTransfrom.offsetMin;
        originOffsetMax = rectTransfrom.offsetMax;

        group.blocksRaycasts = false;

        UI_DragAndDropManager.Instance.Item = this;
        rectTransfrom.SetParent(UI_DragAndDropManager.Instance.transform);
        rectTransfrom.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransfrom.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransfrom.sizeDelta = new Vector2(originRect.width, originRect.height);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 outPosition = Vector3.zero;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransfrom, 
                                                                eventData.pointerCurrentRaycast.screenPosition, 
                                                                Camera.main, 
                                                                out outPosition);
        rectTransfrom.position = outPosition;
    }

    public void ToOrigin()
    {
        rectTransfrom.SetParent(originParent);
        rectTransfrom.SetSiblingIndex(originSibling);
        rectTransfrom.localScale = originScale;
        rectTransfrom.anchorMin = originAchorMin;
        rectTransfrom.anchorMax = originAchorMax;
        rectTransfrom.sizeDelta = new Vector2(originRect.width, originRect.height);
        rectTransfrom.SetPositionAndRotation(originPosition, originRotation);
        rectTransfrom.offsetMax = originOffsetMax;
        rectTransfrom.offsetMin = originOffsetMin;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UI_DragAndDropManager.Instance.OnDragEnd();

        group.blocksRaycasts = true;
    }
}
