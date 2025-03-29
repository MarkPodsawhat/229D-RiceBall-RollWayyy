using UnityEngine;

public class Endgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject EndScene;
    public GameObject EndCredit;

    private bool endGame = false;
    private float scrollSpeed = 50;

    private void Update()
    {
        if (endGame = true)
        {
            
        }
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        endGame = true;
        EndScene.SetActive(true);
    }
}
