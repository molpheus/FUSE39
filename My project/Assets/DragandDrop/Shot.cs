using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject prePos;
    public GameObject prant;
    private int EnergieAll;
    public EnergieAll Energie;
    bool Push = false; 
    bool Finish = false; 

    // Start is called before the first frame update
    // Update is called once per frame
    public void OnMouseDown()
    {
        //Energie = GetComponent<EnergieAll>();
        EnergieAll = Energie.Energie1 * 100;
        Push = true;
    }

    private void Update()
    {
        if(Push)
        {
            for(int i = 0; i < EnergieAll; i++)
            {
                prant.transform.position -= new Vector3(0.0f,0.1f, 0.0f);
            }
            Push = false;
            Finish = true;
        }
        if(Finish== true && Push == false)
        {
            for(int i = 0;i < 10; i++)
            {
                prePos.transform.position -= new Vector3(0.0f, 0.01f, 0.0f);
            }

        } 
    }
}
