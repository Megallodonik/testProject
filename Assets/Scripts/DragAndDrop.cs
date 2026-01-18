using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    [SerializeField] private Color _dragColor = Color.red;
    private DragAndDropSlot _slot;
    private DragAndDropSlot _lastSlot;
    private Color _color;
    private RectTransform _rectTransform;
    private Image _image;
    private bool _isDropped;

    public DragAndDropSlot Slot => _slot;
    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _color = _image.color;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        _image.color = _dragColor;
        _image.raycastTarget = false;
        _isDropped = false;
    }

    public void OnDrag(PointerEventData eventData) {
        _rectTransform.transform.position += new Vector3(eventData.delta.x, eventData.delta.y, _rectTransform.transform.position.z);
    }
    public void ReturnToSlot() {
        _rectTransform.transform.position = _slot.Slot.position;
        _isDropped = true;
    }
    public void ReturnToLastSlot() {
        if(_lastSlot.Card == null) {
            ChangeSlot(_lastSlot);
            ReturnToSlot();
        }
    }
    public void ChangeSlot(DragAndDropSlot slot) {
        if (_slot != null) {
            _slot.ChangeCard(null);
        }
        _lastSlot = _slot;
        _slot = slot;
        OnChangeSlot(slot);
    }
    public virtual void OnChangeSlot(DragAndDropSlot slot) { }
    public void OnEndDrag(PointerEventData eventData) {
        _image.color = _color;
        _image.raycastTarget = true;
        if (!_isDropped) {
            ReturnToSlot();
        }
    }


}
