using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerN : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);  // Скрываем панель в начале игры
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);  // Показать панель
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Перезапуск текущей сцены
    }
}