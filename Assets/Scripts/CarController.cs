using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float acceleration = 10f; // Tốc độ tăng tốc
    public float maxSpeed = 20f; // Tốc độ tối đa
    public float brakeForce = 20f; // Lực phanh
    public float turnSpeed = 50f; // Tốc độ quay đầu

    public Joystick joystick;
    private float currentSpeed = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on this car!");
        }
    }

    void FixedUpdate()
    {
        // Nhận input
        float moveInput = Input.GetAxis("Vertical"); // W/S hoặc Up/Down
        float turnInput = Input.GetAxis("Horizontal"); // A/D hoặc Left/Right

        moveInput = joystick.Vertical;
        turnInput = joystick.Horizontal;




        // Xử lý tăng tốc/phanh
        if (moveInput > 0) // Tăng tốc
        {
            currentSpeed += moveInput * acceleration * Time.fixedDeltaTime;
        }
        else if (moveInput < 0) // Phanh ngược
        {
            currentSpeed += moveInput * brakeForce * Time.fixedDeltaTime;
        }
        else // Dừng xe dần dần khi không nhấn phím
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.05f);
        }

        // Giới hạn tốc độ
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // Tính toán hướng di chuyển
        Vector3 forwardMovement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement);

        // Xử lý quay đầu
        if (Mathf.Abs(currentSpeed) > 0.1f) // Quay đầu chỉ khi xe đang di chuyển
        {
            float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
            if (currentSpeed < 0) turn = -turn; // Đảo ngược hướng quay khi lùi
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

}
