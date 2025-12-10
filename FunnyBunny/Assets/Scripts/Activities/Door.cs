using UnityEngine;
using UnityEngine.EventSystems;

public class Door : Bebebe, Activities, IPointerDownHandler
{
    [SerializeField]
    float timer = 0.5f;
    [SerializeField]
    Animator anim;


    public bool IsActive()
    {
        return isActive;
    }

    protected override void OnActivate()
    {
        Debug.Log("DOOOR");
        
        anim.SetTrigger("Player");
        mainController.playerScript.animator.SetTrigger("Activity"); // override base
        gameObject.layer = LayerMask.NameToLayer("NoColli");
    }
    public int GetKey()
    {
        return 0;
    }
    public void MakeActive()
    {
    }
    public void Trigger()
    {       // на будущее
        if (!isActive)
        {
            anim.SetTrigger("Dedus");
        }

    }

    public Point GetPoint()
    {
        return point;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("MP");

    }
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        point = new Point(gameObject, 0.5f);

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
