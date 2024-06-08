using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;

    // Controls the current movement of this character    
    public Vector2 CurrentMovement { get; set; }

    // Internal
    private Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UpdateAnimator();
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void HandleInput()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }

        dir.Normalize();
        SetMovement(dir);
    }

    private void UpdateAnimator()
    {
        if (CurrentMovement.x < 0)
        {
            animator.SetInteger("Direction", 3); // Left
        }
        else if (CurrentMovement.x > 0)
        {
            animator.SetInteger("Direction", 2); // Right
        }
        else if (CurrentMovement.y > 0)
        {
            animator.SetInteger("Direction", 1); // Up
        }
        else if (CurrentMovement.y < 0)
        {
            animator.SetInteger("Direction", 0); // Down
        }

        animator.SetBool("IsMoving", CurrentMovement.magnitude > 0);
    }

    private void MoveCharacter()
    {
        Vector2 currentMovePosition = myRigidbody2D.position + CurrentMovement * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(currentMovePosition);
    }

    // Sets the current movement of our character
    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovement = newPosition;
    }
}
