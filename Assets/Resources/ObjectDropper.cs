using System.Collections;
using UnityEngine;

public class ObjectDropper : MonoBehaviour
{
    // �O���X�N���v�g��������B���̏�Ԃ��擾
    public ConditionChecker conditionChecker;

    // �\��������I�u�W�F�N�g
    public GameObject targetObject;

    // �ŏI�I�ɒ�~������W
    public Vector2 targetPosition = new Vector2(0, 4);

    // ��x���������B�����L�^���邽�߂̃t���O
    private bool hasTriggered = false;

    // �I�u�W�F�N�g�̈ړ����x
    public float dropSpeed = 5f;

    private void Start()
    {
        // �ŏ��̓I�u�W�F�N�g���\���ɂ��Ă���
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void Update()
    {
        // �������B������A�܂��I�u�W�F�N�g������Ă��Ȃ��ꍇ
        if (conditionChecker != null && conditionChecker.IsConditionMet && !hasTriggered)
        {
            hasTriggered = true; // ��x������������悤�Ƀt���O��ݒ�
            StartCoroutine(ShowAndDropObject());
        }
    }

    private IEnumerator ShowAndDropObject()
    {
        // �I�u�W�F�N�g���A�N�e�B�u�ɂ���i�\������j
        if (targetObject != null)
        {
            targetObject.SetActive(true);

            // �����ʒu����ʊO�i��j�ɐݒ�
            targetObject.transform.position = new Vector2(targetPosition.x, 10); // y=10�͉�ʊO�̉��̒l

            // �I�u�W�F�N�g���ړ�������
            while (Vector2.Distance(targetObject.transform.position, targetPosition) > 0.1f)
            {
                targetObject.transform.position = Vector2.MoveTowards(
                    targetObject.transform.position,
                    targetPosition,
                    dropSpeed * Time.deltaTime
                );
                yield return null; // ���̃t���[���܂őҋ@
            }

            // �ŏI�ʒu�ɐ��m�ɍ��킹��
            targetObject.transform.position = targetPosition;
        }
    }
}
