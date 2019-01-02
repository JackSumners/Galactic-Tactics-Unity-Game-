using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text timerText;
    //public Plane_Brain time_brain;
    private string t;
    public double timeNum;
    public int T;

    private void Start()
    {
        timeNum = Math.Round(Time.time, 2);

        if (timeNum > 60)
        {
            T = (int)(timeNum / 60);
            timeNum -= (T*60);
            timerText.text = "Clear Time: " + T + " Min " + timeNum + " Seconds";
        }
        else
        {
            timerText.text = "Clear Time: " + timeNum + " seconds";

        }
    }

    private void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}