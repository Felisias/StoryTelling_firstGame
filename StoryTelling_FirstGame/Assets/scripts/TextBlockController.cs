using UnityEngine;

public class TextBlockController : MonoBehaviour
{
    public float initialSpeed = 50f; // Начальная скорость подъема
    public float deceleration = 5f; // Замедление
    public float acceleration = 10f; // Ускорение
    public float stopYPosition = 1000f; // Позиция, на которой текст останавливается за экраном
    public TextBlockController nextBlock; // Ссылка на следующий текстовый блок

    private bool isMoving = false;
    private bool isDecelerating = true;

    void Update()
    {
        if (isMoving)
        {
            Vector3 position = transform.position;

            // Равнозамедленное движение
            if (isDecelerating)
            {
                initialSpeed -= deceleration * Time.deltaTime;
                if (initialSpeed < 0)
                {
                    initialSpeed = 0;
                }
            }
            // Равноускоренное движение
            else
            {
                initialSpeed += acceleration * Time.deltaTime;
            }

            // Движение текста вверх
            position.y += initialSpeed * Time.deltaTime;
            transform.position = position;

            // Остановка текста за экраном
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
            isDecelerating = false; // Начало равноускоренного движения
        }
        else if (other.CompareTag("TopZone"))
        {
            isMoving = false; // Остановка движения

            // Запуск следующего блока
            if (nextBlock != null)
            {
                nextBlock.StartMoving();
            }
        }
    }
}
