using UnityEngine;

namespace InteractiveSystem.Components
{
    public class PlayerRaycast : MonoBehaviour
    {
        //serialized field to be able to see what changes in Inspector.
        [SerializeField] private float distanceToTarget;

        //initialise PLayerInputController so we have access to KeyboardInput
        private PlayerInputController _playerInputController;
        //define interactible so we have access to IInteractable functions 
        private static Interactable _focused;

        //define Raycast
        RaycastHit _hit;

        private void Start()
        {
            //initialise _playerInputController
            _playerInputController = GetComponent<PlayerInputController>();
        }

 
        // Update is called once per frame
        private void Update()
        {
            //Set up raycast, define origin, raycast direction and output
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit))
            {
                //DEBUGGING
                /*Debug.Log(_hit.distance);
                Debug.Log(_hit.transform.name);
                Debug.DrawLine(transform.position, _hit.point, Color.red);
                string objectTag = _hit.transform.gameObject.tag;
                Debug.Log(objectTag);*/
                //==================================

                
                //functions to check what is focused, what we are hitting and if we can interact
                CheckFocused();
                CheckRaycastHit();
                CheckInteraction();
            }
        }

//check focused object and unfocus it if we are not looking at it, check for null so we dont get a shitton of NUllExeptions when looking into the empty "sky"
        private void CheckFocused()
        {
            if (_focused is null)
                return;

            _focused.OnFocusLost();
            _focused = null;
        }

        //check raycast hit and distance to hit object, so we only make the object focused if we are close enough to make it feel natural to interact with
        private void CheckRaycastHit()
        {
            if (_hit.transform.CompareTag("Interactable") && _hit.distance < 2.5)
            {
                _focused = _hit.transform.gameObject.GetComponent<Interactable>();
                _focused.OnFocusGained();
            }
        }

//check if we can interact with the currently active object, and If we can generally interact so that we dont send out empty calls. CURRENTLY LAGGY AND SENDING OUT INFINITE REPEATING CALLS IF LOOKING AT INTERACTIBLE OBJECT
        private void CheckInteraction()
        {
            if ((_playerInputController.PlayerInputInteraction) &&
                (_focused.transform.gameObject.GetComponent<Interactable>())
               )
            {
                Debug.Log("Interact");
                _focused.Interact();
            }
        }
    }
}