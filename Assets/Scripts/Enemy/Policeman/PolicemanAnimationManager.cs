using UnityEngine;

public class PolicemanAnimationManager : MonoBehaviour
{
    [SerializeField] Animator policemanAnimator;

    public int intStatement;
    
    public void SwitchIntStatement(int ID)
    {
        switch (ID)
        {
            case 0:
                policemanAnimator.SetInteger("State", 0);
                break;

            case 1:
                policemanAnimator.SetInteger("State", 1);
                break;
        }
    }
}