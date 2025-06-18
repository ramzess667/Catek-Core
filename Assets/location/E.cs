using UnityEngine;

public class DoorController : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private bool isPassable = false;
    public float resetTime = 1f; // ����� �� �������� ���������

    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>(); // �������� ���������
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // ��������� ������� ������� E
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        isPassable = !isPassable; // ����������� ���������
        doorCollider.enabled = !isPassable; // ���������/�������� ���������

        if (isPassable)
        {
            Invoke(nameof(ResetDoor), resetTime); // ��������� ������� ����� 3 ���
        }
    }

    void ResetDoor()
    {
        isPassable = false;
        doorCollider.enabled = true;
    }
}