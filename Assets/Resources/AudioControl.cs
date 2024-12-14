using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test4 : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;//AudioSource型の変数aを宣言 使用するAudioSourceコンポーネントをアタッチ必要

    [SerializeField] private AudioClip KokoniumiMainBGM;//AudioClip型の変数b1を宣言 使用するAudioClipをアタッチ必要
    [SerializeField] private AudioClip WaveSound;//AudioClip型の変数b2を宣言 使用するAudioClipをアタッチ必要 

    //自作の関数1
    public void SE1()
    {
        BGM.PlayOneShot(KokoniumiMainBGM);
    }

    //自作の関数2
    public void SE2()
    {
        BGM.PlayOneShot(WaveSound);
    }

    
}
