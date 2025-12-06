using UnityEngine;

public class SpiceActivity1 : MonoBehaviour, Activities
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    Animator animator;
    Point point;
    bool isActive = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        point = new Point(gameObject, 0.5f);
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
