using UnityEngine;
using UnityEngine.U2D;

public class WaveControlByTilt : MonoBehaviour
{
    [Header("Wave Parameters")]
    [SerializeField] private float baseWaveAmplitude = 0.5f; // 基本の波の高さ
    [SerializeField] private float baseWaveFrequency = 2.0f; // 基本の波の周期
    [SerializeField] private float tiltWaveAmplitude = 1.0f; // 傾いたときの波の高さ
    [SerializeField] private float tiltWaveFrequency = 1.5f; // 傾いたときの波の周期
    [SerializeField] private float waveSpeed = 1.0f; // 波の速度

    [Header("Tilt Settings")]
    [SerializeField] private float tiltThreshold = 0.5f; // 傾き閾値（0〜1）
    [SerializeField] private Transform waveObject; // 波に浮かべるオブジェクト（オプション）

    private float currentAmplitude;
    private float currentFrequency;
    private SpriteShapeController sc;
    private Spline spline;
    private Vector2 basePointPos;
    private int n;

    private void Start()
    {
        sc = GetComponent<SpriteShapeController>();
        spline = sc.spline;
        basePointPos = spline.GetPosition(1);
        currentAmplitude = baseWaveAmplitude;
        currentFrequency = baseWaveFrequency;

        // 必要に応じて、スプラインの初期設定
        n = spline.GetPointCount();
    }

    private void Update()
    {
        // デバイスの傾きを取得
        Vector3 tilt = Input.acceleration;

        // 傾きが閾値を超えているか判定
        if (Mathf.Abs(tilt.x) > tiltThreshold || Mathf.Abs(tilt.y) > tiltThreshold)
        {
            // 閾値を超えた場合の波パラメータ
            currentAmplitude = tiltWaveAmplitude;
            currentFrequency = tiltWaveFrequency;
        }
        else
        {
            // 通常の波パラメータ
            currentAmplitude = baseWaveAmplitude;
            currentFrequency = baseWaveFrequency;
        }

        // 波の更新
        float time = Time.time * waveSpeed;
        for (int i = 2; i < n; i++)
        {
            Vector3 pos = spline.GetPosition(i);
            float x = basePointPos.x + i * 0.5f; // 点の間隔を適宜設定
            pos.y = currentAmplitude * Mathf.Sin(currentFrequency * x + time);
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
        return currentAmplitude * Mathf.Sin(currentFrequency * x + time);
    }
}
