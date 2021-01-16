using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
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
        //List<int> chartLines = new List<int>();
        var chartLines = new List<List<int>>();
        chartLines.Add(new List<int>());
        for (int i = 0; i < tempLines.Length; i++)
        {
            string[] tempLine1 = tempLines[i].Split(',');
            tempLine1[1].Trim();

            var tempLine2 = new List<int>();
            tempLine2.Add(int.Parse(tempLine1[0]));
            tempLine2.Add(int.Parse(tempLine1[1]));
            chartLines.Add(tempLine2);
        }

        print(chartLines[1][0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
