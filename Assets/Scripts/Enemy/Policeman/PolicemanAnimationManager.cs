using UnityEngine;

public class PolicemanAnimationManager : MonoBehaviour
{
    [SerializeField] Animator policemanAnimator;
    
    private bool isWalking;
    
    [SerializeField] private int intStatement;

    private void Update()
    {
        isWalking = true;
        MakeTransition();
    }

    private void MakeTransition()
    {
        if (isWalking)
        {
            intStatement = 0;
            SwitchIntStatement(intStatement);
        }
    }

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