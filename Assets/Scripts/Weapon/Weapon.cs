using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float fireRate = 1f;  // �⺻ �߻� �ӵ� (�ʴ� �߻� Ƚ��)
    protected float lastFireTime = 0f;

    // ��� ����� Fire �޼��带 �����ؾ� �մϴ�.
    public abstract void Fire();

    // ��Ÿ�� üũ�� ���� ���� �޼���
    protected bool CanFire()
    {
        return Time.time >= lastFireTime + fireRate;
    }
}
