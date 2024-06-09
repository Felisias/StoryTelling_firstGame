using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerN : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        gameOverPanel.SetActive(false);  // �������� ������ � ������ ����
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);  // �������� ������
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // ���������� ������� �����
    }
}