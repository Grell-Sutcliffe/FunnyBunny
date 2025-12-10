using UnityEngine;

public class UIAnimator : MonoBehaviour
{
    Animator uiAnimator;

    void Start()
    {
        uiAnimator = GetComponent<Animator>();
        if (uiAnimator != null)
        {
            uiAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }
}
