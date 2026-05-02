using UnityEngine;

namespace InteractiveSystem.Components
{
    public class PlayerRaycast : MonoBehaviour
    {
        //initialise PLayerInputController so we have access to KeyboardInput
        private PlayerInputController _playerInputController;
        public static float DistanceFromTarget;

        //serialized field to be able to see what changes in Inspector.
        [SerializeField] private float distanceToTarget;

        private Interactable _focused;

        RaycastHit _hit;

        // Update is called once per frame
        void Update()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit))
            {
                //DEBUGGING
                /*Debug.Log(_hit.distance);
                Debug.Log(_hit.transform.name);
                Debug.DrawLine(transform.position, _hit.point, Color.red);
                string objectTag = _hit.transform.gameObject.tag;
                Debug.Log(objectTag);*/
                //==================================
                
                CheckFocused();
                CheckRaycastHit();


                //_focused = _hit.transform.gameObject.GetComponent<Interactable>();

                /*_focused = _hit.transform.CompareTag("Interactable") ? _hit.transform.gameObject.GetComponent<Interactable>() : null;
                if (_focused is not null)
                {
                    CheckForInteraction();
                }*/


            }
            /*else 
            {
                _focused = _hit.transform.gameObject.GetComponent<Interactable>();
                if (_focused.transform.CompareTag("Interactable") && distanceToTarget < 2.5)
                {
                    _focused.OnFocusGained();
                }
                
            }*/
        }

        private void CheckFocused()
        {
            if (_focused is null)
                return;
                    
            _focused.OnFocusLost();
            _focused = null;
        }

        private void CheckRaycastHit()
        {
            if (_hit.transform.CompareTag("Interactable"))
            {
                _focused = _hit.transform.gameObject.GetComponent<Interactable>();
                _focused.OnFocusGained();
            }
            else return;
        }


        /*
        private void Interact()
        {
            if (_focused.OnFocusGained)
        }*/
    }
}