using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class MovementPointScript : MonoBehaviour, Activities
{
    Point point;
    [SerializeField]
    float timer = 0.5f;

    public bool IsActive()
    {
        return false;
    }
    public void MakeActive()
    {
    }
    void Start()
    {
        point = new Point(gameObject, timer);
    }
    public void Trigger()
    {
        
    }

    public Point GetPoint()
    {
        return point;
    }
}
