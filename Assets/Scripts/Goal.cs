using UnityEngine;

public class Goal : MonoBehaviour
{
    Rigidbody rb;

    const float G = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            
            Pull(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player p = other.gameObject.GetComponent<Player>();
            p.camOffSet *= 2;
        }
    }

    void Pull(GameObject player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();

        Vector3 dir = rb.position - playerRb.position;

        float distance = dir.magnitude;

        if (distance == 0) 
        {
            return;
        }

        float forceMagnitude = G * (rb.mass * playerRb.mass) / Mathf.Pow(distance, 2);

        Vector3 gravityForce = forceMagnitude * dir.normalized;

        playerRb.AddForce(gravityForce);

    }

}
