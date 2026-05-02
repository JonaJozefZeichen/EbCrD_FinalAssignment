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
        public Transform Transform { get; }
        public string DisplayName => displayName;
        public bool CanInteract() => isEnabled;
        private Outline _outline;

        public Interactable(Transform transform)
        {
            Transform = transform;
        }

        private void Awake()
        {
            _outline = gameObject.AddComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineVisible;
            _outline.OutlineColor = Color.white;
            _outline.OutlineWidth = 15f;
            _outline.enabled = false;
        }

        public void Interact()
        {
            onInteract?.Invoke();
        }

        public bool OnFocusGained()
        {
            _outline.enabled = true;
            return true;
        }

        public void OnFocusLost()
        {
            _outline.enabled = false;
        }
    }
}