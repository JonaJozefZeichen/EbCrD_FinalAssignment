using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private PlayerInputController _playerInputController;

    private void Start(){
        _playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        Vector3 positionChange = new Vector3
                                 (_playerInputController.MovementInputVector.x, 0,
                                     _playerInputController.MovementInputVector.y) *
                                 Time.deltaTime * speed;

        transform.position += positionChange;
    }
}