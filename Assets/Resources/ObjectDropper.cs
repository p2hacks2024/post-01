using System.Collections;
using UnityEngine;

public class ObjectDropper : MonoBehaviour
{
    // 外部スクリプトから条件達成の状態を取得
    public ConditionChecker conditionChecker;

    // 表示させるオブジェクト
    public GameObject targetObject;

    // 最終的に停止する座標
    public Vector2 targetPosition = new Vector2(0, 4);

    // 一度だけ条件達成を記録するためのフラグ
    private bool hasTriggered = false;

    // オブジェクトの移動速度
    public float dropSpeed = 5f;

    private void Start()
    {
        // 最初はオブジェクトを非表示にしておく
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void Update()
    {
        // 条件が達成され、まだオブジェクトが現れていない場合
        if (conditionChecker != null && conditionChecker.IsConditionMet && !hasTriggered)
        {
            hasTriggered = true; // 一度だけ処理するようにフラグを設定
            StartCoroutine(ShowAndDropObject());
        }
    }

    private IEnumerator ShowAndDropObject()
    {
        // オブジェクトをアクティブにする（表示する）
        if (targetObject != null)
        {
            targetObject.SetActive(true);

            // 初期位置を画面外（上）に設定
            targetObject.transform.position = new Vector2(targetPosition.x, 10); // y=10は画面外の仮の値

            // オブジェクトを移動させる
            while (Vector2.Distance(targetObject.transform.position, targetPosition) > 0.1f)
            {
                targetObject.transform.position = Vector2.MoveTowards(
                    targetObject.transform.position,
                    targetPosition,
                    dropSpeed * Time.deltaTime
                );
                yield return null; // 次のフレームまで待機
            }

            // 最終位置に正確に合わせる
            targetObject.transform.position = targetPosition;
        }
    }
}
