using UnityEngine;

public class Flower : MonoBehaviour
{
    //Flower class, still needs improvements, missing state switch in the sense of changing visuals. missing statement do make only pickuppable once.
    [SerializeField] private GameObject onInteract;
    [SerializeField] private bool isPickedUp;
   //private bool _isPickedUp;
    public void Toggle()
    {
        isPickedUp = !isPickedUp;
        onInteract.SetActive(isPickedUp);
    }
}