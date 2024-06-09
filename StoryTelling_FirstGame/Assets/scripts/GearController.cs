using UnityEngine;

public class GearController : MonoBehaviour
{
    public Gear[] gears;

    void Update()
    {
        foreach (Gear gear in gears)
        {
            if (gear.isActiveAndEnabled)
            {
                gear.rotationSpeed = 100f; // Вы можете настроить это значение
            }
        }
    }
}