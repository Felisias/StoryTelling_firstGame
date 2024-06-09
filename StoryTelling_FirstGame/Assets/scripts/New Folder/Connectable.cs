using UnityEngine;

public class Connectable : MonoBehaviour
{
    [SerializeField] public int level;
    [SerializeField] public bool isSpawned;
    [SerializeField] private GameObject nextConnectable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Connectable>())
        {
            Connectable c = collision.GetComponent<Connectable>();

            if (!c.isSpawned && !collision.isTrigger && c.level == level)
            {
                Destroy(collision.gameObject);
                isSpawned = true;
                Instantiate(nextConnectable, Vector2.Lerp(transform.position, collision.transform.position, .5f), Quaternion.identity);
                Destroy(gameObject);

                // Уведомляем LevelWatcher, если уровень 5
                if (level == 4)
                {
                    LevelWatcher.Instance.NotifyLevel5Spawned();
                }
            }
        }
    }
}
