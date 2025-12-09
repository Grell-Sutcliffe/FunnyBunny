using UnityEngine;

public class DoggyMovementScript : MovementScript
{
    DoggyController doggyController;

    float saw_bunny_anger_amount = 0.05f;

    Rigidbody2D rb;

    string is_F = "is_F";
    string is_RF = "is_RF";
    string is_R = "is_R";
    string is_RB = "is_RB";
    string is_B = "is_B";

    string current_direction;

    void Awake() => rb = GetComponentInChildren<Rigidbody2D>();

    protected override void Start()
    {
        doggyController = GetComponent<DoggyController>();

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

        if (other.CompareTag(player_tag))
        {
            animator.SetBool(is_angry, true);
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (other.CompareTag(player_tag))
        {
            StartAngerAnimation();
        }
    }

    void StartAngerAnimation()
    {
        need_to_move = false;

        animator.SetBool(is_crying, true);
    }

    public void StopAngerAnimation()
    {
        SetAllAngerParametersFalse();
        need_to_move = true;
    }

    public void SetAllAngerParametersFalse()
    {
        animator.SetBool(is_walking, true);
        animator.SetBool(is_angry, false);
        animator.SetBool(is_crying, false);
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
        Debug.Log($"direction = {direction}");
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
