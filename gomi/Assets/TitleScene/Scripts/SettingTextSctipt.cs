using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingTextSctipt : MonoBehaviour
{

    public GameObject speedValueObject = null; 
    //private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text speedValue = speedValueObject.GetComponent<Text>();
        speedValue.text = SettingControlSctipt.speed.ToString("f1");
    }
}
