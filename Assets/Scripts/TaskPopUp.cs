using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TaskPopUp : MonoBehaviour {
    //[SerializeField] TasksConfigScriptableObject _config; //в продукте, конечно, надо через zenject прокидывать
    [SerializeField] private PopUpSlot _popUp;
    [SerializeField] private GameObject _taskVisual;
    private HeroTask _task;
    private Card _card;
    private TaskManager _manager;
    private bool _done = false;
    public HeroTask Task => _task;
    public TaskManager Manager => _manager;
    public void Init(HeroTask task, TaskManager manager) {
        _done = false;
        _manager = manager;
        int posX = Random.Range(0 + 200, Screen.width - 200);
        int posY = Random.Range(0 + 200, Screen.height - 200);
        this.transform.position = new Vector2(posX, posY);

        _task = task;
        _popUp.gameObject.SetActive(false);
        _popUp.Init(task, this);
        _popUp.TaskStarted += BeginTask;
    }
    private void OnDestroy() {
        _popUp.TaskStarted -= BeginTask;
    }

    public void OpenPopUp() {
        _popUp.gameObject.SetActive(true);
    }
    public void ClosePopUp() {
        _popUp.gameObject.SetActive(false);
        if (_done) {
            DeleteTask();
        }
    }
    private void EndTask() {
        _done = true;
        _taskVisual.SetActive(true);
        _popUp.EndTask(_card);
    }
    public void DeleteTask() {
        _manager.EndTask(this);
    }
    private void BeginTask(Card card) {
        _card = card;
        _card.ReturnToLastSlot();
        StartCoroutine(Timer(_task.Time));
       _taskVisual.SetActive(false);

    }
    private IEnumerator Timer(int seconds) {
        while (seconds > 0) {
            TaskTick();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        EndTask();
    }
    private void TaskTick() {
        _card.AddTaskProgress(_task.Time);
    }
}
