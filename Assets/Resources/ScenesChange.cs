using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Unityエンジンのシーン管理プログラムを利用する

public class Change : MonoBehaviour // Change という名前にします
{
    // インスペクターから設定可能なフィールド
    [SerializeField] private string nextSceneName; // 次に遷移するシーン名

    // ボタンから呼び出されるメソッド
    public void ChangeButton() // ChangeButton という名前にします
    {
        // インスペクターで指定されたシーン名を使って画面遷移
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("次に遷移するシーン名が指定されていません。");
        }
    }
}
