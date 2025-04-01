using UnityEngine;

public class Hazard : MonoBehaviour
{
    // 플레이어에게 줄 데미지 양 (Inspector에서 조절 가능)
    public int damage = 10;

    // Collider가 Trigger로 설정되어 있어야 함
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 "Player" 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            // 플레이어의 PlayerHealth 컴포넌트를 가져와 데미지를 줌
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("플레이어에게 " + damage + " 데미지를 입혔습니다.");
            }
            else
            {
                Debug.LogWarning("플레이어 오브젝트에 PlayerHealth 컴포넌트가 없습니다!");
            }
        }
    }
}
