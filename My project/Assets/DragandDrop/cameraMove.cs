using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class cameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shotObj;
    void Start()
    {
    }
    void Update()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        transform.position = new Vector3(transform.position.x, shotObj.transform.position.y, transform.position.z);
    }
}
