using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    Player playerScript;
    public GameObject prefPoper;
    public static MainController Instance { get; private set; }
    // [SerializeField] GameObject healthBar;
    [SerializeField]  
    GameObject inventory;
    public List<InventoryScript> ListInventories = new List<InventoryScript>();

    [SerializeField]
    Image defImagemda;

    List<int> FillInv = new List<int>(new int[10]);
    public void AddToInv(Item item)
    {   int value = item.id;
        for (int i = 0; i < FillInv.Count; i++)
        {
            if (FillInv[i] == 0)
            {
                FillInv[i] = value; // there will not be more than 10
                ListInventories[i].SetNewItem(item);
                Debug.Log(value); 
                return;
            }
        }
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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
   
}
