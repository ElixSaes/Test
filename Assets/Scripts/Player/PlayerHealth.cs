using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // ü���� ����� ������ (���� ü��, �ִ� ü��)�� �����ϴ� �̺�Ʈ
    public event Action<int, int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        // �ʱ� UI ������Ʈ�� ���� �̺�Ʈ ȣ��
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // �������� ������ ü���� ���ҽ�Ű��, ü���� 0 ���ϰ� �Ǹ� ��� ó��
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("������: " + damage + " / ���� ü��: " + currentHealth);
        // ü���� ����� ������ �̺�Ʈ ȣ��
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ü���� ȸ���ϴ� �޼���
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        Debug.Log("ȸ����: " + healAmount + ", ���� ü��: " + currentHealth);
    }

    // �÷��̾ ������� �� ó���� ����
    private void Die()
    {
        Debug.Log("�÷��̾� ���!");
        // ��: �÷��̾� ������Ʈ ��Ȱ��ȭ, ������ ó�� ��
    }
}
