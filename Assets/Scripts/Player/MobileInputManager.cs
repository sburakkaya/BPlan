using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInputManager : MonoBehaviour, IInputManager
{
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private bool canJump = true;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;

    public float GetHorizontalInput()
    {
        if (isMovingLeft)
        {
            return -1f;
        }
        if (isMovingRight)
        {
            return 1f;
        }
        return 0f;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool JumpButtonPressed()
    {
        return canJump && Input.GetButtonDown("Jump") && !EventSystem.current.IsPointerOverGameObject();
    }

    public void StartMovingRight()
    {
        isMovingRight = true;
        transform.localScale = new Vector3(1,1,1);
    }

    public void StartMovingLeft()
    {
        isMovingLeft = true;
        transform.localScale = new Vector3(-1,1,1);
    }

    public void StopMoving()
    {
        isMovingRight = false;
        isMovingLeft = false;
    }

    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}