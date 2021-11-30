using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] Text timeText;
    [SerializeField] Text gameText;
    [SerializeField] Text totalTimeText;
    [SerializeField] GameObject effect;
    [SerializeField] AudioClip clip;
    [SerializeField] LineRenderer renderer;
    [SerializeField] Transform isntansePose;
    AudioSource source;
    int time = 0;
    int tempTIme = 0;
    void Start()
    {
        OnTouchEndGame.GameOver += OnTouchEndGame_GameOver;
        time = (int)Time.time;
        PlayerMovement.CheckGameOver += PlayerMovement_checkGameOver;
        source = GetComponent<AudioSource>();
    }

    private void PlayerMovement_checkGameOver(Transform trans)
    {
        renderer.SetPosition(0, isntansePose.position);
        renderer.SetPosition(1, trans.position + trans.up);
        OnTouchEndGame_GameOver(trans,0.5f);
    }
    private void OnDestroy()
    {
        OnTouchEndGame.GameOver -= OnTouchEndGame_GameOver;
        PlayerMovement.CheckGameOver -= PlayerMovement_checkGameOver;
    }
    Transform trans;
    bool gameOver = false;
    private void OnTouchEndGame_GameOver(Transform trans,float time)
    {
        if (gameOver) return;
        gameOver = true;
        this.trans = trans;
        Invoke(nameof( GameOver),time);  
    }

    private void GameOver()
    {
        Instantiate(effect, trans.position + trans.up, trans.rotation);
        trans.gameObject.SetActive(false);
        source.clip = clip;
        source.Play();
        Invoke(nameof(ShowGameOverCanvas),1f);
    }

    private void ShowGameOverCanvas()
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
            tempTIme++;
            timeText.text = "Total Time : " + tempTIme;
        }
    }

    public void GameComplete()
    {
        gameText.text = "Game Complete";
        totalTimeText.text = "Total Time : " + tempTIme;
        totalTimeText.gameObject.SetActive(true);
        GameOver();
    }   
}
