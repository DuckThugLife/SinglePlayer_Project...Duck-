using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
    }

    public void OnPlayerLook(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
    }

    public void OnPlayerJump(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
    }

}
