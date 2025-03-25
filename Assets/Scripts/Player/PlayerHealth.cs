using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // 데미지를 받아 체력을 감소시키는 메서드
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("데미지 받음: " + damageAmount + ", 남은 체력: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력을 회복하는 메서드
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        Debug.Log("회복됨: " + healAmount + ", 현재 체력: " + currentHealth);
    }

    // 플레이어가 사망했을 때 처리할 로직
    private void Die()
    {
        Debug.Log("플레이어 사망!");
        // 예: 플레이어 오브젝트 비활성화, 리스폰 처리 등
    }
}
