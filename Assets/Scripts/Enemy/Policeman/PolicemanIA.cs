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
        RunToDirection();
    }

    private void DetectionPlayer()
    {
        if (DetectPlayer)
        {
            direction = transform.position.x < player.position.x;
            speed = speedToAttackPlayer;
        }
        else
            speed = walkingSpeed;
    }
}