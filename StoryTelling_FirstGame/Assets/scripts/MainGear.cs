using UnityEngine;

public class MainGear : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public int rotationDirection = 1; // 1 для вращения по часовой, -1 для против часовой

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * rotationDirection);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var gear = collision.GetComponent<DraggableGear>();
        if (gear != null)
        {
            gear.StartRotating(-rotationDirection); // Передаем противоположное направление
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var gear = collision.GetComponent<DraggableGear>();
        if (gear != null)
        {
            gear.StopRotating();
        }
    }
}

