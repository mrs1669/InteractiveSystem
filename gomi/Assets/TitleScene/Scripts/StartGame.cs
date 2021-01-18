using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{


    public void goGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void goSetting() {
        SceneManager.LoadScene("SettingScene");
    }

}
