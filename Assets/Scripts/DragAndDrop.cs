using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    [SerializeField] private Color _dragColor = Color.red;
    private Vector2 _slotPosition;
    private Color _color;
    private RectTransform _rectTransform;
    private Image _image;


    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _color = _image.color;
        _slotPosition = _rectTransform.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        _image.color = _dragColor;
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        _rectTransform.transform.position += new Vector3(eventData.delta.x, eventData.delta.y, _rectTransform.transform.position.z);
    }
    public void ReturnToSlot() {
        _rectTransform.transform.position = _slotPosition;
    }
    public void ChangeSlot(Vector2 position) {
        _slotPosition = position;
    }
    public void OnEndDrag(PointerEventData eventData) {
        _image.color = _color;
        _image.raycastTarget = true;
    }

    public virtual bool InTaskSlot(int requairedStrength) {
        return false;
    }
}
