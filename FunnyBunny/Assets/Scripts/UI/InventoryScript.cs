using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    MainController controller;
    [SerializeField]
    Image image;
    Item item;
    void Start()
    {
        controller = MainController.Instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("SLOT MOUSE DOWN");
        
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
    }
}
