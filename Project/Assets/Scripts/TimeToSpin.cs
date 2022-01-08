using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class TimeToSpin : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] DateTime timerEnd;
    [SerializeField] Text seconds;
    [SerializeField] TextMeshProUGUI secondsTxt;
    [SerializeField] float TargetTimeInSeconds; //depends seconds time value will change
    private int TotalSeconds;
    bool isSpinAllow;
    [SerializeField] Button StartTimerButton;
    [SerializeField] bool isTimeFormatMinuts;
    [SerializeField] string timeValue;
    private void Start()
    {
        StartTimerButton.onClick.AddListener(TimeToSpinAction);
        isSpinAllow = true;
        SetTime();
    }

    void SetTime()
    {
        img.fillAmount = 0;
        timerEnd = DateTime.Now.AddSeconds(TargetTimeInSeconds);
        TimeSpan delta = timerEnd - DateTime.Now;
        TotalSeconds = (int)delta.TotalSeconds;

        if (isTimeFormatMinuts)
        {
            secondsTxt.text = "Timer :"+delta.Hours.ToString("00") +":"+delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00");
        }
        else
        {
            secondsTxt.text = "Timer : " + TargetTimeInSeconds + "seconds";
        }
    }
    private void TimeToSpinAction()
    {
        SetTime();
        isSpinAllow = false;
        ButtonActiveState(false);
    }
    void ButtonActiveState(bool isActive)
    {
        StartTimerButton.gameObject.SetActive(isActive);
    }
    private void Update()
    {
        if (isSpinAllow) return;
        if (img.fillAmount <= 1)
        {
            TimeSpan delta = timerEnd - DateTime.Now;
            float TotalSeconds = (float)delta.TotalSeconds;
           
            img.fillAmount = 1.0f - (TotalSeconds / TargetTimeInSeconds);
            if (isTimeFormatMinuts)
            {
                seconds.text = delta.Hours.ToString("00") + ":" + delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00");
            }
            else
            {
                seconds.text = TotalSeconds.ToString("00");
            }

            if (img.fillAmount == 1)
            {
                img.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                seconds.color = img.color;
                isSpinAllow = true;
                ButtonActiveState(true);
            }
          
        }
    }
}
//please find the github link in the video description
//https://github.com/unity6d/ProgressBar


