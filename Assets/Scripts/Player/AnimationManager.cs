using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private IInputManager inputManager;

    private const string WALK_ANIMATION = "run";

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        inputManager = GetComponent<IInputManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (inputManager.GetHorizontalInput() != 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }
}