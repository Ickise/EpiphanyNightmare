using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    private void Start()
    {
        InputReader._instance.onMoveEvent.AddListener(FlipSprite);
    }

    private void FlipSprite()
    {
        transform.rotation = InputReader._instance.direction.x > 0 ?  new Quaternion(transform.rotation.x, 0, transform.rotation.z, 0) :  new Quaternion(transform.rotation.x, 180, transform.rotation.z, 0);
    }
}
