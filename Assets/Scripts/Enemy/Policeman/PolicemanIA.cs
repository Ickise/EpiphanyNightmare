using UnityEngine;

public class PolicemanIA : IA
{
    [SerializeField] private PolicemanAnimationManager _policemanAnimationManager;

    protected override void StateManager()
    {
        Walking();
        DetectionPlayer();
    }

    private void Walking()
    {
        if (RaycastHitWall || !RaycastDetectNotVoid)
        {
            if (speed == walkingSpeed)
            {
                direction = !direction;
                _policemanAnimationManager.intStatement = 0;
                _policemanAnimationManager.SwitchIntStatement(_policemanAnimationManager.intStatement);
            }

            else
                return;
        }
        RunToDirection();
    }

    private void DetectionPlayer()
    {
        if (DetectPlayer)
        {
            direction = transform.position.x < player.position.x;
            speed = speedToAttackPlayer;
            _policemanAnimationManager.intStatement = 0;
            _policemanAnimationManager.SwitchIntStatement(_policemanAnimationManager.intStatement);
        }
        else
            speed = walkingSpeed;
    }
}