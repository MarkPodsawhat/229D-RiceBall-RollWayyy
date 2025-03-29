using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TitleScene;
    public GameObject TimeUi;
    public GameObject EndScene;

    public TextMeshProUGUI InGameTime;

    public Button StartButton;
    public Button ExitButton;
    public Button BackButton;

    private float timer;

    private void Awake()
    {
        StartButton.onClick.AddListener(OnStart);
    }
    void Start()
    {
        TitleScene.SetActive(true);
        EndScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStart()
    {
        TitleScene.SetActive(false);
        TimeUi.SetActive(true);
    }

    public void CheckStart()
    {
        Debug.Log("StartButton");
    }
}
