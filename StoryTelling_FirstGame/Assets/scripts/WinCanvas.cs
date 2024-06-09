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
        canvasObject.SetActive(false); // Убедитесь, что canvasObject назначен в инспекторе
        switchSceneButton.onClick.AddListener(OnSwitchSceneButtonClicked); // Убедитесь, что switchSceneButton назначен в инспекторе
    }

    public void Show()
    {
        canvasObject.SetActive(true);
    }

    private void OnSwitchSceneButtonClicked()
    {
        canvasObject.SetActive(false);
        SceneManager.LoadScene("finale"); // Замените "NextScene" на имя вашей следующей сцены
    }
}
