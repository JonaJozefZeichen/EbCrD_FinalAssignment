using UnityEngine;

public class CameraController : MonoBehaviour
{
    private MouseInputController _mouseInputController;
    
    
    [SerializeField] private float sensitivity;
    
    public Transform orientation;
    
    private Vector3 _cameraRotation;
  

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //define where the inputs come from, so we can use the previously defined mouse inputs in the code
        _mouseInputController = GetComponent<MouseInputController>();
    }

    private void FixedUpdate()
    {
        //use fixed update so everything is smoother and not impacted by frames
        //define the mouse positions again
        float mouseX = _mouseInputController.MouseInputVector.x * Time.deltaTime * sensitivity;
        float mouseY = _mouseInputController.MouseInputVector.y * Time.deltaTime * sensitivity;
        //use them in a simple calculation allowing us to move the camera as we wish form the players perspective
        _cameraRotation = new Vector3(-mouseY, mouseX, 0);
        transform.eulerAngles = _cameraRotation;
        
        //rotates the orientation of the object defined in the Inspector
        orientation.rotation = Quaternion.Euler(0,mouseX,0);
    }
}