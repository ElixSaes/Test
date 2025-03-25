using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;  // 플레이어 체력 스크립트 참조
    public Image healthFillImage;      // HP 게이지 Image (Filled 타입)

    void Start()
    {
        // 시작 시 최대 체력에 맞춰 초기화
        healthFillImage.fillAmount = 1f;
    }

    void Update()
    {
        // 현재 체력 비율에 맞춰 fillAmount 업데이트
        healthFillImage.fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
