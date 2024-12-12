using UnityEngine;
using UnityEngine.U2D;

public class WaveControlByTilt : MonoBehaviour
{
    [SerializeField] private float baseWaveAmplitude = 0.5f; // 波の基本高さ
    [SerializeField] private float baseWaveFrequency = 2.0f; // 波の基本周期
    [SerializeField] private float amplitudeMultiplier = 2.0f; // 高さ変化の倍率
    [SerializeField] private float frequencyMultiplier = 0.5f; // 周期変化の倍率

    [SerializeField] private Transform waveObject; // 波に浮かべるオブジェクト（オプション）

    private float waveAmplitude;
    private float waveFrequency;
    private float waveSpeed = 1.0f;
    private SpriteShapeController sc;
    private Spline spline;
    private Vector2 basePointPos;
    private int n;

    private void Start()
    {
        sc = GetComponent<SpriteShapeController>();
        spline = sc.spline;
        basePointPos = spline.GetPosition(1);
        waveAmplitude = baseWaveAmplitude;
        waveFrequency = baseWaveFrequency;

        // 必要に応じて、スプラインの初期設定
        // 例: 点数や位置の設定
        n = spline.GetPointCount();
    }

    private void Update()
    {
        // デバイスの傾き取得
        Vector3 tilt = Input.acceleration;

        // 傾きを波の高さと周期に反映
        waveAmplitude = baseWaveAmplitude + tilt.x * amplitudeMultiplier;
        waveFrequency = baseWaveFrequency + tilt.y * frequencyMultiplier;

        // 波の更新
        float time = Time.time * waveSpeed;
        for (int i = 2; i < n; i++)
        {
            Vector3 pos = spline.GetPosition(i);
            float x = basePointPos.x + i * 0.5f; // 点の間隔を適宜設定
            pos.y = waveAmplitude * Mathf.Sin(waveFrequency * x + time);
            spline.SetPosition(i, pos);
        }

        // 波の上にオブジェクトを浮かべる（オプション）
        if (waveObject != null)
        {
            Vector3 waveObjPos = waveObject.position;
            waveObjPos.y = GetWaveHeight(waveObject.position.x, time);
            waveObject.position = waveObjPos;
        }
    }

    // 指定したx位置の波の高さを取得
    private float GetWaveHeight(float x, float time)
    {
        return waveAmplitude * Mathf.Sin(waveFrequency * x + time);
    }
}
