using TMPro;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject EndScene;
    public GameObject EndCredit;
    public GameObject gameM;
    public GameObject timeEnd;
    private TextMeshProUGUI totalTime;
    GameManager gameMS;

    private bool endGame = false;
    private float scrollSpeed = 50;

    private void Awake()
    {
        totalTime = timeEnd.GetComponent<TextMeshProUGUI>();
        gameMS = gameM.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (endGame)
        {
            EC();
        }
    }

    void EC()
    {
        RectTransform rect = EndCredit.GetComponent<RectTransform>();
        if (rect.anchoredPosition.y > 3800)
        {
            return;
        }
        rect.anchoredPosition += new Vector2(0,10);

    }

    private void OnCollisionEnter(Collision collision)
    {
        TextMeshProUGUI IGM = gameMS.InGameTime;

        totalTime.text = gameMS.InGameTime.text;
        totalTime.color = Color.green;

        endGame = true;
        EndCredit.SetActive(true);
        EndScene.SetActive(true);

        gameMS.WASD .SetActive(false);
        gameMS.TimeUi.SetActive(false);
        gameMS.timeBool = false;

    }
}
