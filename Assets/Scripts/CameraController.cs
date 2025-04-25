using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // �÷��̾� ������Ʈ
    public float distance = 5.0f;
    public float sensitivity = 2.0f;
    public float fixedVerticalAngle = 10f; //������ ���� ���� 

    private float currentX = 0; //�¿� ȸ���� ���� ����
    

    void Update()
    {
        // ���콺 �Է����� ī�޶� ȸ�� ���� ������Ʈ
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        
    }

    void LateUpdate()
    {
        // �÷��̾ �߽����� ī�޶��� ��ġ ���
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(fixedVerticalAngle, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }
}
