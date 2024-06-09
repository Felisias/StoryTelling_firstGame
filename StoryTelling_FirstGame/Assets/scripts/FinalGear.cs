using UnityEngine;
using System.Collections;

public class FinalGear : MonoBehaviour
{
    private bool _isRotating = false;
    private int _rotationDirection = -1; // 1 для вращения по часовой, -1 для против часовой


    void Update()
    {
        if (_isRotating)
        {
            transform.Rotate(Vector3.forward * 100f * Time.deltaTime* _rotationDirection);
        }
    }

    public void StartRotating()
    {
        if (!_isRotating)
        {
            _isRotating = true;
            StartCoroutine(ShowCanvasAfterDelay(2f));
        }
    }

    public void StopRotating()
    {
        _isRotating = false;
    }

    private IEnumerator ShowCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (WinCanvas.Instance != null)
        {
            WinCanvas.Instance.Show();
        }
        else
        {
            Debug.LogError("WinCanvas.Instance is null. Make sure WinCanvas script is in the scene and correctly initialized.");
        }
    }
}
