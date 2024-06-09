using System.Collections; // Не забудьте добавить это
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Время в секундах, через которое произойдёт смена сцены
    public float delay = 5f;

    // Название сцены, на которую нужно перейти
    public string sceneName = "NextScene";

    // Запускаем корутину при старте сцены
    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    // Корутин для смены сцены через определённое время
    IEnumerator ChangeSceneAfterDelay()
    {
        // Ждём заданное количество времени
        yield return new WaitForSeconds(delay);

        // Загружаем новую сцену
        SceneManager.LoadScene(sceneName);
    }
}
