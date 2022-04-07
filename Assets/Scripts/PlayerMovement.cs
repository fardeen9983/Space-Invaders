using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Script Inputs
    /// </summary>
    #region Script Inputs
    [SerializeField]
    public float speed;
    #endregion

    /// <summary>
    /// Components
    /// </summary>
    #region Game Components
    private Rigidbody2D rigidBody;
    private Animator animator;
    #endregion

    private float HorizontalInput;
    private bool IsMovingLeft;
    private bool IsMovingRight;
    private PlayerMotionState MotionState;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        IsMovingLeft = IsMovingRight = false;
        MotionState = PlayerMotionState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(HorizontalInput * speed, rigidBody.velocity.y);

        switch (MotionState)
        {
            case PlayerMotionState.IDLE:
                MotionState = HorizontalInput == 0 ? PlayerMotionState.IDLE : HorizontalInput < 0 ? PlayerMotionState.STEER_LEFT : PlayerMotionState.STEER_RIGHT;
                break;
            case PlayerMotionState.STEER_RIGHT:
                animator.SetTrigger("move_right");
                if (HorizontalInput > 0)
                {
                    IsMovingLeft = false;
                    IsMovingRight = true;
                    MotionState = PlayerMotionState.MOVING_RIGHT;
                    animator.SetBool("moving_right", IsMovingRight);
                }
                else
                {
                    IsMovingLeft = IsMovingRight = false;
                    MotionState = PlayerMotionState.IDLE;
                }
                break;
            case PlayerMotionState.MOVING_RIGHT:
                
                if (HorizontalInput <= 0)
                {
                    IsMovingRight = false;
                    MotionState = PlayerMotionState.STOP_MOVING_RIGHT;
                }
                break;
           
            case PlayerMotionState.STEER_LEFT:
                animator.SetTrigger("move_left");
                if (HorizontalInput < 0)
                {
                    IsMovingLeft = true;
                    IsMovingRight = false;
                    MotionState = PlayerMotionState.MOVING_LEFT;
                    animator.SetBool("moving_left", IsMovingLeft);
                }
                else
                {
                    IsMovingLeft = IsMovingRight = false;
                    MotionState = PlayerMotionState.IDLE;
                }
                break;

            case PlayerMotionState.MOVING_LEFT:
                if (HorizontalInput >= 0)
                {
                    IsMovingLeft = false;
                    MotionState = PlayerMotionState.STOP_MOVING_LEFT;
                }
                break;
            case PlayerMotionState.STOP_MOVING_RIGHT:
            case PlayerMotionState.STOP_MOVING_LEFT:
                IsMovingRight = IsMovingLeft = false;
                MotionState = PlayerMotionState.IDLE;
                animator.SetBool("moving_right", IsMovingRight);
                animator.SetBool("moving_left", IsMovingLeft);
                break;
        }
    }
}
