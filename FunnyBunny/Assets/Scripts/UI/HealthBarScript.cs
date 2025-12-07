using Unity.VisualScripting;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    GameObject healthBarFilling;

    RectTransform healthBar_rectTransform;

    void Start()
    {
        healthBar_rectTransform = healthBarFilling.GetComponent<RectTransform>();

        SetHealthFull();
    }

    void SetHealthFull()
    {
        SetHealthBarPercent(1);
    }

    public void SetHealthBarPercent(float percent)
    {
        Vector3 new_localScale = healthBar_rectTransform.localScale;
        new_localScale.x = percent;
        healthBar_rectTransform.localScale = new_localScale;
    }
}
