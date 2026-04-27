using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float velocity;
    [SerializeField] private float acceleration;


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)==true)transform.position += new Vector3(0,0,velocity) *  Time.deltaTime;
    }
}
