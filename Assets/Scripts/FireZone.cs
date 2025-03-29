using UnityEngine;

public class FireZone : MonoBehaviour
{
    public GameObject spawnPoint;
    public Material banMat;

    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject;
        if (ball.CompareTag("Player"))
        {
            var rb = ball.GetComponent<Rigidbody>();
            MeshRenderer render = ball.GetComponent<MeshRenderer>();

            if (render.sharedMaterial == banMat)
            {
                ball.transform.position = spawnPoint.transform.position;
            }
        }
    }

}
