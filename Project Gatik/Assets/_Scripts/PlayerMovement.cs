using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed;


    Vector2 direction;


    //Components
    Rigidbody2D rd;
    Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        Movement();
    }

    public void PlayerInput(InputAction.CallbackContext directionPressed)
    {
        direction = directionPressed.ReadValue<Vector2>();
       
        
    }


    private void Movement()
    {
        if(direction != Vector2.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

        }
        
        

        animator.SetFloat("Speed", direction.sqrMagnitude);
        rd.velocity = direction * movementSpeed * Time.fixedDeltaTime;
    }


}
