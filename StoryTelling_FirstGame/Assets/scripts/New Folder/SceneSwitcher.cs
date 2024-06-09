using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName; // Имя сцены для переключения

    public void SwitchScene()
    {
        // Проверка, указано ли имя сцены
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Возобновляем время, если было приостановлено
            Time.timeScale = 1;
            // Переключаемся на указанную сцену
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set in the inspector");
        }
    }
}
