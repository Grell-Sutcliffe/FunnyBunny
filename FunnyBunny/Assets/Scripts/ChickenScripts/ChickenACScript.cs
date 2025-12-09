using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChickenACScript : MonoBehaviour
{
    public GameObject movement_points_GO;
    public GameObject root;

    List<Point> list_of_movement_points;
    public float move_speed = 1f;
    public float chase_speed = 0.6f;

    int current_point_index;
    bool need_to_move = true;

    float speed = 1f;
    float stop_distance = 0f;
    bool rotate_towards = false;

    bool is_right;

    Animator animator;

    string is_walking = "is_walking";
    string is_crying = "is_crying";

    Vector2 step = Vector2.zero;

    Coroutine moveCoroutine;

    SpriteRenderer sprite;

    GameObject target;

    void Start()
    {
        animator = root.GetComponent<Animator>();
        sprite = root.GetComponent<SpriteRenderer>();

        FillListOfMovementPoints();

        if (list_of_movement_points.Count > 0)
        {
            moveCoroutine = StartCoroutine(MoveAlongPointsLoop());
        }
    }

    void FixedUpdate()
    {
        if (!need_to_move)
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

        step = toTarget.normalized * speed * Time.fixedDeltaTime;

        SetDirection(step);
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
    }

    float GetAngle(Vector2 vector)
    {
        float angleRad = Mathf.Atan2(vector.y, vector.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;

        float angle = (90f - angleDeg + 360f) % 360f;

        return angle;
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
        //sprite.flipY = !sprite.flipY;
    }

    System.Collections.IEnumerator MoveAlongPointsLoop()
    {
        if (list_of_movement_points.Count == 0)
            yield break;

        if (current_point_index < 0 || current_point_index >= list_of_movement_points.Count)
            current_point_index = 0;

        while (true)
        {
            GameObject targetPoint = list_of_movement_points[current_point_index].point_GO;

            target = targetPoint;

            Vector3 targetPos = targetPoint.transform.position;

            while (Vector3.Distance(transform.position, targetPos) > 0.01f)
            {
                if (need_to_move)
                {
                    transform.position = Vector3.MoveTowards(
                        transform.position,
                        targetPos,
                        move_speed * Time.deltaTime
                    );
                }

                yield return null;
            }

            transform.position = targetPos;
            current_point_index = (current_point_index + 1) % list_of_movement_points.Count;
        }
    }

    int GetNearestPointIndex()
    {
        int nearestIndex = 0;
        float minSqrDist = float.MaxValue;

        for (int i = 0; i < list_of_movement_points.Count; i++)
        {
            Vector3 p = list_of_movement_points[i].point_GO.transform.position;
            float sqrDist = (p - transform.position).sqrMagnitude;

            if (sqrDist < minSqrDist)
            {
                minSqrDist = sqrDist;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }

    System.Collections.IEnumerator ReturnToRouteAndPatrol()
    {
        if (list_of_movement_points.Count == 0)
            yield break;

        int nearestIndex = GetNearestPointIndex();
        GameObject targetPoint = list_of_movement_points[nearestIndex].point_GO;

        target = targetPoint;

        Vector3 targetPos = targetPoint.transform.position;

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            if (need_to_move)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPos,
                    move_speed * Time.deltaTime
                );
            }

            yield return null;
        }

        transform.position = targetPos;

        current_point_index = nearestIndex;

        moveCoroutine = StartCoroutine(MoveAlongPointsLoop());
    }

    void FillListOfMovementPoints()
    {
        list_of_movement_points = movement_points_GO.GetComponentsInChildren<MonoBehaviour>().OfType<Point>().ToList();
    }

    public void ChickenCry()
    {
        animator.SetBool(is_walking, false);
        animator.SetBool(is_crying, true);
    }
}
