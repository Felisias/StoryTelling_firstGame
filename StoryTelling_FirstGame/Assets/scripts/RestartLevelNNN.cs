using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelNNN : MonoBehaviour
{
    public void RestartCurrentLevel()
    {
        // Получаем активную сцену
        Scene currentScene = SceneManager.GetActiveScene();
        // Перезапускаем сцену с текущим именем
        SceneManager.LoadScene(currentScene.name);
    }
}