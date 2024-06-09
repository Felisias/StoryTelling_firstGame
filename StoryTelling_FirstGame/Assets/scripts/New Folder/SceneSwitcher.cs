using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName; // ��� ����� ��� ������������

    public void SwitchScene()
    {
        // ��������, ������� �� ��� �����
        if (!string.IsNullOrEmpty(sceneName))
        {
            // ������������ �����, ���� ���� ��������������
            Time.timeScale = 1;
            // ������������� �� ��������� �����
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set in the inspector");
        }
    }
}
