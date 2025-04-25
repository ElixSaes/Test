using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private bool isRunning = false; // �޸��� ����

    public Transform cameraTransform;  // ī�޶� ������Ʈ ����

    // �뽬 ���� ������
    public float dashDistance;      // �뽬 �Ÿ�
    public float dashDuration;     // �뽬 ���� �ð�
    public float doubleTapThreshold = 0.3f;  // �����̽��� ���� �� ��� �ð�

    private float lastSpacePressTime = 0f; // ������ �����̽��� ���� �ð�
    private bool isDashing = false;        // �뽬 ������ ����

    private void Start()
    {
        var cfg = ConfigLoader.Config;

        // config���� �뽬 ���� ���� ����
        dashDistance = cfg.dashDistance;
        dashDuration = cfg.dashDuration;

        Debug.Log($"[Config ����] dashDistance: {dashDistance}, dashDuration: {dashDuration}");
    }

    void Update()
    {
        if (!isDashing)
        {
            RunningInput();
            Movement();
            DashInput();
        }
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
    // �����̽��� ���� �� �����Ͽ� �뽬 ����
    private void DashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���� �����̽��� �������� ���� üũ
            if (Time.time - lastSpacePressTime <= doubleTapThreshold)
            {
                // �̵� �Է� ������ �ִ� ��� �뽬 ����
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

                if (inputDirection.magnitude >= 0.1f)
                {
                    // ī�޶� �������� �뽬 ���� ���
                    Vector3 cameraForward = cameraTransform.forward;
                    cameraForward.y = 0;
                    cameraForward.Normalize();

                    Vector3 cameraRight = cameraTransform.right;
                    cameraRight.y = 0;
                    cameraRight.Normalize();

                    Vector3 dashDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;
                    StartCoroutine(Dash(dashDirection));
                }
            }
            lastSpacePressTime = Time.time;
        }
    }

    // �뽬 �ڷ�ƾ: ���� �ð� ���� �뽬 �������� ������ �̵�
    private IEnumerator Dash(Vector3 direction)
    {
        isDashing = true;
        float startTime = Time.time;
        // �뽬 �ӵ��� dashDistance�� dashDuration���� ���� ��
        float dashSpeed = dashDistance / dashDuration;

        while (Time.time < startTime + dashDuration)
        {
            transform.position += direction * dashSpeed * Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
}
