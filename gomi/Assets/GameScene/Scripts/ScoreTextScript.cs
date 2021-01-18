using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{
    TextMeshPro textMeshPro;
    GameManagerScript gameManagerScript;

    int score = 0;
    float lerpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.gameObject.GetComponent<TextMeshPro>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (score != gameManagerScript.GetScore())
        {
            lerpTime += 0.025f;
            score = (int) Mathf.Lerp(score, gameManagerScript.GetScore(), lerpTime);
        }
        else
            lerpTime = 0;
        textMeshPro.text = score.ToString();
        gameManagerScript.SetScore(score);
    }
}
