using UnityEngine;

public class EnemyController : MonoBehaviour
{
    IMover mover;
    IAttack enemyAttack;
   EnemyLevelManager level;

    [Header("Movement")]
    [SerializeField] private float waitTime;
    [SerializeField] private float startWaitTime;
    [SerializeField] public float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] public Vector3[] moveSpots;
    [SerializeField] int currentSpotindex;

    [Header("Component")]
    [SerializeField] public Animator enemyAnim;
    [SerializeField] Rigidbody rb;

    [Header("Ray -Direction Values")]
    [SerializeField] public float attackRange;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] private int rayCount = 5;
    [SerializeField] private float viewAngle = 45f;

    public Vector3 rayDirection;
    public float _currentAngle;
    float _playerLevel;
    float _enemyLevel;

    void Awake()
    {
        mover = new Movement();
        enemyAttack = new EnemyAttack();
        level=GetComponent<EnemyLevelManager>();
    }

    void Start()
    {
       PlayerLevelManager.Instance.OnGetLevel+=LevelManager_OnGetLevel;

        waitTime = startWaitTime;
        currentSpotindex = Random.Range(0, moveSpots.Length);
    }

    private void LevelManager_OnGetLevel(float level)
    {
            _playerLevel=level;
     }

    void Update()
    {
        _enemyLevel=level.EnemyLevel;
        if (CanSeePlayer())
        {
            if (_enemyLevel > _playerLevel)
            {
                EnemyAttack();
                
                GameManager.Instance.EndGame();
            }
            else if (_playerLevel > _enemyLevel)
            {
                StayStill();
               // Debug.Log($"BU COK GUCLU");
            }
        }
        else
        {
            EnemyMove();
        }
    }

    bool CanSeePlayer()
    {
        float angleStep = viewAngle / (rayCount - 1);
        float startAngle = -viewAngle / 2;

        for (int i = 0; i < rayCount; i++)
        {
            _currentAngle = startAngle + (angleStep * i);
            rayDirection = Quaternion.Euler(0, _currentAngle, 0) * transform.forward;
            if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, attackRange, playerLayer))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    void EnemyMove()
    {
        Vector3 targetPosition = moveSpots[currentSpotindex];
        Vector3 direction = (targetPosition - transform.position).normalized;
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            if (waitTime <= 0)
            {
                currentSpotindex = (currentSpotindex + 1) % moveSpots.Length;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        mover.MoveE(targetPosition, this.transform, speed);
        if (direction != Vector3.zero)
        {
            mover.RotationE(rb, transform, direction, 5f);
            enemyAnim.SetBool("isRuning", true);
        }
        else
        {
            enemyAnim.SetBool("isRuning", false);
        }
    }

    void EnemyAttack()
    {
        enemyAttack.Attack(this.transform, rayDirection, attackRange, playerLayer, this.gameObject, enemyAnim);
    }

    void StayStill()
    {
        speed = 0;
        enemyAnim.SetBool("isRuning", false);
        
    }

  
}
