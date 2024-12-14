using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundRenderer; // �w�i��SpriteRenderer
    [SerializeField] private Sprite morningBackground; // ���̔w�i�摜
    [SerializeField] private Sprite dayBackground; // ���̔w�i�摜
    [SerializeField] private Sprite eveningBackground; // �[���̔w�i�摜
    [SerializeField] private Sprite nightBackground; // ��̔w�i�摜

    void Start()
    {
        // �ŏ��̔w�i�摜��ݒ�
        backgroundRenderer.sprite = morningBackground;
    }

    void Update()
    {
        // �����Ɋ�Â��Ĕw�i��ύX�����i�����ł͒P���ȏ����ɂ��Ă��܂��j
        int hour = System.DateTime.Now.Hour;
        if (hour >= 4 && hour < 10)
        {
            backgroundRenderer.sprite = morningBackground;
        }
        else if (hour >= 10 && hour < 16)
        {
            backgroundRenderer.sprite = dayBackground;
        }
        else if (hour >= 16 && hour < 18)
        {
            backgroundRenderer.sprite = eveningBackground;
        }
        else
        {
            backgroundRenderer.sprite = nightBackground;
        }
    }
}
