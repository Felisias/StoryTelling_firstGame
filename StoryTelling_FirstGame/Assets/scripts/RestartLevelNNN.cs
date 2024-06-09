using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelNNN : MonoBehaviour
{
    public void RestartCurrentLevel()
    {
        // �������� �������� �����
        Scene currentScene = SceneManager.GetActiveScene();
        // ������������� ����� � ������� ������
        SceneManager.LoadScene(currentScene.name);
    }
}