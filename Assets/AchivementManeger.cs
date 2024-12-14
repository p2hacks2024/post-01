using UnityEngine;
using TMPro; 
using System;

public class AchinementManeger : MonoBehaviour
{
    
    [System.Serializable]
    public class Achievement
    {
        public string id;          // 実績を識別するためのID
        public string title;       // 実績のタイトル
        public string explain; //実績の説明
        public bool isUnlocked;    // 実績の達成状態
    }

    // 配列を定義
    public Achievement[] achievements = new Achievement[]
    {
        new Achievement { id = "1", title = "１．はじめのいっぽ", explain = "１度目のログイン\nココはあなただけのウミ\nゆったり波に流されよう\n",isUnlocked = false },
        new Achievement { id = "2", title = "２．おかえり", explain = "２度目のログイン\nまた来てくれてありがとう\nゆっくり海を感じよう\n",isUnlocked = false },
        new Achievement { id = "3", title = "３．早起き", explain = "３時～６時にログイン\n早起きは三文の徳\n…もしかして夜更かし？\n",isUnlocked = false },
        new Achievement { id = "4", title = "４．夜更かし", explain = "２３時～3時にログイン\nおやすみ前かな？\nそれとも早起き…？\n", isUnlocked = false },
        new Achievement { id = "5", title = "５．大波", explain = "スマホを振る・傾ける\n大きな波を起こしました¥n波を操れるなんて！\n",isUnlocked = false },
        new Achievement { id = "6", title = "６．一富士", explain = "富士山発見！\n新年早々少しのハッピー\n大吉気分待ったなし！\n",isUnlocked = false },
        new Achievement { id = "7", title = "７．二鷹", explain = "鷹発見！\n海の上を飛行中\nあなたの運気も急上昇\n",isUnlocked = false },
        new Achievement { id = "8", title = "８．三茄子", explain = "茄子発見！\n海の上に茄子！？\n縁起いい……のかな？\n",isUnlocked = false },
        new Achievement { id = "9", title = "９．一富士二鷹三茄子", explain = "富士山　鷹　茄子発見！\n三つ全てを発見しました\nいい一年になる予感！\n",isUnlocked = false },
        new Achievement { id = "10", title = "10．幽霊船", explain = "幽霊船を発見した\nなんか透けてなかった？\n誰が乗ってたんだろう…\n",isUnlocked = false },
        new Achievement { id = "11", title = "11．誰かのウミ", explain = "誰かと通信\n灯台が光っています\n向こう側にもきっとウミ\n",isUnlocked = false },
        new Achievement { id = "12", title = "12．UFO", explain = "UFOを発見した\n結構大きかったですね\nどこに行くんでしょう？",isUnlocked = false },
        new Achievement { id = "13", title = "13．ちょっとだけ深い", explain = "タイトルに戻る\nこのボタンがあるのは\nこの実績のためってわけ\n",isUnlocked = false },
        new Achievement { id = "14", title = "14．海底２万マイル", explain = "海底に迷い込む\n深海にたどり着きました\nなんてラッキーなの！\n",isUnlocked = false },
        new Achievement { id = "15", title = "15．ねこ…？", explain = "ねこ？を発見した\n島？いいえ　ねこです\n巨大なねこってかわいい\n",isUnlocked = false },
        new Achievement { id = "16", title = "☆．P2HACK", explain = "P2HACK！！\n今日だけの特別実績\nみなさんお疲れ様です！\n",isUnlocked = false }
    };
    
    public TMP_Text displayText; //表示する実績のテキスト
    public GameObject backgroundImage;//表示する実績の背景画像
    public float displayDuration = 3f; // テキスト表示の時間（秒）
    public Vector3 backgroundStartPos; // 背景の開始位置
    public Vector3 backgroundEndPos;   // 背景の終了位置
    public Vector3 textStartPos;       // テキストの開始位置
    public Vector3 textEndPos; // テキストの終了位置
    public float dropSpeed = 4f;       // 降りてくる速度
    private float cameraMoveDuration; // カメラ移動時間

    private const string LoginCountKey = "LoginCount";//ログイン回数を保持するキー

