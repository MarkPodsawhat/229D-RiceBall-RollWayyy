using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private TextMeshPro tmp;

    private void Awake()
    {

    }
    void Start()
    {
        tmp = TimeUi.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }

    public void TimeCount()
    {
        timer += Time.deltaTime;
        tmp.text = timer.ToString();
    }

    public void OnStart()
    {
        TitleScene.SetActive(false);
        TimeUi.SetActive(true);
    }

    public void BackMenu()
    {
        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
