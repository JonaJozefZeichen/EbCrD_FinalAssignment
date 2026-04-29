using UnityEngine;
using UnityEngine.InputSystem;
public class MouseInputController : MonoBehaviour
{
    public Vector2 MouseInputVector { get; private set; }

    
    //define that we receive an InputValue from the UnityEngine
    private void OnMouseMovement(InputValue inputValue)
    {
        //recieves 2 vectors from mouse which we defined in the ActionInputSystem, Vector 2 takes the x and y vectors
        Debug.Log(inputValue.Get<Vector2>());
        MouseInputVector = inputValue.Get<Vector2>();
    }
}
