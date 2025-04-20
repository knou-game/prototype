using UnityEngine;

public class PlantFollower : MonoBehaviour
{
    private bool isFollowing = false;
    public Transform target;
    public Vector3 offset = new Vector3(0.5f, 0.5f, 0); // 따라다니는 위치

    void Update()
    {
        if (isFollowing && target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isFollowing && other.CompareTag("Player"))
        {
            target = other.transform;
            isFollowing = true;

            // 새싹을 플레이어 자식으로 만들기
            transform.SetParent(target);
        }
    }
}
