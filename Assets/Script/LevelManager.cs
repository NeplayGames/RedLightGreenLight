using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] Text timeText;
    int time = 0;
    void Start()
    {
        OnTouchEndGame.GameOver += OnTouchEndGame_GameOver;
        time = (int)Time.time;
    }

    private void OnTouchEndGame_GameOver()
    {
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(time != (int)Time.time)
        {
            time++;
            timeText.text = "Total Time : " + time;
        }
    }
}
