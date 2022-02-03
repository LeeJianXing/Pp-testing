using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private  float  moveSpeed =500f;
    Vector2 lastCilckPos;
    bool isMoving;
    public Animator animator;
    private float stop = 0f;
    public Transform pet;
    public Rigidbody2D rb;

    
    private float PetPos;

    private float petYBound = -260f;



    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {

       

        if (Input.GetMouseButtonDown(0))
        {
           
            lastCilckPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastCilckPos.y = petYBound;
            isMoving = true;

        }

        if (isMoving && (Vector2)transform.position != lastCilckPos)
        {
            float step = moveSpeed * Time.deltaTime;
            
            animator.SetFloat("Horizontal", lastCilckPos.x);
            
            PetPos = pet.position.x;

            transform.position = Vector2.MoveTowards(transform.position, lastCilckPos, step);
            animator.SetFloat("Speed", step);

            
          

            if(lastCilckPos.x >= PetPos ) 
            {
               
                animator.SetBool("moveRight", true);
                animator.SetBool("moveLeft", false);

                

            }

            if (lastCilckPos.x <= PetPos )
            {
                animator.SetBool("moveLeft", true);
               animator.SetBool("moveRight", false);

                






            }


            if ((Vector2)transform.position == lastCilckPos)
            {
                animator.SetFloat("Speed", stop);
            }
        }


          


         else
        {
            isMoving = false;
        }




    }













    
}
