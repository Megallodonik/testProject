using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpSlot : DragAndDropSlot
{
    public Action<Card> TaskStarted;
    [SerializeField] private TMPro.TextMeshProUGUI _titleText;
    [SerializeField] private TMPro.TextMeshProUGUI _strengthText;
    [SerializeField] private TMPro.TextMeshProUGUI _heroText;
    [SerializeField] private TMPro.TextMeshProUGUI _winText;
    [SerializeField] private TMPro.TextMeshProUGUI _buttonText;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _slotObj;
    private TaskPopUp _taskPopUp;
    private string _title;
    private int _requairedStrength;

    public override void InitSlot() {
        _slot = _slotObj.transform;
    }
    public void Init(HeroTask task, TaskPopUp taskPopUp) {
        if (_titleText == null) {
            Debug.LogError($"Title Text of {this.gameObject} is not attached!");
            return;
        }
        if (_strengthText == null) {
            Debug.LogError($"Strength Text of {this.gameObject} is not attached!");
            return;
        }
        if (_heroText == null) {
            Debug.LogError($"Hero Text of {this.gameObject} is not attached!");
            return;
        }
        if (_winText == null) {
            Debug.LogError($"Win Text of {this.gameObject} is not attached!");
            return;
        }
        if (_buttonText == null) {
            Debug.LogError($"Button Text of {this.gameObject} is not attached!");
            return;
        }
        _taskPopUp = taskPopUp;
        InitSlot();
        _title = task.Name;
        _requairedStrength = task.RequairedStrength;

        _titleText.text = $"Task: {_title}";
        _strengthText.text = $"S: {_requairedStrength.ToString()}";
        _buttonText.text = "Close";
    }

    public override void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Card>() != null) {
            Card card = eventData.pointerDrag.GetComponent<Card>();
            if (_card == null) {
                card.ChangeSlot(this);
                card.ReturnToSlot();
                _heroText.text = $"HS: {card.Hero.Strength}";
                TaskStarted?.Invoke(card);
                _card = card;
            }
            else {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ReturnToSlot();
            }

        }
    }

    public void EndTask(Card card) {
        
        if (card.CheckStrength(_requairedStrength)) {
            _winText.text = "Победа";
            card.Win();
        }
        else {
            _winText.text = "Поражение";
            card.Defeat();
        }
        _buttonText.text = "Далее";
    }

}
