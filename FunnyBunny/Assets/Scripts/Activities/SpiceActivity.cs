using UnityEngine;

public class SpiceActivity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // add tag !!!!!!!
    {
        if (collision.CompareTag("Player"))
        {
            Trigger();

        }
    }

    public void Trigger()
    {
        Debug.Log("added");
        animator.SetTrigger("hit");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
