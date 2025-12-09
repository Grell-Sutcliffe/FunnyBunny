using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject chickens;

    [SerializeField]
    public Player playerScript;
    public GameObject prefPoper;
    public static MainController Instance { get; private set; }
    // [SerializeField] GameObject healthBar;
    [SerializeField]  
    GameObject inventory;
    public List<InventoryScript> ListInventories = new List<InventoryScript>();

    public List<GameObject> prefubsById;

    [SerializeField]
    Image defImagemda;
    public Sprite empty;
    [SerializeField]
    Stalker stalker;
    List<int> FillInv = new List<int>(new int[10]);
    public void AddToInv(Item item)
    {   int value = item.id;
        ListInventories = new List<InventoryScript>(inventory.GetComponentsInChildren<InventoryScript>());
        Debug.Log(ListInventories.Count);
        for (int i = 0; i < ListInventories.Count; i++)
        {
            if (ListInventories[i].item.id == 0)
            {
                ListInventories[i].SetNewItem(item);
                Debug.Log(value); 
                return;
            }
        }
    }
    public GameObject RetPref(int id)
    {
        return prefubsById[id];
    }
    public Vector3 GetPlayerPos()
    {
        return playerScript.GetPos();
    }
    private void Awake() // ??
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // ??
        //Debug.Log(FillInv[0]);
        ListInventories = new List<InventoryScript>(inventory.GetComponentsInChildren<InventoryScript>());
        
    }

    public void ChickenCry()
    {
        // MoveCameraToChickens();

        foreach (Transform child in chickens.transform)
        {
            ChickenACScript chickenScript = child.GetComponent<ChickenACScript>();
            if (chickenScript != null)
            {
                chickenScript.ChickenCry();
            }
        }
    }

    public void ChangeStalkImg(Sprite i)
    {
        stalker.ChangeImg(i);
    }
    public void ReternImg()
    {
        stalker.ChangeImg(empty);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
   
}
