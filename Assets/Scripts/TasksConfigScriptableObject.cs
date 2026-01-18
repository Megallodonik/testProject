using UnityEngine;

[CreateAssetMenu(fileName = "TasksConfigScriptableObject", menuName = "Scriptable Objects/TasksConfigScriptableObject")]
public class TasksConfigScriptableObject : ScriptableObject
{
    [SerializeField] GameObject _taskPrefab;
    [SerializeField] GameObject _cardPrefab;
    [SerializeField] private HeroTask[] _tasks;
    [SerializeField] private Hero[] _heroes;
    [SerializeField] private int _maxTasks = 5;
    [SerializeField] private int _maxCards = 3;

    public HeroTask[] Tasks => _tasks;
    public GameObject TaskPrefab => _taskPrefab;
    public Hero[] Heroes => _heroes;
    public GameObject CardPrefab => _cardPrefab;
    public int MaxTasks => _maxTasks;
    public int MaxCards => _maxCards;
}
