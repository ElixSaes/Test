using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxMissiles = 5;             // �ִ� ���� �̻��� ����
    public int currentMissileCount = 0;     // ���� ���� �̻��� ����
    public float pickupRange = 3.0f;          // ������ ȹ�� ���� ���� (���� ����)

    void Update()
    {
        MissilePickup();
    }

    // F Ű �Է� ��, �÷��̾� �ֺ� ������ ���� ���� �ִ� �̻��� �������� ȹ���ϴ� ����
    private void MissilePickup()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // �÷��̾� ��ġ�� �߽����� pickupRange �ݰ� ���� ��� �ݶ��̴��� ������
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, pickupRange);

            GameObject missileToPickup = null;
            float closestDistance = Mathf.Infinity;

            // ���� ���� �ִ� �̻��� ������ �� ���� ����� ���� ã��
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

            // �̻��� �������� �����ϸ� ȹ�� ó��
            if (missileToPickup != null)
            {
                if (currentMissileCount < maxMissiles)
                {
                    currentMissileCount++;
                    missileToPickup.SetActive(false);  // ȹ���� �̻��� ��Ȱ��ȭ
                    Debug.Log("�̻��� ȹ��! ���� ���� �̻���: " + currentMissileCount);
                }
                else
                {
                    Debug.Log("�ִ� �̻��� ���� ������ �����߽��ϴ�!");
                }
            }
        }
    }
}
