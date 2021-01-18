using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboTextScript : MonoBehaviour
{
   // Animator animator;
    TextMeshPro textMeshPro;
    GameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
       // animator = this.gameObject.GetComponent<Animator>();
        textMeshPro = this.gameObject.GetComponent<TextMeshPro>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementCombo()
    {
        gameManagerScript.SetCombo();
        textMeshPro.text = gameManagerScript.GetCombo().ToString();
       // animator.SetBool("AnimationTrigger", true);
       // animator.SetBool("AnimationTrigger", false);
    }

    public void ResetCombo()
    {
        gameManagerScript.ResetCombo();
        textMeshPro.text = gameManagerScript.GetCombo().ToString();
    }
}
