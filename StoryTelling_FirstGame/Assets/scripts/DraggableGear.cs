using UnityEngine;
using System.Collections.Generic;

public class DraggableGear : MonoBehaviour
{
    private Vector3 _originalPosition;
    private bool _isDragging = false;
    private Collider2D _collider2D;
    private List<DraggableGear> _overlappingGears = new List<DraggableGear>();
    private bool _isRotating = false;
    private int _rotationDirection = 1; // 1 для вращения по часовой, -1 для против часовой

    public List<GameObject> targetSquares; // Список целевых квадратов
    public float checkRadius = 1.5f; // Радиус проверки соседей
    public float rotationSpeed = 100f; // Скорость вращения

    void Start()
    {
        _originalPosition = transform.position;
        _collider2D = GetComponent<Collider2D>();
        InvokeRepeating("UpdateRotationStatus", 0f, 0.1f); // Проверяем статус вращения каждые 0.1 секунды
    }

    void Update()
    {
        if (_isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }

        if (_isRotating && !_isDragging)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * _rotationDirection);
        }
    }

    void OnMouseDown()
    {
        _isDragging = true;
        _collider2D.enabled = false; // Отключаем коллайдер при начале перетаскивания
    }

    void OnMouseUp()
    {
        _isDragging = false;
        _collider2D.enabled = true; // Включаем коллайдер при отпускании
        CheckDropPosition();
        UpdateConnectedGears();
        UpdateRotationStatus();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var otherGear = collision.GetComponent<DraggableGear>();
        if (otherGear != null && otherGear != this)
        {
            if (!_overlappingGears.Contains(otherGear))
            {
                _overlappingGears.Add(otherGear);
            }
            UpdateRotationStatus();
        }

        var mainGear = collision.GetComponent<MainGear>();
        if (mainGear != null)
        {
            StartRotating(-mainGear.rotationDirection); // Начинаем вращаться в противоположном направлении от главной шестерёнки
        }

        var finalGear = collision.GetComponent<FinalGear>();
        if (finalGear != null)
        {
            finalGear.StartRotating();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var otherGear = collision.GetComponent<DraggableGear>();
        if (otherGear != null && otherGear != this)
        {
            if (_overlappingGears.Contains(otherGear))
            {
                _overlappingGears.Remove(otherGear);
            }
            UpdateRotationStatus();
        }

        var mainGear = collision.GetComponent<MainGear>();
        if (mainGear != null)
        {
            StopRotating();
        }

        var finalGear = collision.GetComponent<FinalGear>();
        if (finalGear != null)
        {
            finalGear.StopRotating();
        }
    }

    void CheckDropPosition()
    {
        bool isDroppedOnTarget = false;

        foreach (GameObject square in targetSquares)
        {
            Collider2D squareCollider = square.GetComponent<Collider2D>();
            if (squareCollider.bounds.Contains(transform.position))
            {
                transform.position = square.transform.position;
                _originalPosition = transform.position;
                isDroppedOnTarget = true;
                break;
            }
        }

        if (!isDroppedOnTarget)
        {
            transform.position = _originalPosition;
        }
    }

    public void StartRotating(int direction)
    {
        if (!_isRotating)
        {
            _isRotating = true;
            _rotationDirection = direction;

            foreach (var gear in _overlappingGears)
            {
                gear.StartRotating(-direction);
            }
        }
    }

    public void StopRotating()
    {
        if (_isRotating)
        {
            _isRotating = false;
            foreach (var gear in _overlappingGears)
            {
                gear.StopRotating();
            }
        }
    }

    void UpdateConnectedGears()
    {
        _overlappingGears.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        foreach (var collider in colliders)
        {
            var gear = collider.GetComponent<DraggableGear>();
            if (gear != null && gear != this)
            {
                _overlappingGears.Add(gear);
            }
        }
    }

    void UpdateRotationStatus()
    {
        if (_isDragging) return;

        bool shouldRotate = IsConnectedToMainGear(new HashSet<DraggableGear>());

        if (shouldRotate)
        {
            foreach (var gear in _overlappingGears)
            {
                if (gear._isRotating)
                {
                    StartRotating(-gear._rotationDirection);
                    return;
                }
            }
        }
        else
        {
            StopRotating();
        }
    }

    bool IsConnectedToMainGear(HashSet<DraggableGear> visited)
    {
        if (visited.Contains(this)) return false;

        visited.Add(this);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<MainGear>() != null)
            {
                return true; // Есть соединение с главной шестерёнкой
            }
        }

        foreach (var gear in _overlappingGears)
        {
            if (gear != null && gear != this && gear.IsConnectedToMainGear(visited))
            {
                return true; // Есть соединение с главной шестерёнкой через другую шестерёнку
            }
        }

        return false; // Нет соединения с главной шестерёнкой
    }
}
