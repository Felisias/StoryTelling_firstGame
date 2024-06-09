using UnityEngine;

public class FenceControllerN : MonoBehaviour
{
    public Transform fenceTransform; // ���� ��� �������� ������ �� Transform ������
    public float moveDistance = 1.0f; // ����������, �� ������� ����� ������������ �����

    private void Start()
    {
        // �������� ��������� Transform �������� �������, ���� �� �� ��� �������� �������
        if (fenceTransform == null)
        {
            fenceTransform = transform;
        }
    }

    public void MoveFence()
    {
        // ���������� ��������� �������� ��� ������
        float offsetX = Random.Range(-moveDistance, moveDistance);
        float offsetY = Random.Range(-moveDistance, moveDistance);

        // �������� ������� ������� � ��������� ��������
        Vector3 newPosition = fenceTransform.position + new Vector3(offsetX, offsetY, 0);
        fenceTransform.position = newPosition;
    }
}