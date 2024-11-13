using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicker : MonoBehaviour
{
    private Camera cameraMain;
    [SerializeField] private Transform hand;
    private GameObject moveObject;
    private bool isUper;
    
    
    
    private void Awake()
    {
        isUper = false;
        cameraMain = Camera.main;
    }
    
    private void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.isPressed)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = cameraMain.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag == "Box")
                {
                    moveObject = hit.collider.gameObject;
                    isUper = true;
                }
                if(hit.collider.gameObject.tag == "Gates")
                {
                    hit.collider.gameObject.GetComponent<OpenGates>().IsOpen();
                }
            }           
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            isUper = false;
        }
        
        if (isUper)
        {
            MoveBox();
        }
                   
    }

    private void MoveBox()
    {
        moveObject.transform.position = hand.position;
    }

    

}
