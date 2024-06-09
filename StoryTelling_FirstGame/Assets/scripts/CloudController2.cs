using UnityEngine;

public class CloudController2 : MonoBehaviour
{
    public float speed = 2f;
    public float height = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sheep"))
        {
            FindObjectOfType<GameControllerN2>().LoseGame();
        }
    }
}