using UnityEngine;

public class TextBlockController : MonoBehaviour
{
    public float initialSpeed = 50f; // ��������� �������� �������
    public float deceleration = 5f; // ����������
    public float acceleration = 10f; // ���������
    public float stopYPosition = 1000f; // �������, �� ������� ����� ��������������� �� �������
    public TextBlockController nextBlock; // ������ �� ��������� ��������� ����

    private bool isMoving = false;
    private bool isDecelerating = true;

    void Update()
    {
        if (isMoving)
        {
            Vector3 position = transform.position;

            // ���������������� ��������
            if (isDecelerating)
            {
                initialSpeed -= deceleration * Time.deltaTime;
                if (initialSpeed < 0)
                {
                    initialSpeed = 0;
                }
            }
            // ��������������� ��������
            else
            {
                initialSpeed += acceleration * Time.deltaTime;
            }

            // �������� ������ �����
            position.y += initialSpeed * Time.deltaTime;
            transform.position = position;

            // ��������� ������ �� �������
            if (position.y >= stopYPosition)
            {
                isMoving = false;
                if (nextBlock != null)
                {
                    nextBlock.StartMoving();
                }
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        isDecelerating = true;
    }

    void Start()
    {
        if (nextBlock == null)
        {
            StartMoving();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CentralZone"))
        {
            isDecelerating = false; // ������ ���������������� ��������
        }
        else if (other.CompareTag("TopZone"))
        {
            isMoving = false; // ��������� ��������

            // ������ ���������� �����
            if (nextBlock != null)
            {
                nextBlock.StartMoving();
            }
        }
    }
}
