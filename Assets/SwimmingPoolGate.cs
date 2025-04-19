using UnityEngine;

public class SwimmingPoolGate : MonoBehaviour
{
    public GameObject swimmingPoolBlocker; // 차단 벽
    public Transform player;               // 플레이어 Transform
    public string followerName = "Plant 0"; // 따라다니는 새싹 이름

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bool hasPlant = false;

            // 새싹이 플레이어 자식으로 붙어있는지 검사
            foreach (Transform child in player)
            {
                if (child.name == followerName)
                {
                    hasPlant = true;
                    break;
                }
            }

            if (hasPlant)
            {
                swimmingPoolBlocker.SetActive(false); // 차단 해제
                Debug.Log("🌱 새싹이 있어서 수영장 입장 가능!");
            }
            else
            {
                swimmingPoolBlocker.SetActive(true); // 차단 유지
                Debug.Log("❌ 새싹 없어서 입장 불가");
            }
        }
    }
}
