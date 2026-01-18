using UnityEngine;

[System.Serializable]
public class HeroTask
{
    [SerializeField] private string _taskName;
    [SerializeField] private int _requairedStrength;
    [SerializeField] private int _time;
    public string Name => _taskName;
    public int RequairedStrength => _requairedStrength;
    public int Time => _time;
}
