using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int CurrentHealth => currentHealth;

    // 체력이 변경될 때마다 (현재 체력, 최대 체력)을 전달하는 이벤트
    public event Action<int, int> OnHealthChanged;

    void Start()
    {
        maxHealth = ConfigLoader.Config.maxHealth;
        currentHealth = maxHealth;
        // 초기 UI 업데이트를 위해 이벤트 호출
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // 데미지를 받으면 체력을 감소시키고, 체력이 0 이하가 되면 사망 처리
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("데미지: " + damage + " / 남은 체력: " + currentHealth);
        // 체력이 변경될 때마다 이벤트 호출
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 체력을 회복하는 메서드
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        Debug.Log("회복됨: " + healAmount + ", 현재 체력: " + currentHealth);
    }

    // 플레이어가 사망했을 때 처리할 로직
    private void Die()
    {
        Debug.Log("플레이어 사망!");
        // 예: 플레이어 오브젝트 비활성화, 리스폰 처리 등
    }

    public void SetHealth(int newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        Debug.Log("체력 로드 적용됨: " + currentHealth);
    }
}
