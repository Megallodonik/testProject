using UnityEngine;

public class Card : DragAndDrop
{
    private int _strength;
    public void Init(Hero hero, Vector3 pos) {
        ChangeSlot(pos);
        ReturnToSlot();
        _strength = hero.Strength;
    }
    public override bool InTaskSlot(int requairedStrength) {
        if (_strength >= requairedStrength) return true;
        return false;
    }
}
