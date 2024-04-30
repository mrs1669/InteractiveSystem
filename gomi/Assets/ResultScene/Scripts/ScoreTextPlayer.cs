using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextPlayer : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    public GameObject score_object;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        Text score_text = score_object.GetComponent<Text>();
        score = gameManagerScript.GetScore();
        score_text.text = score.ToString()+"点";
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
