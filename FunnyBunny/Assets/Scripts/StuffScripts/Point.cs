using UnityEngine;

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
