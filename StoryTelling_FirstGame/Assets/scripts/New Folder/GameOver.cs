using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private float penatlyTime;
    [SerializeField] private float time;

    private void Start()
    {
        time = penatlyTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Connectable")
        {
            //time -= Time.deltaTime;
            time -= Time.unscaledDeltaTime;

            if (time <= 0)
                SetGameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Connectable")
        { 
            time = penatlyTime;
        }
    }

    private void SetGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
    