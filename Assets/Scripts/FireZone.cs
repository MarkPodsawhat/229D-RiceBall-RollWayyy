using UnityEngine;

public class FireZone : MonoBehaviour
{
    public GameObject spawnPoint;
    public Material banMat;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject;
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
