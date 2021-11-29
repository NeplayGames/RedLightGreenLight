using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Run");
            animator.speed = 1;
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.speed = 0;

            //animator.SetTrigger("Idle");
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Player"))
                    return;
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, 0.3f * Time.deltaTime * speed);
                Vector3 direction = (hit.point - transform.position).normalized;

                //create the rotation we need to be in to look at the target
                Quaternion _lookRotation = Quaternion.LookRotation(direction);

                //rotate us over time according to speed until we are in the required rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotationSpeed);

            }
        }
    }
}
