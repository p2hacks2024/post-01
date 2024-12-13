using UnityEngine;
using UnityEngine.U2D;

public class Water : MonoBehaviour
{
    private SpriteShapeController sc;
    private Spline spline;
    private float scale;
    private Vector2 basePointPos;
    private int n;
    [SerializeField] private float interval = 0.1f;
    [SerializeField] private float basewaveAmplitude = 0.5f; // ”g‚Ì‚‚³
    [SerializeField] private float basewaveFrequency = 0.5f;  // ”g‚ÌüŠú
    [SerializeField] private float basewaveSpeed = 0.5f;     // ”g‚Ì“®‚­‘¬‚³
    [SerializeField] private Transform waveObject;
    [SerializeField] private float amplitudeMultiplier = 2.0f; // ‚‚³•Ï‰»‚Ì”{—¦
    [SerializeField] private float frequencyMultiplier = 0.5f; // üŠú•Ï‰»‚Ì”{—¦
    public SpriteShapeRenderer spriteShapeRenderer;
    private float waveAmplitude;
    private float waveFrequency;
    private float waveSpeed;


    private void Start()
    {
        sc = GetComponent<SpriteShapeController>();
        spline = sc.spline;
        basePointPos = spline.GetPosition(1);
        scale = transform.localScale.x;
        n = (int)(-basePointPos.x * scale * 2 / interval) + 1;

        if (spriteShapeRenderer != null)
        {
            spriteShapeRenderer.enabled = false;
        }

        // ”g‚Ì“_‚ğ”z’u
        Vector3 p = basePointPos;
        for (int i = 2; i < n; i++)
        {
            p += interval * Vector3.right / scale;
            spline.InsertPointAt(i, p);
            spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spline.SetLeftTangent(i, 0.1f * interval * Vector3.left / scale);
            spline.SetRightTangent(i, 0.1f * interval * Vector3.right / scale);
            spline.SetHeight(i, 0.1f);
        }

    }

    private void Update()
    {
        Vector3 tilt = Input.acceleration;
        waveAmplitude = basewaveAmplitude;
        waveFrequency = basewaveFrequency - tilt.x;
        waveSpeed = basewaveSpeed;
        float time = Time.time * basewaveSpeed;

        for (int i = 2; i < n; i++)
        {
            Vector3 pos = spline.GetPosition(i);
            float x = basePointPos.x + interval * (i - 2);
            pos.y = 0.5f * waveAmplitude * Mathf.Sin(waveFrequency * x + time) * 0.25f; // sin”g
            spline.SetPosition(i, pos);

        }
        

    }
    public float GetWaveHeight(float x, float time)
    {
        return waveAmplitude * Mathf.Sin(waveFrequency * x + time);
    }

    public void BaseWave()
    {
        float time = Time.time * basewaveSpeed;
        waveAmplitude = basewaveAmplitude;
        waveFrequency = basewaveFrequency;
        waveSpeed = basewaveSpeed;

        for (int i = 2; i < n; i++)
        {
            Vector3 pos = spline.GetPosition(i);
            float x = basePointPos.x + interval * (i - 2);
            pos.y = 0.5f * waveAmplitude * Mathf.Sin(waveFrequency * x + time) * 0.25f; // sin”g
            spline.SetPosition(i, pos);

        }
        if (waveObject != null)
        {
            Vector3 waveObjPos = waveObject.position;
            waveObjPos.y = GetWaveHeight(waveObject.position.x, time + 1) - 0.25f; // ”g‚Ì‚‚³‚ğæ“¾
            waveObject.position = waveObjPos;
        }
    }

    public void Wave1()
    {
        float time = Time.time * basewaveSpeed;
        waveAmplitude = basewaveAmplitude * 3.0f;
        waveFrequency = basewaveFrequency - 0.5f;
        waveSpeed = basewaveSpeed;
        for (int i = 2; i < n; i++)
        {
            Vector3 pos = spline.GetPosition(i);
            float x = basePointPos.x + interval * (i - 2);
            pos.y = waveAmplitude * Mathf.Sin(waveFrequency * x + time) * 0.25f; // sin”g
            spline.SetPosition(i, pos);

        }
        if (waveObject != null)
        {
            Vector3 waveObjPos = waveObject.position;
            waveObjPos.y = GetWaveHeight(waveObject.position.x, time - 0.25f) - 0.25f; // ”g‚Ì‚‚³‚ğæ“¾
            waveObject.position = waveObjPos;
        }
    }
}