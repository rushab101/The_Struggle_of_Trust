using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public ParticleSystem dust; // 07 may 2020

    private float movementInputDirection;
    private float jumpTimer;
    private float turnTimer;
    private float wallJumpTimer;
    private float knockbackStartTime;
    private bool jumped;
    private float dashTimeLeft;
    private bool isFalling;
    private float spinTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100f;
    private float lastSpin = -100f;
    [SerializeField]
    private float knockbackDuation;

    private int amountOfJumpsLeft;
    private int facingDirection = 1;
    private int lastWallJumpDirection;

    private bool isFacingRight = true;
    public bool isWalking;
    public bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool canNormalJump;
    private bool disableMove;
    private bool canWallJump;
    private bool isAttemptingToJump;
    private bool checkJumpMultiplier;
    private float lastTapTime = 0;
    public bool canMove;
    public bool canFlip;
    private bool hasWallJumped;
    private bool knockback;
    private bool isHurting; // new (06 may 2020)
    private bool isDead; // new (06 may 2020)
    private bool damagePlayer;
    private bool isDashing;
    private bool isSlidding;

    [SerializeField]
    private Vector2 knockbackSpeed;


    public Rigidbody2D rb;
    public Animator anim;

    public int amountOfJumps = 1;

    public float movementSpeed = 10.0f;
    public float fasterMovementSpeed = 11.0f;
    public float jumpForce = 16.0f;
    public float fJumpPressedRemember = 0;

    public float tapSpeed = 0.55f;
    public float tapSpeed2 = 0.7f;
    public float tapSpeed3 = 1.5f;

    public float tapSpeed4 = 2.0f;

    public float dashTime;
    public float spinTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    public float spinCoolDown;
    public bool spinning = false;
    public float fJumpPressedRememberTime = 0.2f;
    public float fGroundedRemeber = 0;
    public float fGroundRememberTime = 0.2f;
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
    private bool notRepeat = false;
    public float IEFFrames = 0.0f;

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask whatIsGround;
    public bool isSpinning;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
        lastTapTime = 0;
        disableMove = false;
    }

    // Update is called once per frame
    void Update()
    {

        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        CheckIfWallSliding();
        CheckJump();
        CheckKnockback();
        // checkifCanspin();
        CheckDash();
        CheckSlide();
        CheckSpin();
        CheckFalling();
    }


    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    //07 may 2020
    private void CreateDust()
    {
        dust.Play();
    }

    private void CheckFalling()
    {
        if (rb.velocity.y < -0.1 && jumped)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }

    private void CheckIfWallSliding()
    {
        if ((isTouchingWall && movementInputDirection == facingDirection && rb.velocity.y < -0.1 && rb.velocity.magnitude > 0))
        {
            isWallSliding = true;
            anim.SetBool("wallSlide", true);
        }
        else
        {

            anim.SetBool("wallSlide", false);
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

      //  UnityEngine.Debug.Log("IEFFrames: " + IEFFrames);

        if (IEFFrames <= 20)
        {
            FindObjectOfType<PlayerCombatController>().animationIE = true;
            rb.velocity = new Vector2(knockbackSpeed.x * direction, knockbackSpeed.y);// actually doing the knockback
            IEFFrames = 150.0f;
            anim.SetBool("L", true);
            damagePlayer = true;
        }
    }

    private void CheckKnockback()
    {
        // anim.SetBool("L", false);
        if (Time.time >= knockbackStartTime + knockbackDuation && knockback) // KnockBack is Over
        {
            FindObjectOfType<PlayerCombatController>().animationIE = false;
            knockback = false;
            anim.SetBool("L", false);
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
        if (IEFFrames > 20)
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

    public int GetFacingDirection()
    {
        return facingDirection;
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0.01f)
        {
            amountOfJumpsLeft = amountOfJumps;
        }





        if (isTouchingWall)
        {
            checkJumpMultiplier = false;
            canWallJump = true;
        }

        if (amountOfJumpsLeft <= 0)
        {
            canNormalJump = false;
        }


        else
        {
            canNormalJump = true;

        }
    }

    private void CheckMovementDirection()
    {


        if (isFacingRight && movementInputDirection < 0)
        {
          //  UnityEngine.Debug.Log("Right Flip");
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
          //  UnityEngine.Debug.Log("Left Flip");
            Flip();
        }

        if (Mathf.Abs(rb.velocity.x) >= 0.01f && rb.velocity.magnitude > 0 && !isTouchingWall)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isWallSliding", isWallSliding);



        anim.SetBool("isHurting", isHurting); // new (06 may 2020)
        anim.SetBool("isDead", isDead); // new (06 may 2020)
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        fJumpPressedRemember -= Time.deltaTime;
        fGroundRememberTime -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {

            fJumpPressedRemember = fJumpPressedRememberTime;
            if (isGrounded)
            {
                fGroundedRemeber = fGroundRememberTime;
            }
            if (isGrounded || (amountOfJumpsLeft > 0 && !isTouchingWall))
            {
                NormalJump();
            }
            else
            {
                jumpTimer = jumpTimerSet;
                isAttemptingToJump = true;
            }
        }

        if (Input.GetAxis("Vertical") < 0 && isGrounded && !FindObjectOfType<PlayerCombatController>().down_attack)
        {

            disableMove = true;
            anim.SetBool("Down", true);
            movementInputDirection = 0f;

        }

        else
        {
            disableMove = false;
            movementInputDirection = Input.GetAxisRaw("Horizontal");
            anim.SetBool("Down", false);
        }


        if (Input.GetButtonDown("Horizontal") && isTouchingWall)
        {
            if (!isGrounded && movementInputDirection != facingDirection)
            {
                canMove = false;
                canFlip = false;
                turnTimer = turnTimerSet;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z) && !FindObjectOfType<PlayerCombatController>().down_attack && !FindObjectOfType<PlayerCombatController>().airAttack)
        {
            //   UnityEngine.Debug.Log("Error");
            canMove = false;
            StartCoroutine(SwordAttackQUICK());
            //canMove = false;

        }

        if (turnTimer >= 0)
        {
            turnTimer -= Time.deltaTime;

            if (turnTimer <= 0)
            {
                canMove = true;
                canFlip = true;
            }
        }

        if (checkJumpMultiplier && !Input.GetButton("Jump"))
        {
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Time.time >= (lastSpin + spinCoolDown))
            {
                AtemptToSpin();
            }

        }

        if (Input.GetButtonDown("Dash"))
        {
            if (Time.time >= (lastDash + dashCoolDown))
            {
                AttemptToDash();
            }

        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            UnityEngine.Debug.Log("In dashing");
            if (Time.time >= (lastDash + dashCoolDown))
            {
                AttemptToSlide();
            }

        }



    }
    private void CheckDash()
    {

        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                canFlip = false;

                //anim.SetBool("spinMan", true);
                rb.velocity = new Vector2(dashSpeed * facingDirection, 0);
                dashTimeLeft -= Time.deltaTime;
                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    //     UnityEngine.Debug.Log("Get values");
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }

            }
            if (dashTimeLeft <= 0 || isTouchingWall)
            {
                isDashing = false;
                canMove = true;
                canFlip = true;
            }


        }
    }

    private void CheckSpin()
    {

        if (isSpinning)
        {
            if (spinTimeLeft > 0 && !Input.GetKey(KeyCode.Space))
            {
                canMove = false;
                canFlip = false;
                canNormalJump = false;

                rb.velocity = new Vector2(fasterMovementSpeed * facingDirection, rb.velocity.y);
                
                spinTimeLeft -= Time.deltaTime;


            }
            else if (spinTimeLeft <= 0)
            {
                StartCoroutine(SwordAttackQUICK2());
                anim.SetBool("spinMan", false);
                isSpinning = false;
                canMove = true;
                canFlip = true;
            }


        }


    }

    private void CheckSlide()
    {

        if (isSlidding)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                canFlip = false;

                rb.velocity = new Vector2(dashSpeed * facingDirection, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;

            }
            if (dashTimeLeft <= 0 || isTouchingWall)
            {
                isDashing = false;
                canMove = true;
                canFlip = true;
            }


        }
    }


    private void AttemptToDash()
    {

        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }

    private void AtemptToSpin()
    {
        anim.SetBool("spinMan", true);
        spinTimeLeft = spinTime;
        lastSpin = Time.time;
        isSpinning = true;
    }

    private void AttemptToSlide()
    {
        isSlidding = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
    }





    IEnumerator SwordAttackQUICK()
    {
        //canMove = false;

        yield return new WaitForSeconds(0.45f);

        canMove = true;
    }

      IEnumerator SwordAttackQUICK2()
    {
        //canMove = false;

        yield return new WaitForSeconds(0.95f);

        canMove = true;
    }

    private void CheckJump()
    {
        if (jumpTimer > 0)
        {
            //WallJump
            if (!isGrounded && isTouchingWall && movementInputDirection != 0 && movementInputDirection != facingDirection)
            {
                WallJump();
            }
            else if (isGrounded || fJumpPressedRemember > 0 || fGroundedRemeber > 0 && !isTouchingWall)
            {

                fGroundedRemeber = 0;
                fJumpPressedRemember = 0;
                NormalJump();
            }
        }

        if (isAttemptingToJump)
        {
            jumpTimer -= Time.deltaTime;
        }

        if (wallJumpTimer > 0)
        {
            if (hasWallJumped && movementInputDirection == -lastWallJumpDirection)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                hasWallJumped = false;
            }
            else if (wallJumpTimer <= 0)
            {
                hasWallJumped = false;
            }
            else
            {
                wallJumpTimer -= Time.deltaTime;
            }
        }
    }

    private void NormalJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (((Time.time - lastTapTime) < tapSpeed && !isWallSliding) && isTouchingWall)
            {
                canNormalJump = false;
                UnityEngine.Debug.Log("Double tap");
            }

            if (!isWallSliding && !isTouchingWall || isGrounded)
            {
                canWallJump = true;
            }


            lastTapTime = Time.time;
        }

        if (!isWallSliding && !isTouchingWall)
            {
                canWallJump = true;
            }
        if (isGrounded)
        {
            canWallJump = true;
        }

        if (canNormalJump)
        {

            CreateDust(); //07 may 23020
            jumped = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
        }
        else
        {
            jumped = false;

        }
    }

    private void WallJump()
    {
        if (canWallJump)
        {
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

    private void checkifCanspin()
    {
        if (Input.GetKeyDown(KeyCode.C) && !notRepeat)
        {
            anim.SetBool("spinMan", true);
            notRepeat = true;
            UnityEngine.Debug.Log("YAAAAA ");
            spinning = true;

            rb.velocity = new Vector2(fasterMovementSpeed * movementInputDirection, rb.velocity.y);
            StartCoroutine(Test());

        }

    }

    private void ApplyMovement()
    {


        if (!isGrounded && !isWallSliding && movementInputDirection == 0 && !knockback)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
        }

        else if (canMove && !knockback && !Input.GetKeyDown(KeyCode.C) && !spinning)
        {
            StartCoroutine(Test());
            //  anim.SetBool("spinMan", false);
            anim.SetBool("spinMan", false);
            spinning = false;
            notRepeat = false;
            rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        }


        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.05f);
        //  Debug.Log("Hi");
        spinning = false;
        //UnityEngine.Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }

    public void DisableFlip()
    {
        canFlip = false;
    }

    public void EnableFlip()
    {
        canFlip = true;
    }

    private void Flip()
    {
        if (!isWallSliding && canFlip && !knockback && !FindObjectOfType<PlayerCombatController>().airAttack)
        {
            CreateDust(); // 07 may 2020
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if (!isWallSliding && !knockback)
        {
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }
}
