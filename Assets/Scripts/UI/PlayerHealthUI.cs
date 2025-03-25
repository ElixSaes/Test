using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;  // �÷��̾� ü�� ��ũ��Ʈ ����
    public Image healthFillImage;      // HP ������ Image (Filled Ÿ��)

    void Start()
    {
        // ���� �� �ִ� ü�¿� ���� �ʱ�ȭ
        healthFillImage.fillAmount = 1f;
    }

    void Update()
    {
        // ���� ü�� ������ ���� fillAmount ������Ʈ
        healthFillImage.fillAmount = (float)playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
