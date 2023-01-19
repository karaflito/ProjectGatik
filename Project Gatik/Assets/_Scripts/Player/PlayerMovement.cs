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
        // If there is input
        if (direction != Vector2.zero)
        {
            //Set animator parameters for horizontal and vertical movement
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }

        // Set animator parameter for overall speed
        animator.SetFloat("Speed", direction.sqrMagnitude);
        // Move the rigidbody based on the direction and movementSpeed
        rd.velocity = direction * movementSpeed * Time.fixedDeltaTime;
    }
}
