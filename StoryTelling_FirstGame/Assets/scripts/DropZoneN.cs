using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            RectTransform droppedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            droppedRectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}