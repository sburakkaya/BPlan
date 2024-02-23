using UnityEngine;

public class BotAnimationManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private IInputManager inputManager;

    private const string WALK_ANIMATION = "run";

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.x > 0.1f)
        {
            animator.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }
}