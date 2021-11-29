using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region variable declaration
    [SerializeField] Transform player;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    Vector3 finalPos;
    #endregion
    void LateUpdate()
    {
        finalPos = player.position + new Vector3(x, y, z);
        //Lerp the position of the player sync to the camera transform.
        transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * 5f);
    }

}