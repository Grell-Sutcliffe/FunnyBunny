using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    MainController controller;
    [SerializeField]
    Image image;
    [SerializeField]
    public Item item;
    void Start()
    {
        controller = MainController.Instance;
        item.id = 0;
    }


    public void ClearCell()
    {
        image.sprite = controller.empty;
        item.id = 0;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("SLOT MOUSE DOWN");
        Debug.Log(item);
        if (item != null) controller.ChangeStalkImg(image.sprite);
    }


    public void SetNewItem(Item i)
    {
        item = i;
        //Debug.Log(i.sprite);
        UpdateImage();
    }

    public void UpdateImage()
    {
        image.sprite = item.sprite;
    }
    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("bla bla bla");
        Activities current;                         // ???????????
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 point = mouseWorldPos;

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

        Debug.Log(hit.collider);
        current = hit.collider?.GetComponent<Activities>();
        current?.Click(item.id);
        //Debug.Log(current);
        if (current == null)
        {   
            Instantiate(controller.RetPref(item.id), point, Quaternion.identity);

        }

        ClearCell();

        controller.ReternImg();
    }
}
