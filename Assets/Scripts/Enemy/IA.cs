using UnityEngine;

public abstract class IA : MonoBehaviour
{
    protected Rigidbody2D enemyRigidbody2D;

    protected Transform player;

    [SerializeField] protected bool direction; //left = false, right = true

    [SerializeField] protected float speed, distanceToHitPlayer = 1f, speedToAttackPlayer = 3f, walkingSpeed = 2f;

    protected SpriteRenderer enemySpriteRenderer;

    protected LayerMask layerDetectPlayer, layerGround;

    [SerializeField] protected Vector2 enemyHeight = new Vector2(1f, 2f);

    [SerializeField] protected float distanceToDetectPlayer = 10f;

    [SerializeField] protected float playerDetectionHeight = 2f;

    [SerializeField] private bool drawCirclesEditor;
    
    protected RaycastHit2D RaycastDetectNotVoid
    {
        get
        {
            Debug.DrawRay(
                new Vector2(transform.position.x, transform.position.y) +
                (direction ? Vector2.right : Vector2.left) * enemyHeight.x, Vector2.down * enemyHeight.y);
            return Physics2D.Raycast(
                new Vector2(transform.position.x, transform.position.y) +
                (direction ? Vector2.right : Vector2.left) * enemyHeight.x, Vector2.down, enemyHeight.y * 1.5f,
                layerGround);
        }
    }

    protected RaycastHit2D IsGrounded
    {
        get { return Physics2D.Raycast(transform.position, Vector2.down, enemyHeight.y, layerGround); }
    }

    protected RaycastHit2D RaycastHitWall
    {
        get
        {
            return Physics2D.CapsuleCast(transform.position, new Vector2(0.1f, enemyHeight.y - 0.1f),
                CapsuleDirection2D.Vertical, 0, direction ? Vector2.right : Vector2.left, enemyHeight.x, layerGround);
        }
    }

    protected bool DetectPlayer
    {
        get
        {
            return Mathf.Abs(transform.position.y - player.position.y) < playerDetectionHeight &&
                   RaycastDetectPlayer &&
                   RaycastDetectPlayer.transform.CompareTag("Player");
        }
    }

    private RaycastHit2D RaycastDetectPlayer
    {
        get
        {
            return Physics2D.Raycast(transform.position, player.position - transform.position, distanceToDetectPlayer,
                layerDetectPlayer);
        }
    }

    private void Start()
    {
        enemyHeight.x *= 0.7f;
        enemyHeight.y += 0.1f;
        speed = walkingSpeed;
        layerGround = LayerMask.GetMask("Ground") | LayerMask.GetMask("IADontCollide");
        layerDetectPlayer = LayerMask.GetMask("Ground") | LayerMask.GetMask("Player") |
                            LayerMask.GetMask("IADontCollide");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (!IsGrounded) return;
        StateManager();
        AtkPlayer();
    }

    protected abstract void StateManager();

    protected void AtkPlayer()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, player.position - transform.position,
            distanceToHitPlayer, layerDetectPlayer);
        if (hit2D && hit2D.transform.CompareTag("Player")) Destroy(player.parent.gameObject);
    }

    protected void RunToDirection()
    {
        enemyRigidbody2D.velocity = new Vector2(direction ? speed : -speed, enemyRigidbody2D.velocity.y);
        enemySpriteRenderer.flipX = direction ? false : true;
    }

    void OnDrawGizmos()
    {
        if (!drawCirclesEditor) return;
        Gizmos.DrawWireSphere(transform.position, distanceToDetectPlayer);
    }
}