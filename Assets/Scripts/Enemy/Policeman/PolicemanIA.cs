public class PolicemanIA : IA
{
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
            }

            else
                return;
        }
        _policemanAnimationManager.intStatement = 0;
        _policemanAnimationManager.SwitchIntStatement(_policemanAnimationManager.intStatement);
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