using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TasksConfigScriptableObject _config;
    private List<TaskPopUp> _activeTasks = new List<TaskPopUp>();
    private ObjectPool<TaskPopUp> _taskPool;


    private void Awake() {
        _taskPool = new ObjectPool<TaskPopUp>(_config.TaskPrefab.GetComponent<TaskPopUp>(), _config.MaxTasks, transform);
        for (int i = 0; i < _config.MaxTasks; i++) {
            int taskIndex = Random.Range(0, _config.Tasks.Length);
            StartTask(_config.Tasks[taskIndex].Name);
        }
    }
    public void EndTask(TaskPopUp task) {
        _taskPool.Return(task);
        _activeTasks.Remove(task);
        int taskIndex = Random.Range(0, _config.Tasks.Length);
        StartTask(_config.Tasks[taskIndex].Name);
    }

    public void StartTask(string taskName) {
        HeroTask task = _config.Tasks.FirstOrDefault(t => t.Name == taskName);
        if (task != null) {
            TaskPopUp taskPopUp = _taskPool.Get();
            taskPopUp.Init(task, this);
            _activeTasks.Add(taskPopUp);
        }
    }
}
