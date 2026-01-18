using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpSlot : DragAndDropSlot
{
    [SerializeField] private TMPro.TextMeshProUGUI _titleText;
    [SerializeField] private TMPro.TextMeshProUGUI _strengthText;
    private string _title;
    private int _requairedStrength;
    public void Init(HeroTask task) {
        _title = task.Name;
        _requairedStrength = task.RequairedStrength;

        if (_titleText == null) {
            Debug.LogError($"Title Text of {this.gameObject} is not attached!");
            return;
        }
        _titleText.text = _title;
        if (_strengthText == null) {
            Debug.LogError($"Strength Text of {this.gameObject} is not attached!");
            return;
        }
        _strengthText.text = _requairedStrength.ToString();
    }

    public override void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null || eventData.pointerDrag.GetComponent<Card>() != null) {
            Card card = eventData.pointerDrag.GetComponent<Card>();
            card.ChangeSlot(this.transform.position);
            card.ReturnToSlot();

            if (card.CheckStrength(_requairedStrength)) {
                card.Manager.DeleteCard(card);
                _titleText.text = "Победа";
            }
            else {
                _titleText.text = "Поражение";
            }

        }
    }
}
