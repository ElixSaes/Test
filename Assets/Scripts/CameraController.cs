using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // 플레이어 오브젝트
    public float distance = 5.0f;
    public float sensitivity = 2.0f;
    public float fixedVerticalAngle = 10f; //고정된 수직 각도 

    private float currentX = 0; //좌우 회전을 위한 변수
    

    void Update()
    {
        // 마우스 입력으로 카메라 회전 각도 업데이트
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        
    }

    void LateUpdate()
    {
        // 플레이어를 중심으로 카메라의 위치 계산
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(fixedVerticalAngle, currentX, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }
}
