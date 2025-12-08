using UnityEngine;

public abstract class BarController : MonoBehaviour
{
    [SerializeField]
    protected GameObject barFilling;

    protected RectTransform bar_rectTransform;

    protected virtual void Start()
    {
        bar_rectTransform = barFilling.GetComponent<RectTransform>();
    }

    protected void SetBarFull()
    {
        SetBarPercent(1);
    }

    protected void SetBarEmpty()
    {
        SetBarPercent(0);
    }

    public void SetBarPercent(float percent)
    {
        Vector3 new_localScale = bar_rectTransform.localScale;
        new_localScale.x = percent;
        bar_rectTransform.localScale = new_localScale;
    }
}
