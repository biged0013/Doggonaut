using UnityEngine;

public class PlayerMovementJaakko : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
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
    //public bool isAttacking = false;
    public PlayerHealth health;

    [SerializeField] private PlayerAudio pAudio;

    private bool wasWalking = false; // Track the previous walking state

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
            pAudio.PlaySound("Jump");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("isAttacking 0");
            health.isAttackingFetched = true;
            pAudio.PlaySound("Hit");
            //StartCoroutine(ResetAttackState()); // Start a coroutine to reset the isAttacking state
        }



        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        UpdateAnimator();
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool IsGrounded()
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

    

    private void UpdateAnimator()
    {
        bool isWalking = horizontal != 0 && IsGrounded();

        // Check if the state of isWalking has changed
        if (isWalking && !wasWalking)
        {
            pAudio.PlaySound("Walking"); // Play the walking sound when starting to walk
            wasWalking = true;
        }
        else if (!isWalking && wasWalking)
        {
            pAudio.StopWalkingSound(); // Stop the walking sound when stopping
            wasWalking = false;
        }

        // Update other animator parameters
        isIdle = !isWalking;
        isJumping = !IsGrounded();

        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
        //animator.SetTrigger("isAttacking 0");
    }



    //private System.Collections.IEnumerator ResetAttackState()
    //{
    //    yield return new WaitForSeconds(1f); // Adjust the delay as needed
    //    //isAttacking = false; // Reset isAttacking to false after a delay
    //}

}
