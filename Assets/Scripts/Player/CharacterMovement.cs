using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float sphereRadius;
    [SerializeField] float jumpDistance;
    [SerializeField] float walkSpeed;
    [SerializeField] float crouchHeight;

    [SerializeField] FixedJoystick joystick;

    [SerializeField] LayerMask groundmask;

    [SerializeField] Transform sphereCenter;

    [SerializeField] private Animator anim;

    private static float gravity = -9.81f;
    private float normalHeight = 2f;

    private CharacterController controller;

    private bool isCrouching, canUp;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (OnGround() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.height = isCrouching ? crouchHeight : normalHeight;

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
        isCrouching = false;

        if (OnGround())
        {
            velocity.y = Mathf.Sqrt(jumpDistance * -2f * gravity);
        }
    }

    public void Crouch()
    {
        isCrouching = !isCrouching;
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
