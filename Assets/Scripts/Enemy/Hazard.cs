using UnityEngine;

public class Hazard : MonoBehaviour
{
    // �÷��̾�� �� ������ �� (Inspector���� ���� ����)
    public int damage = 10;

    // Collider�� Trigger�� �����Ǿ� �־�� ��
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� "Player" �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Player"))
        {
            // �÷��̾��� PlayerHealth ������Ʈ�� ������ �������� ��
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("�÷��̾�� " + damage + " �������� �������ϴ�.");
            }
            else
            {
                Debug.LogWarning("�÷��̾� ������Ʈ�� PlayerHealth ������Ʈ�� �����ϴ�!");
            }
        }
    }
}
