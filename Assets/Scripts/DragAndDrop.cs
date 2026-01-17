using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    [SerializeField] private Color _dragColor = Color.red;
    private Vector2 _slotPosition;
    private Color _color;
    private RectTransform _rectTransform;
    private Image _image;

    public Vector2 SlotPodition => _slotPosition;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        _color = _image.color;
        _slotPosition = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        _image.color = _dragColor;
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData) {
        _image.color = _color;
        _image.raycastTarget = true;
    }
}
