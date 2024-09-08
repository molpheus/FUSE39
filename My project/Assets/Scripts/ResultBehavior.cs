using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultBehavior : MonoBehaviour
{
    public static ResultBehavior Instance;
    GameObject Title;

    bool clicked = false;
    int score = 100000;
    [SerializeField] TextMeshProUGUI ScoreText;

    private void Awake()
    {
        this.gameObject.SetActive(false);

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
        if (Title != null) Title = GameObject.Find("Title");
        ScoreText.text = score.ToString();
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
        ResultExit();
    }

    void ResultExit()
    {
        Title.GetComponent<TitleBehavior>().TitleIntro();
    }
}
