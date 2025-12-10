using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class asdasd : Bebebe, Activities, IPointerDownHandler
{
    [SerializeField]
    float timer = 0.5f;
    protected override void Start()
    {
        base.Start();
        point = new Point(gameObject, timer);
        
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
        Instantiate(mainController.RetPref(2), transform.position, Quaternion.identity);
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
