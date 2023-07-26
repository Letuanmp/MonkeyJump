using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coutdown : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currenTime;
    private bool isRunning;

    private void Start()
    {
        gameOver.SetActive(false);
        currenTime = duration;
        timeText.text = currenTime.ToString();
        StartCoroutine(TimeEnd());

    }

    public void Update()
    {
        if (FindObjectOfType<Tutorial>().isRight && !isRunning)
        {
            StartCoroutine(TimeEnd());
            isRunning = true;
        }

    }
    IEnumerator TimeEnd()
    {
        while (currenTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currenTime);
            timeText.text = currenTime.ToString();
            yield return new WaitForSeconds(1f);
            currenTime--;
           
        }
       
        OpenE();
    }

    public void OpenE()
    {
        timeText.text = "";
        gameOver.SetActive(true);
        FindObjectOfType<GameManager>().GameOver();
      
    }


}
