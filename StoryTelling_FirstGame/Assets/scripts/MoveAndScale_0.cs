using UnityEngine;

public class MoveAndScale : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float scaleIncrease = 0.1f;
    public float smoothTime = 0.5f;
    Vector3 targetPosition;
    Vector3 velocity;

    void Update()
    {
        targetPosition = new Vector3(Input.GetAxis("Horizontal") * -10.0f, -90.0f, 0.0f);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Перемещение объекта влево
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Увеличение размера объекта
            transform.localScale *= (1.0f + scaleIncrease);
        }
    }
}