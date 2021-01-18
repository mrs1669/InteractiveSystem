using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTextSctipt : MonoBehaviour
{

    SettingControlSctipt settingControl;
    GameObject gameObject;

    public Text TextSpeed;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //settingControl = new SettingControlSctipt();
        gameObject = GameObject.Find("GameMain");
        settingControl = gameObject.GetComponent<SettingControlSctipt>();

        //Text表示用のSpeedを保存
        speed = settingControl.Speed;

        //SpeedValueに表示
        TextSpeed.text = string.Format("{0.0:10.0}", speed);
    }

    // Update is called once per frame
    void Update()
    {
        speed = settingControl.Speed;
        //SettingControlScript.cs内で変更されるSpeedの値を随時表示
        TextSpeed.text = string.Format("{0.0:10.0}", speed);
    }
}
