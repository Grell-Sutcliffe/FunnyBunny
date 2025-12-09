using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpiceActivity : Bebebe, Activities, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        point = new Point(gameObject, 0.5f);

        base.Start();
    }
    override protected void OnActivate()
    {
        Debug.Log("Максим прав");
    }
    public int GetKey()
    {
        return idActivate;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("SLOT MOUSE DOWN");
        
    }
    
    public Point GetPoint()
    {
        return point;
    }
    public bool IsActive()
    {
        return isActive;
    }
    public void MakeActive()
    {
        isActive = true;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision) // add tag !!!!!!!
    {
        //Debug.Log(12123);
        if (collision.CompareTag("Respawn"))
        {
            Trigger();

        }
    }
    */
    public void Trigger()
    {
        if (!isActive)
        {
            Debug.Log("AAAAAAAAAA");
            return;
        }
        Debug.Log("added");
        animator.SetTrigger("hit");
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
