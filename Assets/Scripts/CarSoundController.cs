using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI Button

public class CarSoundController : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioSource warningSound; // Âm thanh cảnh báo
    public AudioSource hornSound;    // Âm thanh còi

    private bool isSoundOn = false; // Trạng thái bật/tắt âm thanh cảnh báo

    private void Start()
    {
        // Dừng âm thanh cảnh báo khi bắt đầu game
        if (warningSound != null)
        {
            warningSound.Stop();
        }
        if (hornSound != null)
        {
            hornSound.Stop();
        }
    }

    // Hàm bật/tắt âm thanh cảnh báo
    public void ToggleWarningSound()
    {
        // Đảo trạng thái bật/tắt âm thanh cảnh báo
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            // Nếu âm thanh bật, phát âm thanh cảnh báo
            if (warningSound != null)
            {
                warningSound.Play();
            }
        }
        else
        {
            // Nếu âm thanh tắt, dừng phát âm thanh cảnh báo
            if (warningSound != null)
            {
                warningSound.Stop();
            }
        }
    }

    // Hàm tít còi
    public void HonkHorn()
    {
        // Phát âm thanh còi khi nhấn nút
        if (hornSound != null)
        {
            hornSound.Play();
        }
    }
}
