using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NNNAchievementManager : MonoBehaviour
{
    public Image achievementImage;
    public float displayTime = 3f; // Время отображения ачивки

    private void Start()
    {
        achievementImage.gameObject.SetActive(false);
    }

    public void ShowAchievement(Sprite achievementSprite)
    {
        achievementImage.sprite = achievementSprite;
        StartCoroutine(DisplayAchievement());
    }

    private IEnumerator DisplayAchievement()
    {
        achievementImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        achievementImage.gameObject.SetActive(false);
    }
}
