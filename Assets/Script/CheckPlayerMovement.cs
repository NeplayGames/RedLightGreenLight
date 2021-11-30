using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CheckPlayerMovement : MonoBehaviour
{
    [SerializeField] AudioClip RLGLClip;
    AudioSource audioSource;
    [Header("The least amount of time to allow user to run")]
    [SerializeField] float runMinTime;
    [SerializeField] float runMaxTime;

    [SerializeField] float stopMinTime;
    [SerializeField] float stopMaxTime;

    [SerializeField] AudioMixer mixer;
    float stopTime = 0, runTime = 0;

    [SerializeField] Color green, red;

    [SerializeField] Image image;
    bool playAudio = true;
    [SerializeField] Transform robotHead;
    [HideInInspector]
    public bool canMove = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        runTime = Random.Range(runMinTime, runMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        StopAndRunMethod();
    }

    private void StopAndRunMethod()
    {
        if (stopTime <= 0)
        {
            if (runTime <= 0)
            {
                stopTime = Random.Range(stopMinTime, stopMaxTime);
                runTime = Random.Range(runMinTime, runMaxTime);
                playAudio = true;
                image.color = red;
                canMove = false;
            }
            else
            {
                if (playAudio)
                {
                    playAudio = false;
                    audioSource.pitch = runTime;
                    mixer.SetFloat("pitchBend", 1f / runTime);
                    audioSource.Play();
                    canMove = true;
                    image.color = green;
                }
                if (!audioSource.isPlaying)
                {
                    runTime -= Time.deltaTime;
                    robotHead.rotation = Quaternion.Slerp(robotHead.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 5);
                }
                else           
                    robotHead.rotation = Quaternion.Slerp(robotHead.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime * 5);             
            }
        }
        else
        {
            stopTime -= Time.deltaTime;
        }
    }
}
