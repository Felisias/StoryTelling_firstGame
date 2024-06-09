using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWatcher : MonoBehaviour
{
    public static LevelWatcher Instance { get; private set; }

    [SerializeField] private GameObject panel; // Панель UI
    [SerializeField] private Text panelText; // Текст на панели
    [SerializeField] private Button panelButton; // Кнопка на панели

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
             // Сохраняем объект при смене сцен
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Отключаем панель при старте
        if (panel != null)
        {
            panel.SetActive(false);
        }
        // Добавляем обработчик нажатия на кнопку
        if (panelButton != null)
        {
            panelButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Panel button is not assigned!");
        }
    }

    public void NotifyLevel5Spawned()
    {
        StartCoroutine(ShowPanelAfterDelay(3f));
    }

    private IEnumerator ShowPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (panel != null)
        {
            Debug.Log("Showing panel");
            panel.SetActive(true);
            
            Time.timeScale = 0; // Ставим игру на паузу
        }
        else
        {
            Debug.LogError("Panel is not assigned!");
        }
    }

    private void OnButtonClick()
    {
        Debug.Log("Button Clicked!"); // Добавим лог для проверки
        Time.timeScale = 1; // Возобновляем игру
        // Переключаемся на другую сцену
        SceneManager.LoadScene("love"); // Замените "NextSceneName" на имя вашей сцены
    }
}
