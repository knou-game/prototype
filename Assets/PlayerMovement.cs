using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 설정

    private Vector2 moveInput; // 입력값 저장
    private Rigidbody2D rb; // Rigidbody2D 변수
    private Animator anim; // Animator 변수
    private Vector2 lastMoveDirection; // 마지막 이동 방향 저장

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 연결
        anim = GetComponent<Animator>(); // Animator 연결
    }

    void Update()
    {
        // WASD 또는 방향키 입력값 받기
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D 또는 ← →
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S 또는 ↑ ↓

        moveInput = moveInput.normalized; // 대각선 이동 시 속도 일정하게 유지

        // 이동 중인지 여부 판단
        bool IsMoving = moveInput.magnitude > 0.01f;

        // IsMoving 값 전달 : Animator에서 Idle <-> Walk 전환용
        anim.SetBool("IsMoving", IsMoving);

        if (IsMoving)
        {
            // 이동 중이면 현재 방향을 Animator에 전달
            anim.SetFloat("MoveX", moveInput.x);
            anim.SetFloat("MoveY", moveInput.y);

            // 마지막 이동 방향 기억
            anim.SetFloat("LastMoveX", moveInput.x);
            anim.SetFloat("LastMoveY", moveInput.y);
        }
        else
        {
            // 멈췄을 때는 마지막 방향을 다시 전달
            anim.SetFloat("MoveX", anim.GetFloat("LastMoveX"));
            anim.SetFloat("MoveY", anim.GetFloat("LastMoveY"));
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용한 물리 이동 적용
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
