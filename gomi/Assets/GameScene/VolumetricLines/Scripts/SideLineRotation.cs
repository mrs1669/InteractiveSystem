using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideLineRotation : MonoBehaviour
{
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
       // rotationX = gameObject.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX -= 0.25f;
        
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotationX, rotationY, rotationZ));
        if (rotationX <= 0) rotationX = 360;
    }
}
