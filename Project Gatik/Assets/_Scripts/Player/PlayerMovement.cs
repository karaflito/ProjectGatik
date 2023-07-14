using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script handles player movement in a 2D game
public class PlayerMovement : MonoBehaviour
{
    // Serialized field for setting movement speed in the Unity editor
    [SerializeField] float movementSpeed;

    // used for fire input
    bool fired;
    public bool Fired
    {
        get
        {
            return fired;
        }
    }

    // Vector2 to store the direction of movement from player input
     Vector2 direction;
     Vector2 lastDirection;
    public Vector2 LastDirection
    {
        get
        {
            return lastDirection;
        }
    }

    // Components for controlling physics and animation
    Rigidbody2D rd;
    Animator animator;

    // Retrieves necessary components in the Awake method
    void Awake()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        // Get the Rigidbody2D component
        rd = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Runs physics-based movement in FixedUpdate
    void FixedUpdate()
    {
        Movement();
       
    }

    // Input callback function that sets the direction of movement
    public void PlayerInput(InputAction.CallbackContext directionPressed)
    {
        direction = directionPressed.ReadValue<Vector2>();
       /* if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }*/
    }

    // Input callback function that sets if its ready to fire
    public void FireInput(InputAction.CallbackContext firePressed)
    {
        switch (firePressed.phase)
        {
            case InputActionPhase.Started:
                
                fired = true;
                break;

            case InputActionPhase.Performed:
               
                fired = true;
                break;

            case InputActionPhase.Canceled:
                
                fired = false;
                break;
        }
    }

    // Handles movement and animation
    private void Movement()
    {
        /*if (direction != Vector2.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Transform childTransform = transform.GetChild(0).transform;
            childTransform.position = transform.position + (Vector3)direction * 0.5f;
            childTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
        

        animator.SetFloat("Speed", direction.sqrMagnitude);
        rd.velocity = direction * movementSpeed * Time.fixedDeltaTime;*/
        // Get the mouse position in world coordinates


        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // Calculate the direction from the player to the mouse
        Vector2 directionToMouse = mousePos - transform.position;

        if (directionToMouse != Vector2.zero)
        {
            lastDirection = directionToMouse;
            animator.SetFloat("Horizontal", directionToMouse.normalized.x);
            animator.SetFloat("Vertical", directionToMouse.normalized.y);

            //Set the child object's position and rotation
            float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
            Transform childTransform = transform.GetChild(0).transform;
            childTransform.position = transform.position + (Vector3)directionToMouse.normalized * 0.5f;
            childTransform.rotation = Quaternion.Euler(0, 0, angle);
            


        }



        // Set the speed parameter based on the direction to the mouse
        animator.SetFloat("Speed", directionToMouse.sqrMagnitude);
        rd.velocity = direction * movementSpeed * Time.fixedDeltaTime;
    }
}
