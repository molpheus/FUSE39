using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnergieAll : MonoBehaviour
{
    public List<MonoBehaviour> dropArea;
    // Start is called before the first frame update
    public int Energie1;
    bool Push = false;

    // Update is called once per frame
    void Update()
    {
        Energie1 = 0;
        foreach (MonoBehaviour area in dropArea)
        {
            foreach (Transform child in area.transform)
            {
                if (child == area.transform)
                {
                     continue; 
                }

                Energie1 += child.GetComponent<Draggable>().Energie;
            }
        }


    }

    public void shot()
    {
        transform.position = new Vector2(0, Energie1);
    }
}
