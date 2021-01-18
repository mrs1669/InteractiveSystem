using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventTriggerScript : MonoBehaviour
{
    GameObject directionalLight;
    int selfTime = 0;

    bool trigger = false;

    public GameObject lines;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GameObject.Find("Directional Light");
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == false) return;

        if(selfTime < 60) selfTime++;
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(directionalLight.transform.rotation.x, -90, Time.time/100), 0));

        if (selfTime == 60)
        {
            Instantiate(lines);
            selfTime++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "VerticalCollider") trigger = true;
    }
}
