using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float Levelscore = 0;
    Slider slider;

    Text textReview;
    private void Start()
    {
        slider = GameObject.FindGameObjectWithTag("UI").GetComponent<Slider>();

        textReview = GameObject.Find("Review").GetComponent<Text>();
    }
    void Update()
    {
        showText();
        slider.value += Levelscore;
    }

    void showText()
    {
        if(Levelscore > 0)
        {
            textReview.text = "Perfect Score";
        }
        else if(Levelscore < 0)
        {
            textReview.text = "Points Deduced";
        }
    }
}
