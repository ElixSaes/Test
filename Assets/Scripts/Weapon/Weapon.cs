using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float fireRate = 1f;       // �߻� ���� (��)
    protected float lastFireTime = 0f;

    // ���� Fire �޼���: �߻簡 �������� üũ �� ���⺰ ���� �߻� ���� ȣ��
    public void Fire()
    {

        if (CanFire())
        {
            
            lastFireTime = Time.time;
            DoFire();   // ���⺰ �߻� ���� (���� Ŭ�������� ����)
        }
        else
        {
            Debug.Log("��Ÿ�� ���Դϴ�.");
        }
    }

    // ��Ÿ�� üũ
    protected bool CanFire()
    {
        Debug.Log($"Time: {Time.time} / lastFireTime + fireRate: {lastFireTime + fireRate}");
        return Time.time >= lastFireTime + fireRate;
    }

    // ���⺰ �߻� ���� ������ �����ϱ� ���� �߻� �޼���
    protected abstract void DoFire();
}
