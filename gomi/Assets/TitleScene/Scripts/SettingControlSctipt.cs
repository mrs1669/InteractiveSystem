using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingControlSctipt : MonoBehaviour
{

    GameManagerScript gm;
    GameObject go;

    public static float speed = 2.0f;
    public float saveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //gm = new GameManagerScript();
        go = GameObject.Find("SpeedControl");
        gm = go.GetComponent<GameManagerScript>();

        //元の譜面速度にするために遷移直後の譜面速度を保存
        saveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {   
    }

    //＋ボタンが押されたらSpeedをあげる
    public void upSpeed() {
        speed += 0.1f;
    }

    //ーボタンが押されたらSpeedを下げる
    public void downSpeed() {
        speed -= 0.1f;
    }

    //戻るボタンが押された時のやつ
    public void goBack() {
        //GamemanagerScript.cs内のsetSpeedに、保存した譜面速度を代入
         //gm.setSpeed = saveSpeed;
        SceneManager.LoadScene("titleScene");
    }

    //変更するボタンが押された時のやつ
    public void decideAndGoBack() {
        //GamemanagerScript.cs内のsetSpeedに、upSpeed()やdownSpeed()を押した後の変更後譜面速度を代入
        //gm.setSpeed = Speed;
        SceneManager.LoadScene("titleScene");
    }
}
