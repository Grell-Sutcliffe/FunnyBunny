using UnityEngine;
using UnityEngine.EventSystems;

public class SkibidiToilet : Bebebe, Activities, IPointerDownHandler
{
    [SerializeField]
    float timer = 0.5f;
    protected override void Start()
    {
        base.Start();
        point = new Point(gameObject, timer);
        animator = GetComponent<Animator>();

    }
    public bool IsActive()
    {
        return false;
    }

    public int GetKey()
    {
        return 0;
    }
    public void MakeActive()
    {
    }
    public void Trigger()
    {
        animator.SetTrigger("OPEN");
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
