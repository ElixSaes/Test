using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("참조 연결")]
    public PlayerHealth playerHealth;      // PlayerHealth 스크립트 참조
    public Image healthBarFill;            // HP바 게이지 Image (Filled 타입)

    void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth 참조가 연결되지 않았습니다.");
            return;
        }
        if (healthBarFill == null)
        {
            Debug.LogError("HealthBarFill Image 참조가 연결되지 않았습니다.");
            return;
        }

        // 체력 변경 이벤트에 구독
        playerHealth.OnHealthChanged += UpdateHealthBar;

        // 초기 UI 업데이트
        UpdateHealthBar(playerHealth.currentHealth, playerHealth.maxHealth);

    }

    // 체력 변경 이벤트를 통해 UI를 업데이트하는 메서드
    void UpdateHealthBar(int current, int max)
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)current / max;
        }
    }

    void OnDestroy()
    {
        // 이벤트 구독 해제
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}