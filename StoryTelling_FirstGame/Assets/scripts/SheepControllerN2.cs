using UnityEngine;

public class SheepControllerN2 : MonoBehaviour
{
    public float jumpForce = 5f;
    public float horizontalSpeed = 2f;

    private Rigidbody2D rb;
    private Animator animator;  // Добавьте ссылку на Animator
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  // Получите компонент Animator

        rb.velocity = new Vector2(horizontalSpeed, 0);
    }

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetTrigger("Jump");  // Установите триггер для анимации прыжка
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameControllerN2>().LoseGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 1;
    }
}