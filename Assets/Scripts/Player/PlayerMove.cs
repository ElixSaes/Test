using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    private bool isRunning = false; // 달리기 상태

    public Transform cameraTransform;  // 카메라 오브젝트 참조

    // 대쉬 관련 변수들
    public float dashDistance;      // 대쉬 거리
    public float dashDuration;     // 대쉬 지속 시간
    public float doubleTapThreshold = 0.3f;  // 스페이스바 더블 탭 허용 시간

    private float lastSpacePressTime = 0f; // 마지막 스페이스바 누른 시간
    private bool isDashing = false;        // 대쉬 중인지 여부

    private void Start()
    {
        var cfg = ConfigLoader.Config;

        // config에서 대쉬 관련 값을 적용
        dashDistance = cfg.dashDistance;
        dashDuration = cfg.dashDuration;

        Debug.Log($"[Config 적용] dashDistance: {dashDistance}, dashDuration: {dashDuration}");
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
    // 스페이스바 더블 탭 감지하여 대쉬 실행
    private void DashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 이전 스페이스바 누름과의 간격 체크
            if (Time.time - lastSpacePressTime <= doubleTapThreshold)
            {
                // 이동 입력 방향이 있는 경우 대쉬 실행
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector3 inputDirection = new Vector3(horizontal, 0, vertical);

                if (inputDirection.magnitude >= 0.1f)
                {
                    // 카메라 기준으로 대쉬 방향 계산
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

    // 대쉬 코루틴: 일정 시간 동안 대쉬 방향으로 빠르게 이동
    private IEnumerator Dash(Vector3 direction)
    {
        isDashing = true;
        float startTime = Time.time;
        // 대쉬 속도는 dashDistance를 dashDuration으로 나눈 값
        float dashSpeed = dashDistance / dashDuration;

        while (Time.time < startTime + dashDuration)
        {
            transform.position += direction * dashSpeed * Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
}
