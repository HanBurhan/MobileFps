using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float sphereRadius;
    [SerializeField] float jumpDistance;
    [SerializeField] float walkSpeed;

    [SerializeField] FixedJoystick joystick;

    [SerializeField] LayerMask groundmask;

    [SerializeField] Transform sphereCenter;

    [SerializeField] private Animator anim;

    private static float gravity = -9.81f;

    private CharacterController controller;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (OnGround() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        InputMove();
        UseGravity();
    }

    private void InputMove()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 moveDir = transform.right * x + transform.forward * z;

        bool playerMoving = x != 0 || z != 0;

        anim.SetBool("Walk", playerMoving);

        controller.Move(moveDir * walkSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (OnGround())
        {
            velocity.y = Mathf.Sqrt(jumpDistance * -2f * gravity);
        }
    }

    private bool OnGround()
    {
        return Physics.CheckSphere(sphereCenter.position, sphereRadius, groundmask);
    }

    private void UseGravity()
    {
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
