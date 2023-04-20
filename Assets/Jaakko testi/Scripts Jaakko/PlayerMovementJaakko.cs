using UnityEngine;

public class PlayerMovementJaakko : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isIdle = true;
    private bool isWalking = false;
    private bool isJumping = false;
    [SerializeField] float jumpCheckRadius;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        Flip();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, jumpCheckRadius, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Added code for moving left and right
    public void Move(float moveInput)
    {
        horizontal = moveInput;
    }

    // Added code for jumping
    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    // Added code for attacking
    public void Attack()
    {
        // Add your attack code here
    }

    // Update the animator based on the current state
    private void UpdateAnimator()
    {
        if (horizontal != 0 && isIdle)
        {
            isIdle = false;
            isWalking = true;
            animator.SetBool("isIdle", isIdle);
            animator.SetBool("isWalking", isWalking);
        }
        else if (horizontal == 0 && !isIdle)
        {
            isIdle = true;
            isWalking = false;
            animator.SetBool("isIdle", isIdle);
            animator.SetBool("isWalking", isWalking);
        }

        isJumping = !IsGrounded();
        animator.SetBool("isJumping", isJumping);

        animator.SetBool("isAttacking", isAttacking);
    }
}
