using UnityEngine;
using System.Collections;

public class SequentialFadeIn : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] images; // 画像の配列
    [SerializeField] private float fadeDuration = 2f; // 各画像のフェードにかかる時間
    [SerializeField] private float waitDuration = 1f; // 待機時間

    private int currentImageIndex = 0; // 現在の画像のインデックス

    private void Start()
    {
        // 全ての画像の透明度を0に初期化
        InitializeImages();

        // 順番にフェードインを開始
        StartCoroutine(FadeImagesLoop());
    }

    // 画像の透明度を0に初期化
    private void InitializeImages()
    {
        foreach (SpriteRenderer image in images)
        {
            Color color = image.color;
            color.a = 0f; // 完全に透明
            image.color = color;
        }
    }

    // 画像を順番にフェードインし、5枚目完了時に繰り返すコルーチン
    private IEnumerator FadeImagesLoop()
    {
        while (true) // 無限ループ
        {
            for (int i = 0; i < images.Length; i++)
            {
                currentImageIndex = i;

                // 現在の画像をフェードイン
                yield return StartCoroutine(FadeIn(images[i]));

                // 2つ前の画像を透明にする
                if (i >= 2)
                {
                    SetTransparent(images[i - 2]);
                }

                // 5枚目のフェードイン完了時の特別処理
                if (i == images.Length - 1)
                {
                    SetOpaque(images[0]); // 1枚目を不透明にする
                    SetTransparent(images[3]); // 4枚目を透明にする
                    SetTransparent(images[4]); // 5枚目を透明にする
                    yield return new WaitForSeconds(waitDuration);

                    Debug.Log("Cycle Complete: Restarting from the first image.");
                }

                yield return new WaitForSeconds(waitDuration); // 各画像の待機時間
            }
        }
    }

    // 単一の画像をフェードインする処理
    private IEnumerator FadeIn(SpriteRenderer image)
    {
        float timeElapsed = 0f;
        Color color = image.color;
        color.a = 0f; // 最初は透明

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            color.a = alpha; // 透明度を補間して更新
            image.color = color;
            yield return null; // 次のフレームまで待機
        }

        color.a = 1f; // 完全に不透明にする
        image.color = color;
    }

    // 指定した画像を透明にする
    private void SetTransparent(SpriteRenderer image)
    {
        Color color = image.color;
        color.a = 0f; // 透明にする
        image.color = color;

        Debug.Log($"{image.name} has been made transparent.");
    }

    // 指定した画像を不透明にする
    private void SetOpaque(SpriteRenderer image)
    {
        Color color = image.color;
        color.a = 1f; // 不透明にする
        image.color = color;

        Debug.Log($"{image.name} has been made opaque.");
    }
}
