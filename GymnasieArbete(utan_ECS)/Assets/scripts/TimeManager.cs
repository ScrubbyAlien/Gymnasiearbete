using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float curTimeScale;
    public Image pauseButtonImage;
    public Sprite pauseImg;
    public Sprite playImg;
    public Slider timeSlider;

    bool paused;


    void Start()
    {
        curTimeScale = 1;
        paused = false;
    }

    public void PausePlay()
    {
        if (Time.timeScale != 0)
        {
            //pause
            paused = true;
            curTimeScale = Time.timeScale;
            Time.timeScale = 0;
            pauseButtonImage.sprite = pauseImg;
        }
        else
        {
            //play
            paused = false;
            Time.timeScale = curTimeScale;
            pauseButtonImage.sprite = playImg;
        }


    }

    void Update()
    {
        if (!paused)
        {
            Time.timeScale = timeSlider.value;
        }

    }
}

