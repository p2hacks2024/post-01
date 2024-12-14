using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundRenderer; // 背景のSpriteRenderer
    [SerializeField] private Sprite morningBackground; // 朝の背景画像
    [SerializeField] private Sprite dayBackground; // 昼の背景画像
    [SerializeField] private Sprite eveningBackground; // 夕方の背景画像
    [SerializeField] private Sprite nightBackground; // 夜の背景画像

    void Start()
    {
        // 最初の背景画像を設定
        backgroundRenderer.sprite = morningBackground;
    }

    void Update()
    {
        // 時刻に基づいて背景を変更する例（ここでは単純な条件にしています）
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
