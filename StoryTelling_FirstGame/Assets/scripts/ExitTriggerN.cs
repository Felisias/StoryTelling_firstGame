using UnityEngine;

public class ExitTriggerN : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sheep 2"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameControllerN>().SheepExited();
        }
    }
}