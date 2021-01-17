using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SackBehaviourScript : MonoBehaviour
{
    public GameObject particle;
    ComboTextScript comboTextScript;

    GameManagerScript gameManagerScript;

    List<string> caughtTrash;

    // Start is called before the first frame update
    void Start()
    {
        caughtTrash = new List<string>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        comboTextScript = GameObject.Find("ComboText").GetComponent<ComboTextScript>();
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
            caughtTrash.Add(other.gameObject.name); // 袋でキャッチしたゴミノーツの名前を追加していく
            Destroy(Instantiate(particle, new Vector3(other.transform.position.x, other.transform.position.y), Quaternion.identity), 2.0f); // キャッチした時のパーティクルをキャッチした位置で生成して２秒後に消滅させる
            Destroy(other.gameObject); // キャッチしたゴミオブジェクトを消す

            comboTextScript.IncrementCombo();
        }
    }

    // スコアの加算をここで行う
    // 画面から指が離された時の処理：正しいゴミ箱の位置にドラッグされていれば得点、そうでなければミス
    private void OnDestroy() 
    {
        bool isCorrect = true;

        /******** 燃えないゴミにドラッグされた場合 ********/
        if (this.gameObject.transform.position.x <= -7.0f && this.gameObject.transform.position.y <= 6.0f)
        {
            foreach(string trash in caughtTrash)
            {
                if (trash != "Moenai(Clone)") // 燃えないゴミ以外のゴミが入っていた場合誤りとする
                    isCorrect = false;
            }
        }

        /******** 缶ゴミにドラッグされた場合 ********/
        else if (this.gameObject.transform.position.x <= -6.0f && this.gameObject.transform.position.y > 6.0f)
        {
            foreach (string trash in caughtTrash)
            {
                if (trash != "Can(Clone)")
                    isCorrect = false;
            }
        }

        /******** 燃えるゴミにドラッグされた場合 ********/
        else if (this.gameObject.transform.position.x >= 7.0f && this.gameObject.transform.position.y <= 6.0f)
        {
            foreach (string trash in caughtTrash)
            {
                if (trash != "Moeru(Clone)")
                    isCorrect = false;
            }
        }

        /******** ペットボトルゴミにドラッグされた場合 ********/
        else if (this.gameObject.transform.position.x >= 6.0f && this.gameObject.transform.position.y > 6.0f)
        {
            foreach (string trash in caughtTrash)
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
            gameManagerScript.SetScore(100 * caughtTrash.Count); // 正しければ、100*キャッチしたゴミの個数　をスコアに加算する
        }
        else
        {
            gameManagerScript.SetScore(-25 * caughtTrash.Count); // 誤っていればスコアを　-25*キャッチしたゴミの個数　する
            comboTextScript.ResetCombo();
        }
    }
}
