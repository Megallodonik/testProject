using UnityEngine;
using UnityEngine.UI;

public class Card : DragAndDrop
{
    [SerializeField] private GameObject _deBuff;
    [SerializeField] private TMPro.TextMeshProUGUI _strengthText;
    [SerializeField] private Image _progressImage;
    [SerializeField] private Image _taskProgressImage;
    private float _taskProgress;
    private float _fullTaskProgress;
    private float _progress = 0;
    private float _fullProgress;
    private DragAndDropSlot _firstSlot;
    private CardManager _manager;
    private int _strength;
    private Hero _hero;
    public CardManager Manager => _manager;
    public Hero Hero => _hero;
    public void Init(Hero hero, DragAndDropSlot slot, CardManager manager) {
        _hero = hero;
        _fullProgress = _progressImage.fillAmount;
        _progressImage.fillAmount = 0;
        _fullTaskProgress = _taskProgressImage.fillAmount;
        _taskProgressImage.fillAmount = 0;

        _firstSlot = slot;
        _deBuff.SetActive(false);
        _manager = manager;
        slot.InitSlot();
        ChangeSlot(slot);
        ReturnToSlot();
        _strength = _hero.Strength;
        _strengthText.text = _strength.ToString();
        _strengthText.raycastTarget = false;
    }
    public virtual bool CheckStrength(int requairedStrength) {
        if (_strength >= requairedStrength) return true;
        return false;
    }
    
    public void Win() {
        _taskProgress = 0;
        _taskProgressImage.fillAmount = _taskProgress;
        if (_progress < _fullProgress) {
            _progress += 0.25f * _fullProgress;
            _progressImage.fillAmount = _progress;
        }
    }
    public void AddTaskProgress(float time) {
        if (_taskProgress < _fullTaskProgress) {
            _taskProgress += _fullTaskProgress / time;
            _taskProgressImage.fillAmount = _taskProgress;
        }
    }
    public void Defeat() {
        _taskProgress = 0;
        _taskProgressImage.fillAmount = _taskProgress;
        if (_strength > 0) {
            _strength -= 1;
            _strengthText.text = _strength.ToString();
        }
        _deBuff.SetActive(true);
    }
}
