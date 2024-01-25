using Unity.Mathematics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float cooldownToShoot = 0.5f;
    [SerializeField] private float timeToShoot = 0f;

    [SerializeField] private AudioClip shootAudio;
    
    private void Start()
    {
        InputReader._instance.onShootEvent.AddListener(ShootBullet);
    }

    private void Update()
    {
        timeToShoot += Time.deltaTime;
    }

    private void ShootBullet()
    {
        if (timeToShoot >= cooldownToShoot)
        {
            AudioManager._instance.PlaySFX(shootAudio);
            Instantiate(bullet, transform.position, quaternion.identity);
            timeToShoot = 0f;
        }
    }
}
