using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // 移動させるカメラ
    public Camera targetCamera;

    // 移動量（Y軸方向）
    public float moveDistance = 5f;

    // 移動時間（秒）
    public float moveDuration = 2f;

    private bool isMoving = false; // 移動中かどうか
    private float elapsedTime = 0f; // 経過時間
    private Vector3 startPosition; // 開始位置
    private Vector3 targetPosition; // 目標位置

    private bool isWaiting = true; // 待機中かどうか
    private float waitTime = 0.8f; // 待機時間（秒）

    void Start()
    {
        if (targetCamera == null)
        {
            // カメラが指定されていなければ、自分のカメラを使用
            targetCamera = Camera.main;
        }

        // 初期位置と目標位置を設定
        startPosition = targetCamera.transform.position;
        targetPosition = startPosition + new Vector3(0, moveDistance, 0); // Y軸方向に移動
    }

    void Update()
    {
        if (isWaiting)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                isWaiting = false;
                isMoving = true;
            }
            return;
        }

        if (isMoving)
        {
            UpdateMove();
        }
    }

    void UpdateMove()
    {
        if (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration; // 時間に応じた進行度（0～1）
            targetCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, t); // スムーズに移動
        }
        else
        {
            targetCamera.transform.position = targetPosition; // 最終位置を確定
            isMoving = false; // 移動終了
        }
    }
}
