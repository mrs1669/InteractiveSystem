using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalColliderScript : MonoBehaviour
{
    public GameObject tappedCubePrefab;
    public Camera mainCamera;

    Ray ray;
    RaycastHit hit;

    bool prefabIsInstantiated1 = false;
    GameObject cube1;

    // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
        void Update()
    {
        if (Input.touchCount > 0)
        {
            ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (prefabIsInstantiated1 == false)
                {
                    cube1 = Instantiate(tappedCubePrefab, new Vector3(hit.point.x, hit.point.y), Quaternion.identity); //Rayがコライダーに当たった座標にインスタンス化
                    prefabIsInstantiated1 = true;
                }
                else
                    cube1.transform.position = new Vector3(hit.point.x, hit.point.y);
            }
        }
        else if (prefabIsInstantiated1 == true)
        {
            Destroy(cube1);
            prefabIsInstantiated1 = false;
        }
    }
}
