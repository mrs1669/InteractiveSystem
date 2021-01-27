using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTextSctipt : MonoBehaviour
{

    public GameObject speedValueObject;
    //private float speed;
    private Text speedValue;

    // Start is called before the first frame update
    void Start()
    {
        speedValue = speedValueObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedValue.text = SettingControlSctipt.speed.ToString("f1");
    }
}
