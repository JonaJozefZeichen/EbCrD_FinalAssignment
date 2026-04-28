using UnityEngine;
using UnityEngine.InputSystem;
public class MouseInputController : MonoBehaviour
{
    public Vector2 MouseInputVector { get; private set; }

    
    //define that we recieve an InpuValue from the UnityEngine
    private void OnMouseMovement(InputValue inputValue)
    {
        Debug.Log(inputValue.Get<Vector2>());
        MouseInputVector = inputValue.Get<Vector2>();
    }
}
