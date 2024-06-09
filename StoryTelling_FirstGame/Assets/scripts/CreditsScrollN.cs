using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;  // Добавлено пространство имен для IEnumerator

public class CreditsScroll : MonoBehaviour
{
    public Text creditsText;  // Ссылка на текст для титров
    public float scrollSpeed = 20f;  // Начальная скорость прокрутки
    public float acceleratedScrollSpeed = 100f;  // Ускоренная скорость прокрутки
    private float currentScrollSpeed;

    public RectTransform endPoint;  // Точка, за которой текст считается вышедшим за экран
    public Image fadePanel;  // Панель для затемнения экрана
    public float fadeDuration = 2f;  // Длительность затемнения
    public string nextSceneName;  // Имя следующей сцены

    private bool isFading = false;

    void Start()
    {
        // Устанавливаем начальную скорость прокрутки
        currentScrollSpeed = scrollSpeed;
    }

    void Update()
    {
        // Двигаем текст вверх
        creditsText.transform.Translate(Vector3.up * currentScrollSpeed * Time.deltaTime);

        // Проверяем нажатие клавиш или кнопок мыши для ускорения прокрутки
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            currentScrollSpeed = Mathf.Lerp(currentScrollSpeed, acceleratedScrollSpeed, Time.deltaTime * 5);
        }
        else
        {
            currentScrollSpeed = Mathf.Lerp(currentScrollSpeed, scrollSpeed, Time.deltaTime * 5);
        }

        // Проверяем, ушел ли текст за пределы экрана
        if (creditsText.transform.position.y >= endPoint.position.y && !isFading)
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private IEnumerator FadeOutAndLoadScene()
    {
        isFading = true;
        float elapsedTime = 0f;
        Color panelColor = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            panelColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
