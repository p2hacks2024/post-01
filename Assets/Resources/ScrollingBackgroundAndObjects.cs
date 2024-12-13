using UnityEngine;

public class ScrollingBackgroundAndObjects : MonoBehaviour
{
    [SerializeField] private Transform background1; // 1枚目の背景
    [SerializeField] private Transform background2; // 2枚目の背景
    [SerializeField] private float scrollSpeed = 15f; // 背景のスクロール速度
    [SerializeField] private GameObject[] objectPrefabs; // 出現させるオブジェクトのPrefab配列
    [SerializeField] private float spawnInterval = 2f; // オブジェクトを出現させる間隔
    [SerializeField] private Transform spawnArea; // オブジェクトの出現範囲（上下位置）

    private float backgroundWidth; // 背景の幅

    void Start()
    {
        // 背景画像の幅を取得
        SpriteRenderer bgRenderer = background1.GetComponent<SpriteRenderer>();
        backgroundWidth = bgRenderer.bounds.size.x;

        // 一定時間ごとにオブジェクトを出現させる
        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    void Update()
    {
        // 背景を左にスクロール
        background1.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        background2.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 1枚目の背景が画面外に出たら位置をリセット
        if (background1.position.x <= -backgroundWidth)
        {
            background1.position += new Vector3(backgroundWidth * 2, 0, 0);
        }

        // 2枚目の背景が画面外に出たら位置をリセット
        if (background2.position.x <= -backgroundWidth)
        {
            background2.position += new Vector3(backgroundWidth * 2, 0, 0);
        }
    }

    void SpawnObject()
    {
        // 固定のX, Y座標にオブジェクトを出現させる
        float spawnX = 1.4f; // 固定のX座標
        float spawnY = 0f;  // 固定のY座標

        // ランダムにプレハブを選択
        int randomIndex = Random.Range(0, objectPrefabs.Length); // 配列の範囲内でランダムなインデックスを取得
        GameObject randomPrefab = objectPrefabs[randomIndex];

        // オブジェクトを生成
        GameObject spawnedObject = Instantiate(randomPrefab, new Vector3(background1.position.x + backgroundWidth, spawnY, 0), Quaternion.identity);

        // オブジェクトを背景と同じ速度で移動させる
        spawnedObject.AddComponent<ScrollingObject>().SetSpeed(scrollSpeed);
    }
}

public class ScrollingObject : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float scrollSpeed)
    {
        speed = scrollSpeed;
    }

    void Update()
    {
        // 背景と同じ速度で左に移動
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // 画面外に出たら削除
        if (transform.position.x < -20f) // 適切な削除位置を指定
        {
            Destroy(gameObject);
        }
    }
}
