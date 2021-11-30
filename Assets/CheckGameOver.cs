using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameOver : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelManager.GameComplete();
        }
    }
}
