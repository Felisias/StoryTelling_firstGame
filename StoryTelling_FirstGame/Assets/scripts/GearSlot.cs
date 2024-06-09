using UnityEngine;

public class GearSlot : MonoBehaviour
{
    public bool isOccupied = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear") && !isOccupied)
        {
            isOccupied = true;
            other.transform.position = transform.position;
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            isOccupied = false;
        }
    }
}