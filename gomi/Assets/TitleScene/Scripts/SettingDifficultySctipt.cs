using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDifficultySctipt : MonoBehaviour
{
    public GameObject difficultyValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (SettingControlSctipt.difficulty)
        {
            case 1:
                difficultyValue.GetComponent<Text>().text = "Normal";
                break;
            case 2:
                difficultyValue.GetComponent<Text>().text = "Hard";
                break;
        }
    }
}
