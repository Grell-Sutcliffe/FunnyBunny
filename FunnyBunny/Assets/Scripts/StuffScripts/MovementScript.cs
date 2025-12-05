using System.Collections.Generic;
using UnityEngine;

public abstract class MovementScript : MonoBehaviour
{
    public class Point
    {
        public GameObject point_GO;
        public float wait_time;

        public Point()
        {
            point_GO = null;
            wait_time = 0;
        }

        public Point(GameObject point)
        {
            this.point_GO = point;
            wait_time = 0;
        }

        public Point(GameObject point, float wait_time)
        {
            this.point_GO = point;
            this.wait_time = wait_time;
        }
    }

    public GameObject movement_points_GO;

    //protected List<GameObject> list_of_movement_points;
    protected List<Point> list_of_movement_points;

    public float move_speed = 1f;
    //public float wait_on_point = 0.5f;

    int current_point_index;

    Coroutine moveCoroutine;

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

    }

    protected System.Collections.IEnumerator MoveAlongPointsLoop()
    {
        if (list_of_movement_points.Count == 0)
            yield break;

        transform.position = list_of_movement_points[0].point_GO.transform.position;

        while (true)
        {
            GameObject targetPoint = list_of_movement_points[current_point_index].point_GO;
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

            current_point_index = (current_point_index + 1) % list_of_movement_points.Count;
        
            yield return new WaitForSeconds(list_of_movement_points[current_point_index].wait_time);
        }
    }

    protected void FillListOfMovementPoints()
    {
        list_of_movement_points = new List<Point>();

        foreach (Transform child in movement_points_GO.transform)
        {
            list_of_movement_points.Add(new Point(child.gameObject, 0.5f));
        }
    }
}
