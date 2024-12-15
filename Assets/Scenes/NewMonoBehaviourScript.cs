using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem; // 雨のパーティクルシステム
    public ParticleSystem snowParticleSystem;//雪のパーティクルシステム
    public float rainChance = 10f; // 雨が降る確率 (パーセント)
    public float snowChance = 10f; //雪が降る確率（パーセント）

    void Start()
    {
        // 確率で雨を降らせる
        float randomValue = Random.Range(0f, 100f);
        if (randomValue < rainChance)
        {
            rainParticleSystem.Play(); // 雨を降らせる
        }
        else
        {
            rainParticleSystem.Stop(); // 雨を止める

            // 確率で雪を降らせる
            if (randomValue < snowChance)
            {
                snowParticleSystem.Play(); // 雨を降らせる
            }
            else
            {
                snowParticleSystem.Stop(); // 雨を止める
            }
        }
    }
}