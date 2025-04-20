using UnityEngine;
using System.Collections;

public class RockGateOpener : MonoBehaviour
{
    public float moveDistance = 1f;     // 이동 거리
    public float moveSpeed = 1.5f;      // 이동 속도

    private bool isPlayerInRange = false;
    private bool isOpened = false;
    private bool isMoving = false;

    private Vector3 closedPosition;
    private Vector3 openedPosition;

    void Start()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + Vector3.left * moveDistance;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
            if (!isOpened)
            {
                StartCoroutine(MoveRock(openedPosition));
                isOpened = true;
            }
            else
            {
                StartCoroutine(MoveRock(closedPosition));
                isOpened = false;
            }
        }
    }

    IEnumerator MoveRock(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false; // 이동 완료 후 다시 입력 가능
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
