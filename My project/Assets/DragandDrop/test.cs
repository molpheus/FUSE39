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
                Debug.Log("ドラッグ前に呼び出される処理");
            };
            dropObj.onDropSuccess = (MonoBehaviour area, Action resetAction) =>
            {
                Debug.Log("ドラッグ成功時に呼び出される処理");
                resetAction.Invoke();
            };
            dropObj.onDropFail = (Action resetAction) =>
            {
                Debug.Log("ドラッグ失敗時に呼び出される処理");
                resetAction.Invoke();
            };

    }
}
