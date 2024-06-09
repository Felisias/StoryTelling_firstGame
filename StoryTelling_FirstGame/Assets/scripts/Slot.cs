using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isOccupied = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            isOccupied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            isOccupied = false;
        }
    }
}