using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float directionForwardBack;
    private float directionLeftRight;
    private float rotationHorizontal;
    private float rotationVertical;
    private PlayerMovement playerMovement;
    private Camera playerCamera;
    private Vector2 screenMousePosition;
    private Vector3 worldMousePosition;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera = Camera.main;
        rotationHorizontal = 0.0f;
        rotationVertical = 0.0f;
    }

    private void ButtonDown()
    {
        directionForwardBack = Input.GetAxis("Vertical");
        directionLeftRight = Input.GetAxis("Horizontal");
        rotationHorizontal += Input.GetAxis("Mouse X");
        rotationVertical += Input.GetAxis("Mouse Y");
    }


    private void Update()
    {
        
        ButtonDown();
        playerMovement.Move(directionForwardBack, directionLeftRight, rotationHorizontal, rotationVertical);

    }
}

