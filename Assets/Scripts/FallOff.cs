using UnityEngine;

public class FallOff : MonoBehaviour
{
    GameObject player;
    GameObject spawnPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < transform.position.y)
        {
            player.transform.position = spawnPoint.transform.position;
        }
    }
}
