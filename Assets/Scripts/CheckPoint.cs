using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject spawnPoint;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            spawnPoint.transform.position = transform.position;
        }
    }
}
