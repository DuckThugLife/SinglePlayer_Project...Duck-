using UnityEngine;
using UnityEngine.InputSystem;

public class LockPlayersMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideAndLockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HideAndLockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
