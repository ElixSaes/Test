using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private bool isRunning = false; // 달리기 상태

    public Transform cameraTransform;  // 카메라 오브젝트 참조

    void Update()
    {
        RunningInput(); // Shift 토글 확인 메서드
        Movement();     // 이동 메서드
    }

    // 달리기 입력 처리: Shift 키 토글
    private void RunningInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
        }
    }

    // 이동 입력 처리 및 플레이어 이동
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

        // 이동 입력이 없으면 달리기 상태 해제
        if (inputDirection.magnitude < 0.1f)
        {
            isRunning = false;
            return;
        }

        // 카메라의 forward 및 right 벡터를 기준으로 이동 방향 결정
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

        // 현재 속도 결정
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        // 플레이어 이동 및 회전 처리
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
