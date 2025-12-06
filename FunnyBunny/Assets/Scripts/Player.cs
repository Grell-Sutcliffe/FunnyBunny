using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Speeds")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float crawlSpeed = 1f;

    [Header("Refs")]
    public Animator animator;
    public SpriteRenderer sprite; 

    private Rigidbody2D rb;

    private Vector2 moveInput;
    private float targetSpeed;
    private bool hasInput;

    // height
    public int height = 1;//add in awake
    public int height_constant = 1;
    private bool isCrawling = false;
    private bool isAlive = true;
    private bool isRunning = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        //Debug.Log(height);
        if (!isAlive)
            return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(h, v);

        hasInput = moveInput.sqrMagnitude > 0.01f;
        if (hasInput)
            moveInput = moveInput.normalized;

        SetCrawling(Input.GetKey(KeyCode.C));
        isRunning = Input.GetKey(KeyCode.LeftShift) && !isCrawling;

        if (!hasInput)
        {
            targetSpeed = 0f;
        }
        else
        {
            if (isCrawling)
                targetSpeed = crawlSpeed;
            else if (isRunning)
                targetSpeed = runSpeed;
            else
                targetSpeed = walkSpeed;
        }

        animator.SetFloat("Speed", targetSpeed); // + podognatь
        animator.SetBool("IsCrawling", isCrawling);
        animator.SetBool("IsMoving", hasInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Activity");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }

        Flip();
    }

    public void SetCrawling(bool value)
    {
        isCrawling = value;

        if (isCrawling)
            height = height_constant - 1;
        else
            height = height_constant;
    }

    private void Flip()
    {
        if (Mathf.Abs(moveInput.x) > 0.01f) // if sprite is exist?
        {
            sprite.flipX = moveInput.x < 0f;
        }
    }

    void FixedUpdate()
    {
        if (!isAlive)
            return;
        HandleFixMovement();
    }

    private void HandleFixMovement()
    {
        Vector2 newPos = rb.position + moveInput * targetSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    public void Die()
    {
        if (!isAlive) return;

        isAlive = false;
        animator.SetTrigger("Die"); 

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}
