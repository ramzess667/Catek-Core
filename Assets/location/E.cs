using UnityEngine;

public class DoorController : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private bool isPassable = false;
    public float resetTime = 1f; // Время до возврата состояния

    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>(); // Получаем коллайдер
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Проверяем нажатие клавиши E
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        isPassable = !isPassable; // Переключаем состояние
        doorCollider.enabled = !isPassable; // Отключаем/включаем коллайдер

        if (isPassable)
        {
            Invoke(nameof(ResetDoor), resetTime); // Запускаем возврат через 3 сек
        }
    }

    void ResetDoor()
    {
        isPassable = false;
        doorCollider.enabled = true;
    }
}