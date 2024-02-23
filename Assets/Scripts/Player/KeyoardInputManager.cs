using UnityEngine;

public class KeyboardInputManager : MonoBehaviour, IInputManager
{
    public float GetHorizontalInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public bool JumpButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}