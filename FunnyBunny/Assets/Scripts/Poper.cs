using UnityEngine;
using static UnityEditor.Progress;

public class Poper : MonoBehaviour
{
    public void Des()
    {
        Destroy(gameObject);
    }
}


public abstract class Bebebe : MonoBehaviour
{
    protected MainController mainController;
    protected Animator animator;
    protected Point point;
    protected bool isActive = false;
    [SerializeField]
    protected int idActivate;
    protected virtual void Start()
    {
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
    }

    public void Click(int id)
    {
        float dist = Vector3.Distance(mainController.GetPlayerPos(), transform.position);

        if (dist >= 2f)
        {
            return;
        }
        if (id == idActivate)
        {
            Debug.Log("ACTIVATED");
            isActive = true;
        }
        else
        {
            mainController.playerScript.WrongAnim();

        }
    }
}
