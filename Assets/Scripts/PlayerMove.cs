using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private bool isRunning = false; // �޸��� ����

    public Transform cameraTransform;  // ī�޶� ������Ʈ ����

    void Update()
    {
        RunningInput(); // Shift ��� Ȯ�� �޼���
        Movement();     // �̵� �޼���
    }

    // �޸��� �Է� ó��: Shift Ű ���
    private void RunningInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
        }
    }

    // �̵� �Է� ó�� �� �÷��̾� �̵�
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

        // �̵� �Է��� ������ �޸��� ���� ����
        if (inputDirection.magnitude < 0.1f)
        {
            isRunning = false;
            return;
        }

        // ī�޶��� forward �� right ���͸� �������� �̵� ���� ����
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

        // ���� �ӵ� ����
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // �÷��̾� �̵� �� ȸ�� ó��
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
