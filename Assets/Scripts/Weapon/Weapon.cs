using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float fireRate = 1f;  // 기본 발사 속도 (초당 발사 횟수)
    protected float lastFireTime = 0f;

    // 모든 무기는 Fire 메서드를 구현해야 합니다.
    public abstract void Fire();

    // 쿨타임 체크를 위한 공통 메서드
    protected bool CanFire()
    {
        return Time.time >= lastFireTime + fireRate;
    }
}
