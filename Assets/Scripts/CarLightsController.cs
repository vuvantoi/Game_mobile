using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI Button

public class CarLightsController : MonoBehaviour
{
    [Header("Car Lights")]
    public Light leftWarningLight; // Đèn cảnh báo bên trái
    public Light rightWarningLight; // Đèn cảnh báo bên phải
    public float flashInterval = 0.5f; // Thời gian giữa các lần chớp

    public Light leftLight;  // Đèn dọi đường trái
    public Light rightLight; // Đèn dọi đường phải

    private bool isWarningLightsOn = false; // Trạng thái bật/tắt đèn cảnh báo
    private float flashTimer = 0f;
    private bool isLeftLightOn = false; // Trạng thái đèn trái
    private bool isRightLightOn = false; // Trạng thái đèn phải

    private bool areLightsOn = false; // Trạng thái bật/tắt đèn dọi đường

    void Update()
    {
        // Nếu đèn cảnh báo đang bật, xử lý nhấp nháy
        if (isWarningLightsOn)
        {
            flashTimer += Time.deltaTime;

            // Nếu đã đến thời gian thay phiên chớp đèn
            if (flashTimer >= flashInterval)
            {
                flashTimer = 0f;

                // Đảo trạng thái của hai đèn (chớp thay phiên)
                if (isLeftLightOn)
                {
                    // Nếu đèn trái bật, tắt nó và bật đèn phải
                    isLeftLightOn = false;
                    isRightLightOn = true;
                }
                else
                {
                    // Nếu đèn phải bật, tắt nó và bật đèn trái
                    isLeftLightOn = true;
                    isRightLightOn = false;
                }

                // Cập nhật trạng thái của đèn cảnh báo
                leftWarningLight.enabled = isLeftLightOn;
                rightWarningLight.enabled = isRightLightOn;
            }
        }
        else
        {
            // Tắt cả hai đèn cảnh báo nếu cảnh báo không bật
            leftWarningLight.enabled = false;
            rightWarningLight.enabled = false;
        }
    }

    // Hàm được gọi khi nhấn button UI (để bật/tắt đèn cảnh báo)
    public void ToggleWarningLights()
    {
        // Bật hoặc tắt trạng thái cảnh báo
        isWarningLightsOn = !isWarningLightsOn;

        // Nếu bật, bắt đầu với đèn trái bật và đèn phải tắt
        if (isWarningLightsOn)
        {
            isLeftLightOn = true;
            isRightLightOn = false;

            leftWarningLight.enabled = true;
            rightWarningLight.enabled = false;
        }
        else
        {
            // Nếu tắt, tắt cả hai đèn
            leftWarningLight.enabled = false;
            rightWarningLight.enabled = false;
        }
    }

    // Hàm bật/tắt đèn dọi đường khi nhấn một nút UI khác
    public void OnOffLight()
    {
        // Nếu đèn dọi đường không phải là trạng thái hiện tại thì bật/tắt
        if (areLightsOn)
        {
            // Bật đèn
            leftLight.enabled = false;
            rightLight.enabled = false;
        }
        else
        {
            // Tắt đèn
            leftLight.enabled = true;
            rightLight.enabled = true;
        }

        // Đảo trạng thái
        areLightsOn = !areLightsOn;
    }
}
