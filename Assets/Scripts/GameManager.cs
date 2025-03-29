using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject TitleScene;
    public GameObject TimeUi;
    public GameObject WASD;

    public TextMeshProUGUI InGameTime;

    public Button StartButton;
    public Button ExitButton;
    public Button BackButton;

    public bool timeBool = false;
    private float timer;

    void Update()
    {
        if (timeBool)
        {
            TimeCount();
        }
    }

    public void TimeCount()
    {
        timer += Time.deltaTime;
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.FloorToInt(timer % 60);
        InGameTime.text = string.Format("{0:00}:{1:00}", min,sec);
    }

    public void OnStart()
    {
        TitleScene.SetActive(false);
        TimeUi.SetActive(true);
        timeBool = true;
        WASD.SetActive(true);
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
