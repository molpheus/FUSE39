using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehavior : MonoBehaviour
{
    public static TitleBehavior Instance;

    bool TitleToGame = false;
    public CanvasGroup TitleUI;
    public float FadeSpeed;
    float TitleAlpha;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        TitleAlpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TitleToGame == false)
        {
            if (Input.GetMouseButton(0)) TitleToGame = true;
            else return;
        }
        TitleExit();
    }

    void TitleExit()
    {
        if (TitleAlpha > 0)
        {
            TitleAlpha -= Time.deltaTime * FadeSpeed;
            TitleUI.alpha = TitleAlpha;
        }
        else
        {
            Destroy(this.gameObject);
        }
        // ゲームプレハブを呼び出す
    }
}
