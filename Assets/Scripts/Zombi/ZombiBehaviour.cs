using UnityEngine;

public class ZombiBehaviour : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    Transform player;

    private bool zombiAlive;
    private bool zombiDetect;
    private bool zombiAttack;

    private float zombiWalkSpeed = 1f;
    private float zombiRunSpeed = 2f;
    private float zombiIdleSpeed = 0;
    private float animationSpeed;

    [Header("Stats")]
    public float runSpeed;
    public float zombiHealth;
    public float damgeAmount;

    [Header("Player Check")]
    public Transform detectPos;
    public float detectRadius;
    public LayerMask playerLayer;

    [Header("Attack Check")]
    public float attackRadius;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        zombiDetect = Physics.CheckSphere(detectPos.position, detectRadius, playerLayer);
        zombiAttack = Physics.CheckSphere(detectPos.position, attackRadius, playerLayer);

        animationSpeed = zombiDetect ? zombiRunSpeed : zombiIdleSpeed;

        animator.SetBool("Attack", zombiAttack);
        animator.SetFloat("ZombiSpeed", animationSpeed);

        if (zombiDetect)
        {
            LookPlayer();
        }

        if (zombiHealth <= 0)
        {
            ZombiFall();
        }
    }

    private void LookPlayer()
    {
        //Look To Player
        Vector3 lookOffset = player.position - transform.position;

        Quaternion lookRot = Quaternion.LookRotation(lookOffset);

        transform.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);
    }

    public void FollowPlayer()
    {
        rb.velocity = transform.forward * runSpeed;
    }

    public void ZombiAttack()
    {
        player.GetComponent<CharacterDamage>().playerHealth -= damgeAmount;
    }

    private void ZombiFall()
    {
        animator.SetBool("Die", true);
    }

    public void DestroyZombi()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectPos.position, detectRadius);
        Gizmos.DrawWireSphere(detectPos.position, attackRadius);
    }
}
