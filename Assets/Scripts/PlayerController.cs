using UnityEngine;
using Component = System.ComponentModel.Component;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerInputController _playerInputController;
   

    //public Transform orientation;

    private void Start()
    {
        _playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        //movement for player, take the player inputs received by the InputActionSystem via PlayerInputController and multiply them with an interchangeable variable speed to get the movement. Delta time to run frame independently.
        
        /*Vector3 positionChange = new Vector3
        (_playerInputController.PlayerInputVector.x, 0,
            _playerInputController.PlayerInputVector.y) * (speed * Time.deltaTime);
        transform.position += (positionChange, Space.Self);*/
        
        // we take the unput we get from the playerInputController and multiply it once with our predefined speed and also the delta time so we dont have to worry about framerate impacting our game. Afterwards we define that the movement should happen in the "self" space meaning on the local and not the global axis.
       transform.Translate(new Vector3(_playerInputController.PlayerInputVector.x, 0,
           _playerInputController.PlayerInputVector.y) * (speed * Time.deltaTime), Space.Self);
        
    }

    private void FixedUpdate()
    {
        // transform.Rotate(0, orientation.eulerAngles.y, 0);
    }
}