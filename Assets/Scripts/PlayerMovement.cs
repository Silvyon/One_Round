using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private Rigidbody2D rBody;
    private PlayerControls controls;

    private Vector2 moveInput;
    public Vector2 lastMoveInput;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();

        controls.player.move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
            if(moveInput != Vector2.zero)
            {
                lastMoveInput = moveInput.normalized;
            }
        };
        controls.player.move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void FixedUpdate()
    {
        Vector2 newPos = rBody.position + moveInput * movementSpeed * Time.fixedDeltaTime;
        rBody.MovePosition(newPos);
    }
}
;