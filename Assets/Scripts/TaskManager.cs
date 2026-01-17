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
        StartTask("test");
    }
    public void EndTask(TaskPopUp task) {
        _taskPool.Return(task);
        _activeTasks.Remove(task);
    }

    public void StartTask(string taskName) {
        HeroTask task = _config.Tasks.FirstOrDefault(t => t.Name == taskName);
        if (task != null) {
            TaskPopUp taskPopUp = _taskPool.Get();
            taskPopUp.Init(task);
            _activeTasks.Add(taskPopUp);
        }
    }
}
