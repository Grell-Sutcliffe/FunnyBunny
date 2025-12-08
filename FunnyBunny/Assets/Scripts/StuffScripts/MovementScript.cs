using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MovementScript : MonoBehaviour
{
    public Transform player;
    public GameObject player_GO;

    public GameObject movement_points_GO;

    //protected List<GameObject> list_of_movement_points;
    //protected List<Point> list_of_movement_points;
    protected List<Activities> list_of_movement_points;
    public float move_speed = 1f;
    public float chase_speed = 0.6f;
    //public float wait_on_point = 0.5f;

    protected int current_point_index;

    bool is_chasing = false;

    Coroutine moveCoroutine;

    protected GameObject target;

    protected virtual void Start()
    {
        FillListOfMovementPoints();

        if (list_of_movement_points.Count > 0)
        {
            moveCoroutine = StartCoroutine(MoveAlongPointsLoop());
        }
    }

    protected void Update()
    {
        if (is_chasing && player != null)
        {
            //Debug.Log("Chase");
            target = player_GO;

            Vector3 targetPos = player.position;

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                chase_speed * Time.deltaTime
            );
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter");
            is_chasing = true;

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                moveCoroutine = null;
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
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

        while (true)
        {
            GameObject targetPoint = list_of_movement_points[current_point_index].GetPoint().point_GO;

            target = targetPoint;

            Vector3 targetPos = targetPoint.transform.position;

            while (Vector3.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPos,
                    move_speed * Time.deltaTime
                );

                yield return null;
            }

            transform.position = targetPos;

            yield return new WaitForSeconds(list_of_movement_points[current_point_index].GetPoint().wait_time);
            list_of_movement_points[current_point_index].Trigger();// ??????
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

        int nearestIndex = GetNearestPointIndex();
        GameObject targetPoint = list_of_movement_points[nearestIndex].GetPoint().point_GO;

        target = targetPoint;

        Vector3 targetPos = targetPoint.transform.position;

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                move_speed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = targetPos;

        current_point_index = nearestIndex;

        moveCoroutine = StartCoroutine(MoveAlongPointsLoop());
    }

    protected void FillListOfMovementPoints()
    {
        list_of_movement_points = movement_points_GO.GetComponentsInChildren<MonoBehaviour>().OfType<Activities>().ToList();
    }
}
