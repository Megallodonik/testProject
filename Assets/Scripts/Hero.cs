using UnityEngine;

[System.Serializable]
public class Hero {
    [SerializeField] private string _name;
    [SerializeField] private int _strength;

    public string Name => _name;
    public int Strength => _strength;
}
