using UnityEngine;

public class MissileLauncher : Weapon
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public PlayerInventory playerInventory; // 플레이어 인벤토리 참조

    public float missileSpeed; // 미사일 개별 속도
    public float missileDamage;
    private bool isAiming = false;         // 조준 모드 상태

    void Start()
    {
        missileSpeed = ConfigLoader.Config.missileSpeed;
        missileDamage = ConfigLoader.Config.missileDamage;
    }

    void Update()
    {
        // 우클릭을 누른 상태에서 조준 모드 유지
        isAiming = Input.GetMouseButton(1);

        // 조준 모드에서 좌클릭 입력 시 미사일 발사
        if (isAiming && Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    protected override void DoFire()
    {
        
        // 미사일 보유 개수가 있고, 쿨타임이 지났을 때만 발사
        if (playerInventory.currentMissileCount > 0)
        {
            
            // 미사일 프리팹 생성 (spawnPoint의 위치와 회전 사용)
            GameObject missileInstance = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
            Missile missileScript = missileInstance.GetComponent<Missile>();
            if (missileScript != null)
            {
                // 미사일은 spawnPoint의 forward 방향으로 발사됨
                missileScript.SetDirection(missileSpawnPoint.forward);
                missileScript.SetStats(missileSpeed, missileDamage); // ← JSON 값 전달
            }

            // 발사 후 보유 미사일 수 감소
            playerInventory.currentMissileCount--;
            Debug.Log("미사일 발사됨. 남은 미사일: " + playerInventory.currentMissileCount);
        }
        else
        {
            Debug.Log("남은 미사일이 없습니다.");
        }
    }
}

