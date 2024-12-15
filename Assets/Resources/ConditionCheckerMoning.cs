using UnityEngine;

public class ConditionCheckerMoning : MonoBehaviour
{
    public bool IsConditionMet { get; private set; } = false;

    private void Start()
    {
        // ���݂̃V�X�e���������擾
        System.DateTime currentTime = System.DateTime.Now;

        // ������3������6���̊ԂɊY�����邩�𔻒�
        if (currentTime.Hour >= 3 && currentTime.Hour < 6)
        {
            IsConditionMet = true;
            Debug.Log("�����𖞂����܂����B���݂̎���: " + currentTime);
        }
        else
        {
            Debug.Log("�����𖞂����Ă��܂���B���݂̎���: " + currentTime);
        }
    }
}
