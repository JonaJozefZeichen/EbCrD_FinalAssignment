using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private GameObject onInteract;

   private bool _isPickedUp = false;

   public void Toggle()
   {
       _isPickedUp = !_isPickedUp;
       onInteract.SetActive(_isPickedUp);
   }
   
}
