using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpiceActivity : MonoBehaviour, Activities, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    Animator animator;
    Point point;
    bool isActive = false;
    int idActivate = 22;
    void Start()
    {
        animator = GetComponent<Animator>();
        point = new Point(gameObject, 0.5f);
    }
    public int GetKey()
    {
        return idActivate;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("SLOT MOUSE DOWN");
        
    }
    public void Click(int id)
    {
        Debug.Log("ACTIVATED");
        if (id == idActivate)
        {
            isActive = true;
        }
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
    private void OnTriggerEnter2D(Collider2D collision) // add tag !!!!!!!
    {
        if (collision.CompareTag("Respawn"))
        {
            Trigger();

        }
    }

    public void Trigger()
    {
        if (!isActive)
        {
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
