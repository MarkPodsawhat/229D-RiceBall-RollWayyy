using UnityEngine;

public class WindZone : MonoBehaviour
{
    public float windForce = 10f;
    public Material banMat;

    private void OnTriggerStay(Collider other)
    {
        var ball = other.gameObject;
        
        if (ball.CompareTag("Player"))
        {
            var rb = ball.GetComponent<Rigidbody>();
            MeshRenderer render = ball.GetComponent<MeshRenderer>();
            var dir = transform.up;

            if (render.sharedMaterial != banMat)
            {
                rb.AddForce(dir * windForce);
            }

        }
    }
}
