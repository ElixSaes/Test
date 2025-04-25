using UnityEngine;

public class MissileLauncher : Weapon
{
    public GameObject missilePrefab;
    public Transform missileSpawnPoint;
    public PlayerInventory playerInventory; // �÷��̾� �κ��丮 ����

    public float missileSpeed; // �̻��� ���� �ӵ�
    public float missileDamage;
    private bool isAiming = false;         // ���� ��� ����

    void Start()
    {
        missileSpeed = ConfigLoader.Config.missileSpeed;
        missileDamage = ConfigLoader.Config.missileDamage;
    }

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
                missileScript.SetStats(missileSpeed, missileDamage); // �� JSON �� ����
            }

            // �߻� �� ���� �̻��� �� ����
            playerInventory.currentMissileCount--;
            Debug.Log("�̻��� �߻��. ���� �̻���: " + playerInventory.currentMissileCount);
        }
        else
        {
            Debug.Log("���� �̻����� �����ϴ�.");
        }
    }
}

