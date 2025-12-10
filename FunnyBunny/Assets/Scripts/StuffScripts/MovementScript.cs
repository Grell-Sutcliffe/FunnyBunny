using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MovementScript : MonoBehaviour
{
    public Transform player;
    public GameObject player_GO;

    public GameObject movement_points_GO;
    public GameObject root;

    protected List<Activities> list_of_movement_points;
    public float move_speed = 1f;
    public float chase_speed = 0.6f;

    protected int current_point_index;
    protected bool need_to_move = true;
    protected bool need_to_chase_bunny = true;

    protected bool is_chasing = false;

    protected float speed = 1f;
    protected float stop_distance = 0.03f;
    protected bool rotate_towards = false;

    public bool was_bunny_hit = false;

    protected bool is_right;

    protected Animator animator;

    protected string is_walking = "is_walking";
    protected string is_angry = "is_angry";
    protected string is_crying = "is_crying";
    protected string is_heart_attack = "is_heart_attack";
    protected string is_sleeping = "is_sleeping";
    protected string is_happy = "is_happy";

    protected string player_tag = "PlayerCollider";

    protected Vector2 step = Vector2.zero;

    Coroutine moveCoroutine;

    protected SpriteRenderer sprite;

    protected GameObject target;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = root.GetComponent<Animator>();
        sprite = root.GetComponent<SpriteRenderer>();

        FillListOfMovementPoints();

        if (list_of_movement_points.Count > 0)
        {
            moveCoroutine = StartCoroutine(MoveAlongPointsLoop());
        }
    }

    protected virtual void FixedUpdate()
    {
        /*
        if (need_to_chase_bunny && need_to_move && is_chasing && player != null)
        {
            target = player_GO;
        }
        */

        if (!need_to_move || target == null)
        {
            animator.SetBool(is_walking, false);
            return;
        }

        Vector2 toTarget = (Vector2)target.transform.position - (Vector2)this.transform.position;
        float dist = toTarget.magnitude;

        if (dist <= stop_distance)
        {
            animator.SetBool(is_walking, false);
            return;
        }

        animator.SetBool(is_walking, true);

        if (is_chasing)
        {
            speed = chase_speed;
        }
        else
        {
            speed = move_speed;
        }
        step = toTarget.normalized * speed * Time.fixedDeltaTime;

        if (rb != null) rb.MovePosition(rb.position + step);
    }

    protected float GetAngle(Vector2 vector)
    {
        float angleRad = Mathf.Atan2(vector.y, vector.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;

        float angle = (90f - angleDeg + 360f) % 360f;

        return angle;
    }

    protected virtual void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(player_tag))
        {
            Debug.Log("OnTriggerEnter");
            is_chasing = true;

            if (need_to_chase_bunny)
            {
                target = player_GO;

                if (moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                    moveCoroutine = null;
                }
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(player_tag))
        {
            is_chasing = false;

            if (moveCoroutine == null && list_of_movement_points.Count > 0)
            {
                moveCoroutine = StartCoroutine(ReturnToRouteAndPatrol());
            }
        }
    }

    protected System.Collections.IEnumerator MoveAlongPointsLoop()
    {
        if (list_of_movement_points.Count == 0)
            yield break;

        if (current_point_index < 0 || current_point_index >= list_of_movement_points.Count)
            current_point_index = 0;

        Debug.Log("START CORUTINE");

        while (true)
        {
            GameObject targetPoint = list_of_movement_points[current_point_index].GetPoint().point_GO;
            target = targetPoint;
            Debug.Log("HELP");

            while (Vector2.Distance(transform.position, targetPoint.transform.position) > stop_distance)
            {
                yield return null;
            }

            yield return new WaitForSeconds(list_of_movement_points[current_point_index].GetPoint().wait_time);

            list_of_movement_points[current_point_index].Trigger();

            current_point_index = (current_point_index + 1) % list_of_movement_points.Count;
        }
    }

    protected int GetNearestPointIndex()
    {
        int nearestIndex = 0;
        float minSqrDist = float.MaxValue;

        for (int i = 0; i < list_of_movement_points.Count; i++)
        {
            Vector3 p = list_of_movement_points[i].GetPoint().point_GO.transform.position;
            float sqrDist = (p - transform.position).sqrMagnitude;

            if (sqrDist < minSqrDist)
            {
                minSqrDist = sqrDist;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }

    protected System.Collections.IEnumerator ReturnToRouteAndPatrol()
    {
        if (list_of_movement_points.Count == 0)
            yield break;

        if (current_point_index < 0 || current_point_index >= list_of_movement_points.Count)
            current_point_index = 0;

        while (true)
        {
            var pointData = list_of_movement_points[current_point_index].GetPoint();
            GameObject targetPoint = pointData.point_GO;

            target = targetPoint;

            while (Vector2.Distance(transform.position, targetPoint.transform.position) > stop_distance)
            {
                yield return null;
            }

            yield return new WaitForSeconds(pointData.wait_time);

            list_of_movement_points[current_point_index].Trigger();

            current_point_index = (current_point_index + 1) % list_of_movement_points.Count;
        }
    }

    protected void FillListOfMovementPoints()
    {
        list_of_movement_points = movement_points_GO.GetComponentsInChildren<MonoBehaviour>().OfType<Activities>().ToList();
    }
}
