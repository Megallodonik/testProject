using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropSlot : MonoBehaviour, IDropHandler {
    public virtual void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null || eventData.pointerDrag.GetComponent<DragAndDrop>() != null) {
            eventData.pointerDrag.GetComponent<DragAndDrop>().ChangeSlot(this.transform.position);
            eventData.pointerDrag.GetComponent<DragAndDrop>().ReturnToSlot();
        }
    }


}
