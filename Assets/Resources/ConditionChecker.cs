using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    public bool IsConditionMet = false;

    // �e�X�g�p: �L�[���������������B��
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsConditionMet = true;
            print("true");
        }
    }
}
