using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameControllerN2 : MonoBehaviour
{
    public GameObject sheepPrefab;
    public Transform spawnPoint;
    public int requiredSheepCount = 10;
    public UIControllerN uiController;  // убедитесь, что это поле установлено в инспекторе
    public ProgressBarControllerN progressBarController;  // Добавьте это поле

    public SleepEffectController sleepEffectController;

    private int sheepCount = 0;
    private bool gameOver = false;

    void Start()
    {
        SpawnSheep();
    }

    void Update()
    {
        if (sheepCount >= requiredSheepCount && !gameOver)
        {
            WinGame();
        }
    }

    void SpawnSheep()
    {
        if (!gameOver)
        {
            Instantiate(sheepPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void SheepExited()
    {
        sheepCount++;
        if (sheepCount < requiredSheepCount)
        {
            SpawnSheep();
        }
        if (progressBarController != null)
        {
            progressBarController.IncrementProgress(1.0f / requiredSheepCount);  // Обновить прогресс
        }
    }

    public void LoseGame()
    {
        gameOver = true;
        if (uiController != null)
        {
            uiController.ShowGameOver();
        }
        else
        {
            Debug.LogError("UIController is not assigned in GameController");
        }

        // Остановить все активные барашки и заставить их падать
        SheepControllerN[] sheepControllers = FindObjectsOfType<SheepControllerN>();
        foreach (SheepControllerN sheep in sheepControllers)
        {
            sheep.GameOver();
        }
    }

    void WinGame()
    {
        sleepEffectController.PlaySleepEffect();
        StartCoroutine(LoadMainSceneAfterDelay(8)); // Задержка в 5 секунд перед загрузкой сцены
    }

    private IEnumerator LoadMainSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Day2"); // вернуться к основной игре
    }
}
