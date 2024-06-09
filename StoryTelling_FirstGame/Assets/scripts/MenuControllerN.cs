using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerN : MonoBehaviour
{
    public RectTransform[] panels;
    public RectTransform textPanel;
    public Text textDisplay;
    public string[] texts;
    public Vector2 largeSize = new Vector2(200, 200);
    public Vector2 smallSize = new Vector2(100, 100);
    public float animationDuration = 0.5f;

    public Vector2 centralPosition = new Vector2(230, 0);
    public Vector2[] initialPositions;

    private int currentIndex = -1;

    void Start()
    {
        // Установка начальных позиций для всех панелей
        initialPositions = new Vector2[panels.Length];
        for (int i = 0; i < panels.Length; i++)
        {
            initialPositions[i] = new Vector2(60 + 200 * i, -320);
            panels[i].anchoredPosition = initialPositions[i];
            panels[i].sizeDelta = smallSize;
        }

        // Установка начального текста
        if (texts.Length > 0)
        {
            textDisplay.text = texts[0];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        if (currentIndex != -1)
        {
            StartCoroutine(AnimatePanel(panels[currentIndex], initialPositions[currentIndex], smallSize));
        }
        currentIndex = (currentIndex + 1) % panels.Length;
        StartCoroutine(AnimatePanel(panels[currentIndex], centralPosition, largeSize));
        UpdateText();
    }

    void MoveLeft()
    {
        if (currentIndex != -1)
        {
            StartCoroutine(AnimatePanel(panels[currentIndex], initialPositions[currentIndex], smallSize));
        }
        currentIndex = (currentIndex - 1 + panels.Length) % panels.Length;
        StartCoroutine(AnimatePanel(panels[currentIndex], centralPosition, largeSize));
        UpdateText();
    }

    void UpdateText()
    {
        if (currentIndex >= 0 && currentIndex < texts.Length)
        {
            textDisplay.text = texts[currentIndex];
        }
    }

    IEnumerator AnimatePanel(RectTransform panel, Vector2 targetPosition, Vector2 targetSize)
    {
        Vector2 startPosition = panel.anchoredPosition;
        Vector3 startScale = panel.localScale;
        Vector3 targetScale = new Vector3(targetSize.x / smallSize.x, targetSize.y / smallSize.y, 1);
        float elapsedTime = 0;

        while (elapsedTime < animationDuration)
        {
            panel.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / animationDuration);
            panel.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.anchoredPosition = targetPosition;
        panel.localScale = targetScale;
    }
}
