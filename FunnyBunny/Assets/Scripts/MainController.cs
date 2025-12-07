using UnityEngine;

public class MainController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Player playerScript;

    // [SerializeField] GameObject healthBar;

    [SerializeField]
    public GameObject bebebel2;
    public Activities bebebel;
    void Start()
    {
        bebebel = bebebel2.GetComponent<MonoBehaviour>() as Activities;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(1);
            doBebebe();
        }
    }
    public void doBebebe()
    {
        bebebel.MakeActive();
    }
}
