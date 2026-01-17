using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundDragAndDrop : DragAndDropSlot
{
    public override void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            eventData.pointerDrag.GetComponent<DragAndDrop>().SlotPodition;
        }
    }
}
