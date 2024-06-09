using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWatcher : MonoBehaviour
{
    public static LevelWatcher Instance { get; private set; }

    [SerializeField] private GameObject panel; // ������ UI
    [SerializeField] private Text panelText; // ����� �� ������
    [SerializeField] private Button panelButton; // ������ �� ������

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
             // ��������� ������ ��� ����� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ��������� ������ ��� ������
        if (panel != null)
        {
            panel.SetActive(false);
        }
        // ��������� ���������� ������� �� ������
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
            
            Time.timeScale = 0; // ������ ���� �� �����
        }
        else
        {
            Debug.LogError("Panel is not assigned!");
        }
    }

    private void OnButtonClick()
    {
        Debug.Log("Button Clicked!"); // ������� ��� ��� ��������
        Time.timeScale = 1; // ������������ ����
        // ������������� �� ������ �����
        SceneManager.LoadScene("love"); // �������� "NextSceneName" �� ��� ����� �����
    }
}
