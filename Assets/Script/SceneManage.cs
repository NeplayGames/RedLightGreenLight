using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    string url = "https://neplay-games.itch.io";
   public void StartGame(int i){
        Time.timeScale = 1f;
       SceneManager.LoadScene(i);
   } 

   public void QuitGame(){
       Application.OpenURL( url);
   }
}