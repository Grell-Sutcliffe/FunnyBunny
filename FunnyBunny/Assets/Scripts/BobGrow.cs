using UnityEngine;
using UnityEngine.EventSystems;

public class BobGrow : Bebebe, Activities, IPointerDownHandler
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
        Debug.Log("GROWWWWW");
        if (mainController.Growed) return;
        animator.SetTrigger("OPEN");
        
    }

    public void SpawnSosages()
    {
        Instantiate(mainController.RetPref(4), transform.position, Quaternion.identity);
        mainController.Growed = true;   

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

    private void OnTriggerEnter2D(Collider2D collision) // add tag !!!!!!!
    {
        Debug.Log(12123);
        if (collision.CompareTag("Enemy"))
        {
            isActive = true;
            Trigger();

        }
    }

    public void Trigger()
    {
        if (!isActive)
        {
            Debug.Log("AAAAAAAAAA");
            return;
        }
        Debug.Log("added");
        animator.SetTrigger("hit");
        Debug.Log($"trigered {0.7f}");
        mainController.FC.ChangeAngerPercent(0.7f);



    }
    // Update is called once per frame
    void Update()
    {

    }
}
