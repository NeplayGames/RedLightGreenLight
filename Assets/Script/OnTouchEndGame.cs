using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchEndGame : MonoBehaviour
{
    public static event Action<Transform,float > GameOver;
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(GameOver!=null)
            GameOver(other.transform,0f);
        }
    }
}
