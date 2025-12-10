using UnityEngine;

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
    protected virtual void OnActivate()
    {

    }
    public void Click(int id)  // ›“Œ Õ≈  À» , «¿◊≈Ã ﬂ “¿  —≈¡ﬂ «¿œ”“¿À??? ›“Œ ‚˚Á˚‚‡ÂÚÒˇ ÔË ‡ÍÚË‚‡ˆËË 
    {
        
        float dist = Vector3.Distance(mainController.GetPlayerPos(), transform.position);
        Debug.Log("ASDASDASDSAD");
        if (dist >= 2f)
        {
            return;
        }
        if (id == idActivate)
        {
            if (isActive)
            {
                return; // ‰ÓÔÛÒÚËÏ Ú‡Í
            }
            Debug.Log("ACTIVATED");
            isActive = true;
            OnActivate();
        }
        else
        {
            mainController.playerScript.WrongAnim();

        }
    }
}
