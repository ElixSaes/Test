using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float fireRate = 1f;       // 발사 간격 (초)
    protected float lastFireTime = 0f;

    // 공통 Fire 메서드: 발사가 가능한지 체크 후 무기별 세부 발사 로직 호출
    public void Fire()
    {

        if (CanFire())
        {
            
            lastFireTime = Time.time;
            DoFire();   // 무기별 발사 로직 (하위 클래스에서 구현)
        }
        else
        {
            Debug.Log("쿨타임 중입니다.");
        }
    }

    // 쿨타임 체크
    protected bool CanFire()
    {
        Debug.Log($"Time: {Time.time} / lastFireTime + fireRate: {lastFireTime + fireRate}");
        return Time.time >= lastFireTime + fireRate;
    }

    // 무기별 발사 세부 동작을 구현하기 위한 추상 메서드
    protected abstract void DoFire();
}
