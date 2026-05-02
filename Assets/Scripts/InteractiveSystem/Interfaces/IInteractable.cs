using UnityEngine;

namespace InteractiveSystem.Interfaces
{
   public interface  IInteractable{

      Transform Transform { get; }
   
      string DisplayName { get; }
   
      bool CanInteract();

      void Interact();

      bool OnFocusGained();
   
      void OnFocusLost();

   }
}
