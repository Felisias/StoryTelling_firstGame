using UnityEngine;

public class FenceControllerN : MonoBehaviour
{
    public Transform fenceTransform; // Поле для хранения ссылки на Transform забора
    public float moveDistance = 1.0f; // Расстояние, на которое будет перемещаться забор

    private void Start()
    {
        // Получаем компонент Transform текущего объекта, если он не был назначен вручную
        if (fenceTransform == null)
        {
            fenceTransform = transform;
        }
    }

    public void MoveFence()
    {
        // Генерируем случайное смещение для забора
        float offsetX = Random.Range(-moveDistance, moveDistance);
        float offsetY = Random.Range(-moveDistance, moveDistance);

        // Получаем текущие позицию и применяем смещение
        Vector3 newPosition = fenceTransform.position + new Vector3(offsetX, offsetY, 0);
        fenceTransform.position = newPosition;
    }
}