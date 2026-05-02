using UnityEngine;

namespace InteractiveSystem.Interfaces
{
   //IInteractable definition of the interface
   public interface  IInteractable{

      Transform Transform { get; }
   
      string DisplayName { get; }
   
      bool CanInteract();

      void Interact();

      void OnFocusGained();
   
      void OnFocusLost();

   }
}
