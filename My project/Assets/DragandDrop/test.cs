using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    public Draggable dropObj;

    // Start is called before the first frame update
    void Start()
    {


    }


// Update is called once per frame
void Update()
    {
            dropObj.beforeBeginDrag = () =>
            {
                Debug.Log("�h���b�O�O�ɌĂяo����鏈��");
            };
            dropObj.onDropSuccess = (MonoBehaviour area, Action resetAction) =>
            {
                Debug.Log("�h���b�O�������ɌĂяo����鏈��");
                resetAction.Invoke();
            };
            dropObj.onDropFail = (Action resetAction) =>
            {
                Debug.Log("�h���b�O���s���ɌĂяo����鏈��");
                resetAction.Invoke();
            };

    }
}
