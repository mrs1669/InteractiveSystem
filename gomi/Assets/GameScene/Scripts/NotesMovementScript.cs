using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMovementScript : MonoBehaviour
{
    float setSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(0, 0, (-Time.time * 20) * setSpeed);
    }

    public void SetSpeed(float s) => setSpeed = s;
}
