using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameControllerN2 : MonoBehaviour
{
    public GameObject sheepPrefab;
    public Transform spawnPoint;
    public int requiredSheepCount = 10;
    public UIControllerN uiController;  // ���������, ��� ��� ���� ����������� � ����������
    public ProgressBarControllerN progressBarController;  // �������� ��� ����

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
            progressBarController.IncrementProgress(1.0f / requiredSheepCount);  // �������� ��������
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

        // ���������� ��� �������� ������� � ��������� �� ������
        SheepControllerN[] sheepControllers = FindObjectsOfType<SheepControllerN>();
        foreach (SheepControllerN sheep in sheepControllers)
        {
            sheep.GameOver();
        }
    }

    void WinGame()
    {
        sleepEffectController.PlaySleepEffect();
        StartCoroutine(LoadMainSceneAfterDelay(8)); // �������� � 5 ������ ����� ��������� �����
    }

    private IEnumerator LoadMainSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Day2"); // ��������� � �������� ����
    }
}
