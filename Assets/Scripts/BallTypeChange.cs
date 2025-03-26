using UnityEngine;

public class BallTypeChange : MonoBehaviour
{
    public int matNo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.ChangeBallType(matNo);
        }
    }

}
