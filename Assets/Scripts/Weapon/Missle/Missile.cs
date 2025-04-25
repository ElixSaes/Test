using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10f;       // �̻��� �̵� �ӵ�
    public float damage = 0f;        // ������ (�߰���)
    private Vector3 direction;      // �̻����� �̵��� ����

    void Update()
    {
        // ������ �������� ���� �̵�
        transform.position += direction * speed * Time.deltaTime;
    }

    // �ܺο��� �̵��� ������ �����ϴ� �޼���
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
        Debug.Log("�̻��� ����: " + direction);
    }

    public void SetStats(float mSpeed, float mDamage)
    {
        speed = mSpeed;
        damage = mDamage;
        Debug.Log($"�̻��� ���� ������ �� �ӵ�: {speed}, ������: {damage}");

    }
}
