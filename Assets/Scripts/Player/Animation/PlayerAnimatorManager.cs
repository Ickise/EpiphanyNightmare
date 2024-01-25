using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    [SerializeField] private PlayerRaycastDetection _playerRaycastDetection;

    [SerializeField] private PolygonCollider2D playerCollider2D;

    [SerializeField] private int intStatement;

    private void Start()
    {
        InputReader._instance.onCounterEvent.AddListener(CounterAnimation);
    }

    private void Update()
    {
       MakeTransition();
    }

    private void MakeTransition()
    {
       // UpdateCollider2D.TryUpdateShapeToAttachedSprite(playerCollider2D);
        
        if (_playerRaycastDetection.isGrounded && InputReader._instance.direction.x == 0 && !InputReader._instance.jump)
        {
            intStatement = 0;
            SwitchIntStatement(intStatement);
        }

        if (_playerRaycastDetection.isGrounded && InputReader._instance.direction.x != 0)
        {
            intStatement = 1;
            SwitchIntStatement(intStatement);
        }

        if (InputReader._instance.jump)
        {
            intStatement = 2;
            SwitchIntStatement(intStatement);
        }
    }
    
    private void CounterAnimation()
    {
        intStatement = 3;
        SwitchIntStatement(intStatement);
    }
    
    private void SwitchIntStatement(int ID)
    {
        switch (ID)
        {
            case 0:
                playerAnimator.SetInteger("State", 0);
                break;

            case 1:
                playerAnimator.SetInteger("State", 1);
                break;
            case 2:
                playerAnimator.SetInteger("State", 2);
                break;
            case 3:
                playerAnimator.SetInteger("State", 3);
                break;
        }
    }
}