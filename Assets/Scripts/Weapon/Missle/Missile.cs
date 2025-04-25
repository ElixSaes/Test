using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10f;       // 미사일 이동 속도
    public float damage = 0f;        // 데미지 (추가됨)
    private Vector3 direction;      // 미사일이 이동할 방향

    void Update()
    {
        // 지정된 방향으로 직선 이동
        transform.position += direction * speed * Time.deltaTime;
    }

    // 외부에서 이동할 방향을 설정하는 메서드
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
        Debug.Log("미사일 방향: " + direction);
    }

    public void SetStats(float mSpeed, float mDamage)
    {
        speed = mSpeed;
        damage = mDamage;
        Debug.Log($"미사일 스탯 설정됨 → 속도: {speed}, 데미지: {damage}");

    }
}
