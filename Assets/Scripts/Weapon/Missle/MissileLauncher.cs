using UnityEngine;

public class MissileLauncher : Weapon
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public PlayerInventory playerInventory; // �÷��̾� �κ��丮 ����

    public float missileSpeed = 10f; // �̻��� ���� �ӵ�
    private bool isAiming = false;         // ���� ��� ����

    void Update()
    {
        // ��Ŭ���� ���� ���¿��� ���� ��� ����
        isAiming = Input.GetMouseButton(1);

        // ���� ��忡�� ��Ŭ�� �Է� �� �̻��� �߻�
        if (isAiming && Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    protected override void DoFire()
    {
        
        // �̻��� ���� ������ �ְ�, ��Ÿ���� ������ ���� �߻�
        if (playerInventory.currentMissileCount > 0)
        {
            
            // �̻��� ������ ���� (spawnPoint�� ��ġ�� ȸ�� ���)
            GameObject missileInstance = Instantiate(missilePrefab, missileSpawnPoint.position, missileSpawnPoint.rotation);
            Missile missileScript = missileInstance.GetComponent<Missile>();
            if (missileScript != null)
            {
                // �̻����� spawnPoint�� forward �������� �߻��
                missileScript.SetDirection(missileSpawnPoint.forward);
            }

            // �߻� �� ���� �̻��� �� ���� �� �߻� �ð� ���
            playerInventory.currentMissileCount--;
            lastFireTime = Time.time;
            Debug.Log("�̻��� �߻��. ���� �̻���: " + playerInventory.currentMissileCount);
        }
        else
        {
            Debug.Log("���� �̻����� �����ϴ�.");
        }
    }
}

