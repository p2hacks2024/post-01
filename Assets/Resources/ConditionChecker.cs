using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    public bool IsConditionMet = false;

    // テスト用: キーを押したら条件を達成
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsConditionMet = true;
            print("true");
        }
    }
}
