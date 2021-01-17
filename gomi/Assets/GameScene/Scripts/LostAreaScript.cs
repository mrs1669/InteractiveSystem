using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostAreaScript : MonoBehaviour
{
    public GameObject comboText;
    public GameObject incrementText;

    GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Notes")
        {
            gameManager.SetScore(-50);
            comboText.GetComponent<ComboTextScript>().ResetCombo();
            Destroy(other.gameObject);

            var it = Instantiate(incrementText).GetComponent<IncrementTextScript>();
            it.kindOfTrash = "";
            it.scoreDelta = -50;
        }
    }
}
