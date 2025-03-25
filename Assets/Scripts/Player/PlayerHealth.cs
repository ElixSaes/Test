using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // �������� �޾� ü���� ���ҽ�Ű�� �޼���
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("������ ����: " + damageAmount + ", ���� ü��: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ü���� ȸ���ϴ� �޼���
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        Debug.Log("ȸ����: " + healAmount + ", ���� ü��: " + currentHealth);
    }

    // �÷��̾ ������� �� ó���� ����
    private void Die()
    {
        Debug.Log("�÷��̾� ���!");
        // ��: �÷��̾� ������Ʈ ��Ȱ��ȭ, ������ ó�� ��
    }
}
