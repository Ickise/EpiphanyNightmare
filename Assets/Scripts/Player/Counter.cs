using UnityEngine;

public class Counter : MonoBehaviour
{
    [Header("À set up")] 
    [SerializeField] private float counterCooldown = 2f, timeToDestroyEnemy = 4f, capsuleAngle = 0f, distanceToDetectEnemy = 0f;

    [SerializeField] private Transform capsuleCastTransform;

    [SerializeField] private Vector2 capsuleSize = new Vector2(1f, 0.1f);
    [SerializeField] private Vector2 force = new Vector2(500, 500);

    [SerializeField] private LayerMask layerEnemy;
    
    [SerializeField] private ParticleSystem _bloodParticles;

    [SerializeField] private ShockWaveManager _shockWaveManager;
    
    [SerializeField] private AudioClip expulseIa;

    private float timeToCounter;

    [SerializeField] private IA _ia;

    private Rigidbody2D enemyRigidbody2D;

    private Collider2D enemyCollider2D;

    private RaycastHit2D capsuleCastHitEnemy;

    private void Start()
    {
        InputReader._instance.onCounterEvent.AddListener(GetIAScript);
    }

    private void Update()
    {
        timeToCounter += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        BumpEnemy();
    }

    private void GetIAScript()
    {
        if (timeToCounter >= counterCooldown)
        {
            _shockWaveManager.CallShockWave();
            timeToCounter = 0;
            InputReader._instance.doCounterAnimation = true;

            
            capsuleCastHitEnemy = Physics2D.CapsuleCast(capsuleCastTransform.position, capsuleSize,
                CapsuleDirection2D.Vertical,
                capsuleAngle, Vector2.right, distanceToDetectEnemy, layerEnemy);

            if (capsuleCastHitEnemy.collider != null)
            {
                _ia = capsuleCastHitEnemy.collider.gameObject.GetComponentInParent<IA>();
            }
        }
    }

    private void BumpEnemy()
    {
        if (_ia != null)
        {
            AudioManager._instance.PlaySFX(expulseIa);
            Instantiate(_bloodParticles, _ia.transform.position, Quaternion.identity);

            enemyRigidbody2D = _ia.GetComponent<Rigidbody2D>();
            enemyCollider2D = _ia.GetComponent<Collider2D>();

            Destroy(_ia);
            enemyCollider2D.isTrigger = true;
            enemyRigidbody2D.velocity = transform.right * force;
            
            Destroy(_ia.gameObject, timeToDestroyEnemy);
        }
    }
}