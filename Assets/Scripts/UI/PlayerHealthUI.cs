using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("���� ����")]
    public PlayerHealth playerHealth;      // PlayerHealth ��ũ��Ʈ ����
    public Image healthBarFill;            // HP�� ������ Image (Filled Ÿ��)

    void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth ������ ������� �ʾҽ��ϴ�.");
            return;
        }
        if (healthBarFill == null)
        {
            Debug.LogError("HealthBarFill Image ������ ������� �ʾҽ��ϴ�.");
            return;
        }

        // ü�� ���� �̺�Ʈ�� ����
        playerHealth.OnHealthChanged += UpdateHealthBar;

        // �ʱ� UI ������Ʈ
        UpdateHealthBar(playerHealth.currentHealth, playerHealth.maxHealth);

    }

    // ü�� ���� �̺�Ʈ�� ���� UI�� ������Ʈ�ϴ� �޼���
    void UpdateHealthBar(int current, int max)
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)current / max;
        }
    }

    void OnDestroy()
    {
        // �̺�Ʈ ���� ����
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}