    void Start()
    {
        // 現在時刻を取得
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        
        //再ログインした際　実績を表示する枠が残らないようにするための処理
        if (backgroundImage != null)
            backgroundImage.SetActive(false);
        if (displayText != null)
            displayText.gameObject.SetActive(false);
            
        // 実績を読み込む
        LoadAchievements();
        // 開発者確認用実績データリセット関数
        //ResetAchievements();
        // ゲーム初回ログイン時実績１達成
        Debug.Log("実績解除: はじめのいっぽ");
        //UnlockAchievement("1");
        // カメラ移動時間を取得
        CameraMove cameraMoveScript = FindObjectOfType<CameraMove>();
        if (cameraMoveScript != null)
        {
            cameraMoveDuration = cameraMoveScript.moveDuration;
        }
        else
        {
            cameraMoveDuration = 0f; // デフォルト値
        }
         // 条件: 3時～6時の間にログインした場合
        if (now.Hour >= 3 && now.Hour < 6)
        {
            Debug.Log("実績解除: 早起き！");
            UnlockAchievement("3"); // 実績解除メソッドを呼び出し
        }
        // 条件: 23時～3時の間にログインした場合
        else if(now.Hour < 3 && now.Hour >= 23)
        {
            Debug.Log("実績解除: 夜更かし");
            UnlockAchievement("4"); //実績解除メソッドを呼び出し
        }
        // 2024/12/15 p2hackの日にログインした場合
        if(year==2024&&month==12&&day==15){
            Debug.Log("実績解除: P2hack");
            UnlockAchievement("16");//実績解除メソッドを呼び出し
        }

        // ?番目の実績を解除
        //UnlockAchievement("3");
    }

    // 実績を解除するメソッド
    public void UnlockAchievement(string id) // 実績IDを受け取る
    {
        Achievement achievement = GetAchievementById(id); //実績を取得

        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.isUnlocked = true;  // 実績を解除
            SaveAchievements();//実績を保存
            ShowUnlockedAchievement(achievement); // 実績タイトルを表示
            CaptureScreenshot(achievement);//実績をとった時のスクリーンショットを撮る
        }
    }

    private Achievement GetAchievementById(string id)// 実績IDで実績を取得
    {
        foreach (var achievement in achievements)
        {
            if (achievement.id == id)
                return achievement;
        }
        Debug.LogWarning($"Achievement with ID {id} not found.");
        return null;
    }
    // 一定時間後にテキストを非表示にするコルーチン
    private System.Collections.IEnumerator AnimatePopup()
    {
        // カメラ移動時間分待機
        yield return new WaitForSeconds(cameraMoveDuration+2f);
        // 初期位置を設定
        backgroundImage.SetActive(true);
        displayText.gameObject.SetActive(true);
        backgroundImage.transform.position = backgroundStartPos;
        displayText.transform.position = textStartPos;

        // 上から降りてくるアニメーション
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * dropSpeed;
            backgroundImage.transform.position = Vector3.Lerp(backgroundStartPos, backgroundEndPos, elapsedTime);
            displayText.transform.position = Vector3.Lerp(textStartPos, textEndPos, elapsedTime);
            yield return null;
        }

        // 一定時間表示
        yield return new WaitForSeconds(displayDuration);

        // テキストと背景を非表示にする
        backgroundImage.SetActive(false);
        displayText.gameObject.SetActive(false);
    }

    // 実績解除時にそのタイトルを表示するメソッド
    private void ShowUnlockedAchievement(Achievement achievement)
    {
            // 実績解除されたタイトルを表示
            displayText.text = $"{achievement.title}";
            backgroundImage.SetActive(true);

            // テキストを一定時間後に非表示にする
            StartCoroutine(AnimatePopup());
    }

    private void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            // 実績の解除状態をPlayerPrefsに保存
            PlayerPrefs.SetInt($"Achievement_{achievement.id}", achievement.isUnlocked ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadAchievements()
    {
        foreach (var achievement in achievements)
        {
            // 実績の解除状態をPlayerPrefsから読み込む
            achievement.isUnlocked = PlayerPrefs.GetInt($"Achievement_{achievement.id}", 0) == 1;
        }
    }

    public void ResetAchievements()
    {
        foreach (var achievement in achievements)
        {
            achievement.isUnlocked = false;
            PlayerPrefs.SetInt($"Achievement_{achievement.id}", 0);
        }
        PlayerPrefs.Save();

        Debug.Log("Achievements have been reset.");
    }

    private void CaptureScreenshot(Achievement achievement)
    {
        string screenshotFileName = $"Achievement_{achievement.id}_{achievement.title}.png";
        string screenshotPath = System.IO.Path.Combine(Application.persistentDataPath, screenshotFileName);
        ScreenCapture.CaptureScreenshot(screenshotPath);
        Debug.Log($"Screenshot taken for achievement: {achievement.title} at {screenshotPath}");
    }
    
}
