using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTextPlayer : MonoBehaviour
{
    GameManagerScript gameManagerScript;
    public GameObject score_object;
    int score = 0;

    public GameObject evaluationText;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        Text score_text = score_object.GetComponent<Text>();
        score = gameManagerScript.GetScore();
        score_text.text = score.ToString()+"点";
        Debug.Log(score);

        Text evaluation = evaluationText.GetComponent<Text>();
        evaluation.text = "評価\n";

        if(score < 0)
        {
            evaluation.text += "ゴミ分別に慣れよう！";
        }
        else if(score > 10000)
        {
            evaluation.text += "The Trash Classification Professional";
        }
        else
        {
            evaluation.text += "ゴミ分別上達！";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToTitle()
    {
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("TitleScene");
    }
}