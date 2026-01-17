using UnityEngine;

[System.Serializable]
public class HeroTask
{
    [SerializeField] private string _taskName;
    [SerializeField] private int _requairedStrength;

    public string Name => _taskName;
    public int RequairedStrength => _requairedStrength;
}
