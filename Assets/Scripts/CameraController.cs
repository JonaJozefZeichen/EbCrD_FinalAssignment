using UnityEngine;

public class CameraController : MonoBehaviour
{
    private MouseInputController _mouseInputController;
    
    public Transform orientation;

    private Vector2 _cameraRotation;
    
    [SerializeField] private float sensitivity;


    private void Start()
    {
        //define where the inputs come from, so we can use the previously defined mouse inputs in the code
        _mouseInputController = GetComponent<MouseInputController>();
        
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        
    }

    private void FixedUpdate()
    {
        //use fixed update so everything is smoother and not impacted by frames
        //define the mouse positions again
        float mouseX = _mouseInputController.MouseInputVector.x * Time.deltaTime * sensitivity;
        float mouseY = _mouseInputController.MouseInputVector.y * Time.deltaTime * sensitivity;
        //use them in a simple calculation allowing us to move the camera as we wish form the players perspective
        _cameraRotation = new Vector2(-mouseY, mouseX);
        transform.eulerAngles = _cameraRotation;

        //rotates the orientation of the object defined in the Inspector
        orientation.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}