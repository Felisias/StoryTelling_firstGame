using UnityEngine;

public class SleepEffectController : MonoBehaviour
{
    public Animator topBarAnimator;
    public Animator bottomBarAnimator;
    public Animator tire;


    public void PlaySleepEffect()
    {
        topBarAnimator.SetTrigger("Sleep");
        bottomBarAnimator.SetTrigger("Sleep");
        tire.SetTrigger("Sleep");

    }
}