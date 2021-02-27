using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UI_DragAndDropReceiver : MonoBehaviour, IDropHandler
{
    [SerializeField]
    UnityEvent<UI_DragAndDropable> onDropped = null;

    public void CallOnDropped(UI_DragAndDropable item)
    {
        onDropped.Invoke(item);
    }

    public void OnDrop(PointerEventData eventData)
    {
        UI_DragAndDropManager.Instance.Receiver = this;
    }
}

