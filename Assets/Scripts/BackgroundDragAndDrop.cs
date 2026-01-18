using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundDragAndDrop : DragAndDropSlot
{
    public override void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null || eventData.pointerDrag.GetComponent<DragAndDrop>() != null) {
            eventData.pointerDrag.GetComponent<DragAndDrop>().ReturnToSlot();
        }
    }
}
