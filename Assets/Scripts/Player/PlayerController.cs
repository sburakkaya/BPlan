using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private IInputManager inputManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

#if UNITY_STANDALONE
        inputManager = GetComponent<KeyboardInputManager>();
#else
        inputManager = GetComponent<MobileInputManager>();
#endif
    }

    private void Update()
    {
        if(!GameManager.Instance.IsPlayerTurn)
            return;
        float moveInput = inputManager.GetHorizontalInput();
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        if (inputManager.JumpButtonPressed())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}