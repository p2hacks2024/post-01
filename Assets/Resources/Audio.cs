using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    //Audioミキサーを入れるとこです
    [SerializeField] AudioMixer audioMixer1;
    [SerializeField] AudioMixer audioMixer2;

    //それぞれのスライダーを入れるとこです。。
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SESlider;

    private void Start()
    {
        //ミキサーのvolumeにスライダーのvolumeを入れてます。

        //BGM
        audioMixer1.GetFloat("BGM", out float bgmVolume);
        BGMSlider.value = bgmVolume;
        //SE
        audioMixer2.GetFloat("SE", out float seVolume);
        SESlider.value = seVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer1.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer2.SetFloat("SE", volume);
    }
}