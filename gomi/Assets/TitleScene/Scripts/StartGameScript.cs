using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{

    //ゲームスタートが押された時のやつ
    public void goGame() {
        SceneManager.LoadScene("GameScene");
    }

    //ゲーム設定が押された時のやつ
    public void goSetting() {
        SceneManager.LoadScene("SettingScene");
    }

    //閉じるボタンが押された時のやつ
    public void endGame() {
        Quit();
    }

    //これでこのゲームを終わらせられるらしい
    void Quit() {
    #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
    #endif
  }
}
