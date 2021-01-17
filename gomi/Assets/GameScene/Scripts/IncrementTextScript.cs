using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrementTextScript : MonoBehaviour
{
    public string kindOfTrash = "";
    public int scoreDelta = 0;

    TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.gameObject.GetComponent<TextMeshPro>();

        /*****************/
        string plusOrMinus = "+";

        if (scoreDelta > 0)
            switch (kindOfTrash)
            {
                case "Moeru":
                    textMeshPro.color = new Color(255, 0, 0);
                    this.gameObject.transform.position = new Vector3(7, 2);
                    break;
                case "Moenai":
                    textMeshPro.color = new Color(0, 255, 0);
                    this.gameObject.transform.position = new Vector3(-2, 2);
                    break;
                case "Can":
                    textMeshPro.color = new Color(0, 0, 255);
                    this.gameObject.transform.position = new Vector3(-2, 10);
                    break;
                case "Bottle":
                    textMeshPro.color = new Color(200, 255, 0);
                    this.gameObject.transform.position = new Vector3(7, 10);
                    break;
                default:
                    break;
            }
        else
        {
            switch (kindOfTrash)
            {
                case "Moeru":
                    this.gameObject.transform.position = new Vector3(7, 2);
                    break;
                case "Moenai":
                    this.gameObject.transform.position = new Vector3(-2, 2);
                    break;
                case "Can":
                    this.gameObject.transform.position = new Vector3(-2, 10);
                    break;
                case "Bottle":
                    this.gameObject.transform.position = new Vector3(7, 10);
                    break;
                default:
                    this.gameObject.transform.position = new Vector3(2.5f, 0);
                    break;
            }
            textMeshPro.color = new Color(0, 0, 0);
            plusOrMinus = "";
        }

        textMeshPro.text = plusOrMinus + scoreDelta.ToString();

        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
