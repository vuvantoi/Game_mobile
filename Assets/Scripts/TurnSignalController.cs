using UnityEngine;

public class TurnSignalController : MonoBehaviour
{
    // Đèn xi nhan
    public GameObject leftIndicator;  // Đèn xi nhan trái
    public GameObject rightIndicator; // Đèn xi nhan phải

    // Âm thanh xi nhan
    public AudioSource turnSignalSound;

    // Tốc độ nhấp nháy (giây)
    public float blinkInterval = 0.5f;

    // Trạng thái xi nhan
    private bool isLeftSignalOn = false;
    private bool isRightSignalOn = false;

    private float timer = 0;

    void Start()
    {
        // Tắt tất cả đèn và âm thanh
        SetLightState(leftIndicator, false);
        SetLightState(rightIndicator, false);

        if (turnSignalSound)
        {
            turnSignalSound.Stop(); // Đảm bảo âm thanh tắt khi bắt đầu
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Điều khiển nhấp nháy đèn
        if (isLeftSignalOn && timer >= blinkInterval)
        {
            ToggleLight(leftIndicator);
        }
        if (isRightSignalOn && timer >= blinkInterval)
        {
            ToggleLight(rightIndicator);
        }
    }

    // Bật/tắt xi nhan trái
    public void LeftSignal()
    {
        isLeftSignalOn = !isLeftSignalOn; // Chuyển trạng thái xi nhan trái
        isRightSignalOn = false;         // Tắt xi nhan phải
        ResetLights();
        PlayTurnSignalSound();
    }

    // Bật/tắt xi nhan phải
    public void RightSignal()
    {
        isRightSignalOn = !isRightSignalOn; // Chuyển trạng thái xi nhan phải
        isLeftSignalOn = false;            // Tắt xi nhan trái
        ResetLights();
        PlayTurnSignalSound();
    }

    // Tắt tất cả đèn và reset timer
    private void ResetLights()
    {
        timer = 0;
        SetLightState(leftIndicator, false);
        SetLightState(rightIndicator, false);
    }

    // Bật/tắt đèn theo trạng thái
    private void ToggleLight(GameObject light)
    {
        bool isActive = light.activeSelf; // Kiểm tra trạng thái hiện tại
        SetLightState(light, !isActive);
        timer = 0; // Reset timer
    }

    // Đặt trạng thái bật/tắt cho đèn
    private void SetLightState(GameObject light, bool state)
    {
        light.SetActive(state);
    }

    // Phát âm thanh xi nhan
    private void PlayTurnSignalSound()
    {
        if (turnSignalSound)
        {
            if (isLeftSignalOn || isRightSignalOn)
            {
                if (!turnSignalSound.isPlaying)
                {
                    turnSignalSound.loop = true;
                    turnSignalSound.Play();
                }
            }
            else
            {
                turnSignalSound.Stop();
            }
        }
    }
}
