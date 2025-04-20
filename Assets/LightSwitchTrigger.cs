using UnityEngine;

public class LightSwitchTrigger : MonoBehaviour
{
    public GameObject darkOverlay;
    public SpriteRenderer switchSprite;
    public Color lightOnColor = Color.white;   // 밝을 때 (기본 상태)
    public Color lightOffColor = Color.black;  // 어두워질 때

    private bool isDark = false;  // 시작은 밝음!

    private void Start()
    {
        // 안전하게 초기 상태 설정
        darkOverlay.SetActive(false);
        switchSprite.color = lightOnColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isDark = !isDark;

            // 어두운 화면 켜고 끄기
            darkOverlay.SetActive(isDark);

            // 버튼 색상도 전환
            switchSprite.color = isDark ? lightOffColor : lightOnColor;
        }
    }
}
