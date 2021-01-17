using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackBehaviourScript : MonoBehaviour
{
    GameManagerScript gameManagerScript;

    List<string> catchedTrash;

    // Start is called before the first frame update
    void Start()
    {
        catchedTrash = new List<string>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("SackVehaviourScript; OnTriggerEnter");

        if (other.gameObject.tag == "Notes")
        {
            catchedTrash.Add(other.gameObject.name); // 袋でキャッチしたゴミノーツの名前を追加していく
            Destroy(other.gameObject); // キャッチしたゴミオブジェクトを消す
        }
    }

    // スコアの加算をここで行う
    // 画面から指が離された時の処理：正しいゴミ箱の位置にドラッグされていれば得点、そうでなければミス
    private void OnDestroy() 
    {
        bool isCorrect = true;

        /******** 燃えないゴミにドラッグされた場合 ********/
        if (this.gameObject.transform.position.x <= -9.0f && this.gameObject.transform.position.y <= 6.0f)
        {
            foreach(string trash in catchedTrash)
            {
                if (trash != "Moenai(Clone)") // 燃えないゴミ以外のゴミが入っていた場合誤りとする
                    isCorrect = false;
            }

            Debug.Log("SackBehaviourScript;" + catchedTrash[0]);
        }

        /******** 缶ゴミにドラッグされた場合 ********/
        else if (this.gameObject.transform.position.x <= -7.0f && this.gameObject.transform.position.y > 6.0f)
        {
            foreach (string trash in catchedTrash)
            {
                if (trash != "Can(Clone)")
                    isCorrect = false;
            }

            Debug.Log("SackBehaviourScript; Can Gomi");
        }

        /******** 燃えるゴミにドラッグされた場合 ********/
        if (this.gameObject.transform.position.x >= 9.0f && this.gameObject.transform.position.y <= 6.0f)
        {
            foreach (string trash in catchedTrash)
            {
                if (trash != "Moeru(Clone)")
                    isCorrect = false;
            }
        }

        /******** ペットボトルゴミにドラッグされた場合 ********/
        else if (this.gameObject.transform.position.x >= 7.0f && this.gameObject.transform.position.y > 6.0f)
        {
            foreach (string trash in catchedTrash)
            {
                if (trash != "Bottle(Clone)") // ペットボトルゴミ以外のゴミが入っていた場合誤りとする
                    isCorrect = false;
            }
        }

        /******** ゴミ箱にドラッグされなかった場合はミス ********/
        else
            isCorrect = false;

        if (isCorrect)
        {
            gameManagerScript.SetScore(100 * catchedTrash.Count); // 正しければ、100*キャッチしたゴミの個数　をスコアに加算する
        }
        else
        {
            gameManagerScript.SetScore(-25 * catchedTrash.Count); // 誤っていればスコアを　-25*キャッチしたゴミの個数　する
        }
    }
}
