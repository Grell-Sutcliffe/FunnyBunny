using UnityEngine;
using UnityEngine.EventSystems;

public class LayItem : MonoBehaviour, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    protected Item item;
    protected MainController mainController;

    public bool isTrap = false;
    protected void Start()
    {
        //item.sprite = GetComponent<SpriteRenderer>().sprite;
        mainController = MainController.Instance;
    }

    // Update is called once per frame
    protected void Update()
    {
        //Debug.Log(item.sprite);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Apple");
        float dist = Vector3.Distance(mainController.GetPlayerPos(), transform.position);

        if (dist <= 2f)   
        {
            Instantiate(mainController.prefPoper, transform.position, Quaternion.identity);
            mainController.AddToInv(item);
            Destroy(gameObject);
        }
    }
}
