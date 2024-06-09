using UnityEngine;

public class ExitTriggerN2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sheep"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameControllerN2>().SheepExited();
        }
    }
}