using UnityEngine;

public class ConditionCheckerMoning : MonoBehaviour
{
    public bool IsConditionMet { get; private set; } = false;

    private void Start()
    {
        // 現在のシステム時刻を取得
        System.DateTime currentTime = System.DateTime.Now;

        // 時刻が3時から6時の間に該当するかを判定
        if (currentTime.Hour >= 3 && currentTime.Hour < 6)
        {
            IsConditionMet = true;
            Debug.Log("条件を満たしました。現在の時刻: " + currentTime);
        }
        else
        {
            Debug.Log("条件を満たしていません。現在の時刻: " + currentTime);
        }
    }
}
