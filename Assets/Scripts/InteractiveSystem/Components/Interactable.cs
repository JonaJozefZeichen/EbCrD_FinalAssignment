using InteractiveSystem.Interfaces;
using UnityEngine;
using UnityEngine.Events;


namespace InteractiveSystem.Components
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string displayName = "Interact";

        [SerializeField] private bool isEnabled = true;

        //this will be the action we want to perform when interacting with the object (e.g script which tells Flower to be picked up.)
        [SerializeField] private UnityEvent onInteract;
        //Define transfrom so we can react to hitboxes of other objects
        public Transform Transform { get; }
        //check for display name of interactible, defined in IInteractible
        public string DisplayName => displayName;
        //make object interactable
        public bool CanInteract() => isEnabled;
        //define QuickOutline extension so we can create the outline of the hovered objects.
        private Outline _outline;

        public Interactable(Transform transform)
        {
            Transform = transform;
        }

        //define look of outline that is displayed
        private void Awake()
        {
            _outline = gameObject.AddComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineVisible;
            _outline.OutlineColor = Color.white;
            _outline.OutlineWidth = 15f;
            _outline.enabled = false;
        }
//predefined on interact function triggering interact scripts which can be put inside the script in the Inspector
        public void Interact()
        {
            onInteract?.Invoke();
        }
//define waht happens when interactable is focused
        public void OnFocusGained()
        {
            _outline.enabled = true;
            //return true;
        }
//define what happens when interactable is unfocused
        public void OnFocusLost()
        {
            _outline.enabled = false;
        }
    }
}