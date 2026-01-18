using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TaskPopUp : MonoBehaviour
{
    //[SerializeField] TasksConfigScriptableObject _config; //в продукте, конечно, надо через zenject прокидывать
    [SerializeField]  private PopUpSlot _slot;
    private Vector2 _offset;
    private HeroTask _task;


    public HeroTask Task => _task;
    public void Init(HeroTask task) {
        int posX = Random.Range(0 + 50, Screen.width - 50);
        int posY = Random.Range(0 + 50, Screen.height - 50);
        this.transform.position = new Vector2 (posX, posY);

        _task = task;
        _slot.gameObject.SetActive(false);
        _slot.Init(task);

    }

    public void OpenPopUp() {
        _slot.gameObject.SetActive(true);
    }
    public void ClosePopUp() {
        _slot.gameObject.SetActive(false);
    }

}
