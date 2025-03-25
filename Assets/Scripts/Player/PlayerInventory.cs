using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxMissiles = 5;             // 최대 보유 미사일 개수
    public int currentMissileCount = 0;     // 현재 보유 미사일 개수
    public float pickupRange = 3.0f;          // 아이템 획득 가능 범위 (미터 단위)

    void Update()
    {
        MissilePickup();
    }

    // F 키 입력 시, 플레이어 주변 지정된 범위 내에 있는 미사일 아이템을 획득하는 로직
    private void MissilePickup()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 플레이어 위치를 중심으로 pickupRange 반경 내의 모든 콜라이더를 가져옴
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, pickupRange);

            GameObject missileToPickup = null;
            float closestDistance = Mathf.Infinity;

            // 범위 내에 있는 미사일 아이템 중 가장 가까운 것을 찾음
            foreach (Collider collider in collidersInRange)
            {
                if (collider.CompareTag("Missile"))
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        missileToPickup = collider.gameObject;
                    }
                }
            }

            // 미사일 아이템이 존재하면 획득 처리
            if (missileToPickup != null)
            {
                if (currentMissileCount < maxMissiles)
                {
                    currentMissileCount++;
                    missileToPickup.SetActive(false);  // 획득한 미사일 비활성화
                    Debug.Log("미사일 획득! 현재 보유 미사일: " + currentMissileCount);
                }
                else
                {
                    Debug.Log("최대 미사일 보유 개수에 도달했습니다!");
                }
            }
        }
    }
}
