using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject moeruTrash;
    public GameObject moenaiTrash;
    public GameObject canTrash;
    public GameObject bottleTrash;
    public GameObject lightEventTrigger;
    public GameObject parentTrashNotes;

    public float setSpeed; //タイトル画面から渡される譜面速度


    // ゲーム中のスコア：ゲッターやセッターでのみ変更可能
    int totalScore = 0;

    // ゲーム中のコンボ：ゲッターやセッターでのみ変更可能
    int combo = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("chart_astronomia", typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる

        //テキスト内の();を消す
        TextLines = TextLines.Replace("(", "");
        TextLines = TextLines.Replace(");", "");

        //Splitで一行ずつを代入した1次配列を作成
        string[] tempLines = TextLines.Split('\n');

        //譜面データとなる二次元配列を生成
        var chartLines = new List<List<int>>();

        // 
        for (int i = 0; i < tempLines.Length; i++)
        {
            string[] tempLine1 = tempLines[i].Split(','); //「,」の前後で文字列を配列に分ける
            tempLine1[1].Trim(); //「,」の後の空白文字を取り除く

            var tempLine2 = new List<int>(); //2列目のリストを生成
            tempLine2.Add(int.Parse(tempLine1[0])); //タイミング
            tempLine2.Add(int.Parse(tempLine1[1])); //種類
            chartLines.Add(tempLine2);
        }

        //ゴミノーツを配置
        for(int i = 0; i < chartLines.Count; i++)
        {
            GameObject trashObject;

            switch(chartLines[i][1])
            {
                case 1:
                    trashObject = Instantiate(moeruTrash, new Vector3(RandomX(), RandomY(), (chartLines[i][0]/50) * setSpeed), Quaternion.Euler(90, Random.Range(0, 360), 0));
                    break;
                case 2:
                    trashObject = Instantiate(moenaiTrash, new Vector3(RandomX(), RandomY(), (chartLines[i][0]/50) * setSpeed), Quaternion.Euler(180, Random.Range(0, 360), 0));
                    break;
                case 3:
                    trashObject = Instantiate(canTrash, new Vector3(RandomX(), RandomY(), (chartLines[i][0]/50) * setSpeed), Quaternion.Euler(90, Random.Range(0, 360), 0));
                    break;
                case 4:
                    trashObject = Instantiate(bottleTrash, new Vector3(RandomX(), RandomY(), (chartLines[i][0]/50) * setSpeed), Quaternion.Euler(90, Random.Range(0, 360), 0));
                    break;
                case 5:
                    trashObject = Instantiate(lightEventTrigger, new Vector3(0, 0, (chartLines[i][0]/50) * setSpeed), Quaternion.identity);
                    break;
                default:
                    trashObject = new GameObject(); // 空オブジェクト、ふつうはここにたどり着かない
                    break;
            }

            trashObject.transform.parent = parentTrashNotes.transform;
            parentTrashNotes.GetComponent<NotesMovementScript>().SetSpeed(setSpeed);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("GameManagerScript; Score: " + GetScore());
    }

    private float RandomX()
    {
        float random = Random.Range(-6.0f, 6.0f);
        if (-6.0f <= random && random < -2.0f)
            return -6.0f;
        else if (-2.0f <= random && random < 2.0f)
            return 0;
        else
            return 6.0f;
    }

    private float RandomY()
    {
        float random = Random.Range(-1.0f, 1.0f);
        if (random > 0)
            return 8.0f;
        else
            return 0;
    }

    // スコアのゲッター
    public int GetScore() => totalScore;

    // スコアのセッター
    public void SetScore(int score) => totalScore += score;

    // コンボのゲッター
    public int GetCombo() => combo;

    // コンボのセッター
    public void SetCombo() => combo++;

    // コンボのリセット
    public void ResetCombo() => combo = 0;
}
