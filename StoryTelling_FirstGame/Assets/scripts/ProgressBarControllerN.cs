using UnityEngine;
using UnityEngine.UI;

public class ProgressBarControllerN : MonoBehaviour
{
    public Image progressBarFill;
    private float targetProgress = 0;
    private float fillSpeed = 0.5f;

    void Update()
    {
        if (progressBarFill.fillAmount < targetProgress)
        {
            progressBarFill.fillAmount += fillSpeed * Time.deltaTime;
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = Mathf.Clamp(targetProgress + newProgress, 0, 1);
    }
}