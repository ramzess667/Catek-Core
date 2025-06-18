using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float slowMultiplier = 0.5f;
    public float sprintMultiplier = 1.5f;
    public float fatigueMultiplier = 0.5f;
    public float maxStamina = 100f;
    public float staminaDrain = 20f;
    public float staminaRegen = 10f;

    public Slider staminaSlider; // ������ �� UI-�������

    private Rigidbody2D rb;
    private Vector2 movement;
    private float currentStamina;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentStamina = maxStamina;

        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = currentStamina;
        }
    }

    void Update()
    {
        // �������� ����������� ��������
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;

        float finalSpeed = speed;

        // ���������� ��� ��������� Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed *= slowMultiplier;
        }
        // ��������� ��� ��������� Ctrl, ���� ���� ������������
        else if (Input.GetKey(KeyCode.LeftControl) && currentStamina > 0)
        {
            finalSpeed *= sprintMultiplier;
            currentStamina -= staminaDrain * Time.deltaTime;
        }
        // �������������� ������������
        else
        {
            currentStamina += staminaRegen * Time.deltaTime;
        }

        // ����������� ������������ � ���������� ���������
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        // ���������� ��� ������ ���������
        if (currentStamina == 0)
        {
            finalSpeed *= fatigueMultiplier;
        }

        // ��������� �������� �������� � �����������
        movement *= finalSpeed;

        // ��������� UI-�������
        if (staminaSlider != null)
        {
            staminaSlider.value = currentStamina;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }
}
