using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropSlot : MonoBehaviour, IDropHandler {
    protected DragAndDrop _card;
    protected Transform _slot;
    public DragAndDrop Card => _card;
    public Transform Slot => _slot;

    private void Awake() {}
    public virtual void InitSlot() {
        _slot = this.transform;
    }
    public virtual void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<DragAndDrop>() != null) {
            if(_card == null && _card != eventData.pointerDrag.GetComponent<DragAndDrop>()) {
                _card = eventData.pointerDrag.GetComponent<DragAndDrop>();
                _card.ChangeSlot(this);
                _card.ReturnToSlot();
            }
            else {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ReturnToSlot();
            }

        }
    }

    public void ChangeCard(DragAndDrop card) {
        _card = card;
    }

}
