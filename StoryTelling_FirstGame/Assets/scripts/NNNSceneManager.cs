using System.Collections; // �� �������� �������� ���
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // ����� � ��������, ����� ������� ��������� ����� �����
    public float delay = 5f;

    // �������� �����, �� ������� ����� �������
    public string sceneName = "NextScene";

    // ��������� �������� ��� ������ �����
    void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    // ������� ��� ����� ����� ����� ����������� �����
    IEnumerator ChangeSceneAfterDelay()
    {
        // ��� �������� ���������� �������
        yield return new WaitForSeconds(delay);

        // ��������� ����� �����
        SceneManager.LoadScene(sceneName);
    }
}
