using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerN : MonoBehaviour
{
    public Text messageText;

    // ���� ����� ����� �������� � ������
    public void ShowMessage()
    {
        messageText.enabled = true;
        messageText.text = "By StoryTelling team";
    }
}
