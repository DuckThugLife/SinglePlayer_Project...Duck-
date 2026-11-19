using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Class References")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerInputHandler _inputHandler;


    [Header("Variables")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform cameraPivot;

    [SerializeField] private float mouseSensitivity = 120f;
    [SerializeField] private float pitchMin = -60f;
    [SerializeField] private float pitchMax = 75f;

    [field: SerializeField] private bool turningEnabled = true;

    private float pitch;
    private float verticalVelocity = 0f;



    private void Update()
    {
        Vector2 moveInput = _inputHandler.Move;
        Vector2 lookInput = _inputHandler.Look;
        bool jumpPressed = _inputHandler.JumpPressed;

        MoveCharacter(moveInput);
        Jump(jumpPressed);
        TurnCharacter(lookInput);
    }

    private void MoveCharacter(Vector2 moveInput)
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        move *= walkSpeed;
        move.y = verticalVelocity;

        _characterController.Move(move * Time.deltaTime);
    }

    private void TurnCharacter(Vector2 lookInput)
    {
        if (!turningEnabled) return;
        float yaw = lookInput.x * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * yaw);

        pitch -= lookInput.y * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    private void Jump(bool jumpPressed)
    {
        if (_characterController.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -0.1f;

            if (jumpPressed)
                verticalVelocity = jumpPower;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }

}
