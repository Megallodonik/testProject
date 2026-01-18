using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TaskPopUp : MonoBehaviour
{
    //[SerializeField] TasksConfigScriptableObject _config; //в продукте, конечно, надо через zenject прокидывать
    [SerializeField] private GameObject _popUp;
    [SerializeField] private TMPro.TextMeshProUGUI _titleText;
    [SerializeField] private TMPro.TextMeshProUGUI _strengthText;
    private Vector2 _offset;
    private HeroTask _task;
    private string _title;
    private int _requairedStrength;

    public HeroTask Task => _task;
    public void Init(HeroTask task) {
        int posX = Random.Range(0 + 50, Screen.width - 50);
        int posY = Random.Range(0 + 50, Screen.height - 50);
        this.transform.position = new Vector2 (posX, posY);

        _task = task;
        _popUp.SetActive(false);
        _title = _task.Name;
        _requairedStrength = _task.RequairedStrength;

        if (_titleText == null) {
            Debug.LogError($"Title Text of {this.gameObject} is not attached!");
            return;
        }
        _titleText.text = _title;
        if (_strengthText == null) {
            Debug.LogError($"Strength Text of {this.gameObject} is not attached!");
            return;
        }
        _strengthText.text = _requairedStrength.ToString();
    }

    public void OpenPopUp() {
        _popUp.SetActive(true);
    }
    public void ClosePopUp() {
        _popUp.SetActive(false);
    }
}
