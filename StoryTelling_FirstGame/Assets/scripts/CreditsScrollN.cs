using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;  // ��������� ������������ ���� ��� IEnumerator

public class CreditsScroll : MonoBehaviour
{
    public Text creditsText;  // ������ �� ����� ��� ������
    public float scrollSpeed = 20f;  // ��������� �������� ���������
    public float acceleratedScrollSpeed = 100f;  // ���������� �������� ���������
    private float currentScrollSpeed;

    public RectTransform endPoint;  // �����, �� ������� ����� ��������� �������� �� �����
    public Image fadePanel;  // ������ ��� ���������� ������
    public float fadeDuration = 2f;  // ������������ ����������
    public string nextSceneName;  // ��� ��������� �����

    private bool isFading = false;

    void Start()
    {
        // ������������� ��������� �������� ���������
        currentScrollSpeed = scrollSpeed;
    }

    void Update()
    {
        // ������� ����� �����
        creditsText.transform.Translate(Vector3.up * currentScrollSpeed * Time.deltaTime);

        // ��������� ������� ������ ��� ������ ���� ��� ��������� ���������
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            currentScrollSpeed = Mathf.Lerp(currentScrollSpeed, acceleratedScrollSpeed, Time.deltaTime * 5);
        }
        else
        {
            currentScrollSpeed = Mathf.Lerp(currentScrollSpeed, scrollSpeed, Time.deltaTime * 5);
        }

        // ���������, ���� �� ����� �� ������� ������
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
