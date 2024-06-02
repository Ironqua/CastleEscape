using UnityEngine;

public class PlayerController : MonoBehaviour
{
    IMover mover;
    IAttack _playerAttack;

    [Header("Component")]
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] Rigidbody playerrigidBody;
    [SerializeField] Animator playerAnim;

    [Header("Move-Attack Values")]
    [SerializeField] float rotationSpeed;
    [SerializeField] public float movementSpeed;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;

    Vector3 rayDirection;
    Vector3 direction;
    

    void Awake()
    {
        _playerAttack = new PlayerAttack();
        mover = new Movement();
    }



    void FixedUpdate()
    {
        PlayerMover();
    }

    void Update()
    {
        mover.RotationP(playerrigidBody, this.transform, direction, rotationSpeed * Time.deltaTime);
        AttackPlayer();
    }

    void PlayerMover()
    {
        direction = new Vector3(fixedJoystick.Horizontal, 0, fixedJoystick.Vertical);
        mover.MoveP(playerrigidBody, direction, movementSpeed * Time.fixedDeltaTime);

        if (direction != Vector3.zero)
        {
            playerAnim.SetBool("isRuning", true);
        }
        else
        {
            playerAnim.SetBool("isRuning", false);
        }
    }

    void AttackPlayer()
    {
        rayDirection = transform.forward;
        _playerAttack.Attack(this.transform, rayDirection, attackRange, enemyLayer, this.gameObject, playerAnim);
        
    }

  


}
