using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("카메라가 따라갈 대상")]
    public Transform target;

    [Header("카메라 이동 속도")]
    public float smoothSpeed = 5f;

    [Header("카메라 위치 오프셋")]
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Z값 유지

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
