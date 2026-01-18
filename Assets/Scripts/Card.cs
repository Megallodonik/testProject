using UnityEngine;

public class Card : DragAndDrop
{
    private CardManager _manager;
    private int _strength;

    public CardManager Manager => _manager;
    public void Init(Hero hero, Vector3 pos, CardManager manager) {
        _manager = manager;
        ChangeSlot(pos);
        ReturnToSlot();
        _strength = hero.Strength;
    }
    public virtual bool CheckStrength(int requairedStrength) {
        if (_strength >= requairedStrength) return true;
        return false;
    }
}
