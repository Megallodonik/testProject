using UnityEngine;

[CreateAssetMenu(fileName = "TasksConfigScriptableObject", menuName = "Scriptable Objects/TasksConfigScriptableObject")]
public class TasksConfigScriptableObject : ScriptableObject
{
    [SerializeField] GameObject _taskPrefab;
    [SerializeField] private HeroTask[] _tasks;
    [SerializeField] private int _maxTasks = 5;

    public HeroTask[] Tasks => _tasks;
    public GameObject TaskPrefab => _taskPrefab;    
    public int MaxTasks => _maxTasks;
}
