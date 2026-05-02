using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 PlayerInputVector { get; private set; }
    public float PlayerInput { get; private set; }


    //define that we receive an InputValue from the UnityEngine
    private void OnMove(InputValue inputValue)
    {
        //Debug.Log(inputValue.Get<Vector2>());
        PlayerInputVector = inputValue.Get<Vector2>();
    }

    private void OnInteract(InputValue inputValue){
        //Debug.Log(inputValue.Get<float>());
        PlayerInput = inputValue.Get<float>();
    }
}