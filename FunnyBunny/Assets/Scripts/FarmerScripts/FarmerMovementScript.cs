using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class FarmerMovementScript : MovementScript
{
    FarmerController farmerController;

    // public GameObject root;

    // float speed = 1f;
    // float stop_distance = 0f;
    // bool rotate_towards = false;

    float saw_bunny_anger_amount = 0.05f;

    // public bool was_bunny_hit = false;

    // private Animator animator;

    Rigidbody2D rb;

    // string is_walking = "is_walking";
    // string is_angry = "is_angry";
    // string is_crying = "is_crying";
    // string is_heart_attack = "is_heart_attack";

    string is_F = "is_F";
    string is_RF = "is_RF";
    string is_R = "is_R";
    string is_RB = "is_RB";
    string is_B = "is_B";

    string current_direction;

    // bool is_right;

    // SpriteRenderer sprite;

    void Awake() => rb = GetComponentInChildren<Rigidbody2D>();

    protected override void Start()
    {
        farmerController = GetComponent<FarmerController>();

        // animator = root.GetComponent<Animator>();

        // sprite = root.GetComponent<SpriteRenderer>();

        current_direction = is_F;

        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        SetDirection(step);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("PlayerVisible"))
        {
            was_bunny_hit = false;
            // farmerController.ChangeAngerPercent(saw_bunny_anger_amount);

            if (farmerController.current_anger_percent >= 0.5f)
            {
                farmerController.StartShooting();
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (other.CompareTag("PlayerVisible"))
        {
            if (was_bunny_hit)
            {
                farmerController.ChangeAngerPercent(-saw_bunny_anger_amount);
            }
            else
            {
                farmerController.ChangeAngerPercent(saw_bunny_anger_amount);
                StartAngerAnimation();
            }

            was_bunny_hit = false;
            farmerController.StopShooting();
        }
    }

    void StartAngerAnimation()
    {
        /*
        if (farmerController.current_anger_percent < 0.35f)
        {
            need_to_move = true;
            StopAngerAnimation();
            return;
        }
        */

        need_to_move = false;

        if (farmerController.current_anger_percent >= 0.8f)
        {
            animator.SetBool(is_angry, true);
        }
        else if (farmerController.current_anger_percent >= 0.65f)
        {
            animator.SetBool(is_crying, true);
            animator.SetBool(is_heart_attack, true);
        }
        else if (farmerController.current_anger_percent >= 0.5f)
        {
            animator.SetBool(is_crying, false);
            animator.SetBool(is_heart_attack, true);
        }
        else if (farmerController.current_anger_percent >= 0.35f)
        {
            animator.SetBool(is_crying, true);
            animator.SetBool(is_heart_attack, false);
        }
        else
        {
            need_to_move = true;
            StopAngerAnimation();
        }
    }

    public void StopAngerAnimation()
    {
        SetAllAngerParametersFalse();
        need_to_move = true;
    }

    public void SetAllAngerParametersFalse()
    {
        animator.SetBool(is_angry, false);
        animator.SetBool(is_crying, false);
        animator.SetBool(is_heart_attack, false);
    }

    void SetDirection(Vector2 vector)
    {
        this.SetDirection(GetAngle(vector));
    }

    void SetDirection(float angle)
    {
        if (angle <= 180)
        {
            if (is_right)
            {
                Flip();
                is_right = false;
            }
        }
        else
        {
            if (!is_right)
            {
                Flip();
                is_right = true;
            }

            angle = 360 - angle;
        }

        if (angle < 22.5)
        {
            if (current_direction != is_B)
            {
                current_direction = is_B;
                SetDirection(is_B);
            }
        }
        else if (angle < 67.5)
        {
            if (current_direction != is_RB)
            {
                current_direction = is_RB;
                SetDirection(is_RB);
            }
        }
        else if (angle < 112.5)
        {
            if (current_direction != is_R)
            {
                current_direction = is_R;
                SetDirection(is_R);
            }
        }
        else if (angle < 157.5)
        {
            if (current_direction != is_RF)
            {
                current_direction = is_RF;
                SetDirection(is_RF);
            }
        }
        else
        {
            if (current_direction != is_F)
            {
                current_direction = is_F;
                SetDirection(is_F);
            }
        }
    }

    void SetDirection(string direction)
    {
        //Debug.Log($"direction = {direction}");
        SetAllDirectionsFalse();
        animator.SetBool(direction, true);
    }

    void SetAllDirectionsFalse()
    {
        animator.SetBool(is_F, false);
        animator.SetBool(is_RF, false);
        animator.SetBool(is_R, false);
        animator.SetBool(is_RB, false);
        animator.SetBool(is_B, false);
    }
}
