using UnityEngine;

public class WallCollisionDetectorN : MonoBehaviour
{
    public UIControllerN uiControllerN;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameControllerN>().LoseGame();
        }
    }
}




