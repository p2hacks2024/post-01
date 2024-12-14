using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundRenderer; // ”wŒi‚ÌSpriteRenderer
    [SerializeField] private Sprite morningBackground; // ’©‚Ì”wŒi‰æ‘œ
    [SerializeField] private Sprite dayBackground; // ’‹‚Ì”wŒi‰æ‘œ
    [SerializeField] private Sprite eveningBackground; // —[•û‚Ì”wŒi‰æ‘œ
    [SerializeField] private Sprite nightBackground; // –é‚Ì”wŒi‰æ‘œ

    void Start()
    {
        // Å‰‚Ì”wŒi‰æ‘œ‚ðÝ’è
        backgroundRenderer.sprite = morningBackground;
    }

    void Update()
    {
        // Žž‚ÉŠî‚Ã‚¢‚Ä”wŒi‚ð•ÏX‚·‚é—ái‚±‚±‚Å‚Í’Pƒ‚ÈðŒ‚É‚µ‚Ä‚¢‚Ü‚·j
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
