using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public ParticleSystem dust; // 07 may 2020

    private float movementInputDirection;
    private float jumpTimer;
    private float turnTimer;
    private float wallJumpTimer;
    private float knockbackStartTime;
    [SerializeField]
    private float knockbackDuation;

    private int amountOfJumpsLeft;
    private int facingDirection = 1;
    private int lastWallJumpDirection;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isAttemptingToJump;
    private bool checkJumpMultiplier;
    private bool canMove;
    private bool canFlip;
    private bool hasWallJumped;
    private bool knockback;
    private bool isHurting; // new (06 may 2020)
    private bool isDead; // new (06 may 2020)
    private bool damagePlayer;

    [SerializeField]
    private Vector2 knockbackSpeed;


    private Rigidbody2D rb;
    private Animator anim;

    public int amountOfJumps = 1;

    public float movementSpeed = 10.0f;
    public float jumpForce = 16.0f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragMultiplier = 0.95f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float wallHopForce;
    public float wallJumpForce;
    public float jumpTimerSet = 0.15f;
    public float turnTimerSet = 0.1f;
    public float wallJumpTimerSet = 0.5f;
    public float IEFFrames = 0.0f;

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
    }

    // Update is called once per frame
    void Update() {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();
        CheckJump();
        CheckKnockback();
    }

    private void FixedUpdate() {
        ApplyMovement();
        CheckSurroundings();
    }

    //07 may 2020
    private void CreateDust() {
        dust.Play();
    }

    private void CheckIfWallSliding() {
        if (isTouchingWall && movementInputDirection == facingDirection && rb.velocity.y < 0) {
            isWallSliding = true;
        }
        else {
            isWallSliding = false;
        }
    }

    public void knockBack(int direction)
    {
        //anim.SetBool("L", true);
       // if (anim.GetBool("L")== true){
        //    UnityEngine.Debug.Log("in KnockBack");
       // }
        knockback = true;
       // IEFFrames = 100.0f;
        knockbackStartTime = Time.time;

        UnityEngine.Debug.Log("IEFFrames: " + IEFFrames);

        if (IEFFrames <= 10)
        {
            rb.velocity = new Vector2(knockbackSpeed.x * direction, knockbackSpeed.y);// actually doing the knockback
            IEFFrames = 300.0f;
            anim.SetBool("L", true);
            damagePlayer = true;
        }
    }

    private void CheckKnockback()
    {
       // anim.SetBool("L", false);
        if (Time.time >= knockbackStartTime + knockbackDuation && knockback) // KnockBack is Over
        {
            knockback = false;
           anim.SetBool("L", false);
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
         if (IEFFrames > 10)
        {
            IEFFrames--;
            damagePlayer = false;

        }
        
        //  if (Time.time < knockbackStartTime + knockbackDuation && knockback)//Still in knockback Stage
        //    {
        //   IEFFrames--;
        //   UnityEngine.Debug.Log(IEFFrames);
        //  }
    }
    
    public int GetFacingDirection() {
        return facingDirection;
    }

    private void CheckSurroundings() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }

    private void CheckIfCanJump() {
        if (isGrounded && rb.velocity.y <= 0.01f) {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (isTouchingWall) {
            checkJumpMultiplier = false;
            canWallJump = true;
        }

        if (amountOfJumpsLeft <= 0) {
            canNormalJump = false;
        }
        else {
            canNormalJump = true;
        }
    }

    private void CheckMovementDirection() {
        if (isFacingRight && movementInputDirection < 0) {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0) {
            Flip();
        }

        if (Mathf.Abs(rb.velocity.x) >= 0.01f) {
            isWalking = true;
        }
        else {
            isWalking = false;
        }
    }

    private void UpdateAnimations() {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isWallSliding", isWallSliding);
        


        anim.SetBool("isHurting", isHurting); // new (06 may 2020)
        anim.SetBool("isDead", isDead); // new (06 may 2020)
    }

    private void CheckInput() {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump")) {
            if (isGrounded || (amountOfJumpsLeft > 0 && isTouchingWall)) {
                NormalJump();
            }
            else {
                jumpTimer = jumpTimerSet;
                isAttemptingToJump = true;
            }
        }

        if (Input.GetButtonDown("Horizontal") && isTouchingWall) {
            if (!isGrounded && movementInputDirection != facingDirection) {
                canMove = false;
                canFlip = false;
                turnTimer = turnTimerSet;
            }
        }

        if (turnTimer >= 0) {
            turnTimer -= Time.deltaTime;

            if (turnTimer <= 0) {
                canMove = true;
                canFlip = true;
            }
        }

        if (checkJumpMultiplier && !Input.GetButton("Jump")) {
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
        }
    }

    private void CheckJump() {
        if (jumpTimer > 0) {
            //WallJump
            if (!isGrounded && isTouchingWall && movementInputDirection != 0 && movementInputDirection != facingDirection) {
                WallJump();
            }
            else if (isGrounded) {
                NormalJump();
            }
        }

        if (isAttemptingToJump) {
            jumpTimer -= Time.deltaTime;
        }

        if (wallJumpTimer > 0) {
            if (hasWallJumped && movementInputDirection == -lastWallJumpDirection) {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                hasWallJumped = false;
            }
            else if (wallJumpTimer <= 0) {
                hasWallJumped = false;
            }
            else {
                wallJumpTimer -= Time.deltaTime;
            }
        }
    }

    private void NormalJump() {
        if (canNormalJump) {
            CreateDust(); //07 may 23020
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
        }
    }

    private void WallJump() {
        if (canWallJump) {
            CreateDust(); //07 may 23020
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            isWallSliding = false;
            amountOfJumpsLeft = amountOfJumps;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canMove = true;
            canFlip = true;
            hasWallJumped = true;
            wallJumpTimer = wallJumpTimerSet;
            lastWallJumpDirection = -facingDirection;
        }
    }

    private void ApplyMovement() {
        if (!isGrounded && !isWallSliding && movementInputDirection == 0 && !knockback) {
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
        }
        else if (canMove && !knockback) {
            rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        }

        if (isWallSliding) {
            if (rb.velocity.y < -wallSlideSpeed) {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }
    }

    public void DisableFlip() {
        canFlip = false;
    }

    public void EnableFlip() {
        canFlip = true;
    }

    private void Flip() {
        if (!isWallSliding && canFlip && !knockback) {
            CreateDust(); // 07 may 2020
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    public void GameOver()
    {
        UnityEngine.Debug.Log("GAME OVER!");
        SceneManager.LoadScene("Game Over");

    }

    public float DamageOrNot()
    {
        return IEFFrames;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
}
