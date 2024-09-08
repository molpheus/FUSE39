using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehavior : MonoBehaviour
{
    public static TitleBehavior Instance;

    GameObject Gameplay;
    bool clicked = false;
    public CanvasGroup TitleUI;
    public float FadeSpeed;
    float TitleAlpha;

    void Awake()
    {
        this.gameObject.SetActive(true);

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
        TitleIntro();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == false)
        {
            if (Input.GetMouseButton(0))
            {
                SoundController.I.PlaySE(SoundController.SE.Ok);
                clicked = true;
            }
            else return;
        }
        TitleExit();
    }

    public void TitleIntro()
    {
        this.gameObject.SetActive(true);
        clicked = false;
        TitleAlpha = 1.0f;
        Gameplay = GameObject.Find("Game");
    }

    void TitleExit()
    {
        Gameplay.SetActive(true);

        if (TitleAlpha > 0)
        {
            TitleAlpha -= Time.deltaTime * FadeSpeed;
            TitleUI.alpha = TitleAlpha;
        }
        else
        {
            clicked = false;
            this.gameObject.SetActive(false);
        }
    }
}
