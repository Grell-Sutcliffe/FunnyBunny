using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementPointScript : MonoBehaviour, Activities, IPointerDownHandler
{
    Point point;
    [SerializeField]
    float timer = 0.5f;

    public bool IsActive()
    {
        return false;
    }
    public void Click(int id)
    {

    }
    public int GetKey()
    {
        return 0;
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
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("MP");

    }
  
}
