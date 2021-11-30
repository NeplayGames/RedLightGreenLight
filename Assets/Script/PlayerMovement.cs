using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] Animator animator;
    [SerializeField] CheckPlayerMovement checkPlayerMovement;
    public static event Action<Transform> CheckGameOver;
    [SerializeField] int totalAnimation;
    Vector3 travelPosition;

    void Start()
    {
        travelPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                animator.SetTrigger("Run");
                    animator.SetInteger("Dance", totalAnimation);
                
                   
            

        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetInteger("Dance",UnityEngine.Random.Range(0,totalAnimation));

            //animator.SetTrigger("Idle");
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if (!hit.collider.CompareTag("Player"))
                {
                    Vector3 direction = (hit.point - transform.position).normalized;

                    //create the rotation we need to be in to look at the target
                    Quaternion _lookRotation = Quaternion.LookRotation(direction);

                    //rotate us over time according to speed until we are in the required rotation
                    transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);

                    travelPosition = new Vector3(hit.point.x,transform.position.y,hit.point.z);
                }
            transform.position = Vector3.MoveTowards(transform.position, travelPosition, 0.3f * Time.deltaTime * speed);
                if (!checkPlayerMovement.canMove)
                {
                    if (CheckGameOver != null)
                        CheckGameOver(transform);
                }

            }
           
        }
    }
}
