using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject prePos;
    private int EnergieAll;
    public EnergieAll Energie;
    bool Push = false;
    // Start is called before the first frame update
    // Update is called once per frame
    public void OnMouseDown()
    {
        //Energie = GetComponent<EnergieAll>();
        EnergieAll = Energie.Energie1;
        Push = true;
    }

    private void Update()
    {
        if(Push)
        {
            for(int i = 0; i < EnergieAll; i++)
            {
                prePos.transform.position += new Vector3(0.0f,0.1f, 0.0f);
            }
        }
  
    }
}
