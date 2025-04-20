using UnityEngine;
using TMPro;

public class DeskInteraction : MonoBehaviour
{
    public GameObject messagePanel;       // 패널 오브젝트
    public TextMeshProUGUI messageText;   // 텍스트 컴포넌트
    public string message = "책상 위에 먼지가 소복히 쌓여 있다.";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageText.text = message;
            messagePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messagePanel.SetActive(false);
        }
    }
}
