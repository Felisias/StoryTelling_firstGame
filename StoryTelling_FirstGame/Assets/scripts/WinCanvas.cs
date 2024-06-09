using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    public static WinCanvas Instance;

    public GameObject canvasObject;
    public Button switchSceneButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        canvasObject.SetActive(false); // ���������, ��� canvasObject �������� � ����������
        switchSceneButton.onClick.AddListener(OnSwitchSceneButtonClicked); // ���������, ��� switchSceneButton �������� � ����������
    }

    public void Show()
    {
        canvasObject.SetActive(true);
    }

    private void OnSwitchSceneButtonClicked()
    {
        canvasObject.SetActive(false);
        SceneManager.LoadScene("finale"); // �������� "NextScene" �� ��� ����� ��������� �����
    }
}
