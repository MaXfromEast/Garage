using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float backspeed;
    private Rigidbody playerBody;
    private Quaternion zeroPositionQ;
    private Quaternion camPositionQ;
    private Vector3 normalCollision;
   

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        zeroPositionQ = playerBody.rotation;
        camPositionQ = Camera.main.transform.rotation;
        
    }
    public void Move(float directionForward, float directionSide, float rotationHorizontal, float rotationVertical)
    {

        HorizontalMovement(directionForward, directionSide);
        Rotation(rotationHorizontal);
        LookUpDown(rotationHorizontal, rotationVertical);

    }


    private void HorizontalMovement(float directionForward, float directionSide)
    {
        if ((directionForward > 0.1)||(Mathf.Abs(directionSide) > 0.1))
        {
            if (normalCollision.y == 1)
            {
                playerBody.velocity = transform.forward * directionForward * speed + transform.up * -1 + transform.right * directionSide * speed;
            }
            else
            {
                playerBody.velocity = Project(directionForward, directionSide)*2; 
            }
        }
        else if ((directionForward < -0.1)||(Mathf.Abs(directionSide) > 0.1))
        {
           
            playerBody.velocity = transform.forward * directionForward * backspeed + transform.up * -1 + transform.right * directionSide * backspeed;
        }
        else
        {
            
        }
        
        
        
    }

    private void Rotation(float rotationHorizontal)
    {
        playerBody.rotation = zeroPositionQ * Quaternion.AngleAxis(rotationHorizontal, Vector3.up);
        
    }

    public void LookUpDown(float rotationHorizontal, float rotationVertical)
    {
        Camera.main.transform.rotation = camPositionQ * Quaternion.AngleAxis(rotationHorizontal, Vector3.up) * Quaternion.AngleAxis(rotationVertical, Vector3.left);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            normalCollision = collision.contacts[0].normal;
        }
        else
        {
            normalCollision = Vector3.up;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            normalCollision = Vector3.up;
        }
    }

    
    private Vector3 Project(float directionForward, float directionSide)  //Ќаправление движени€ вдоль поверхности
    {
        Vector3 direction = (new Vector3(directionSide, 0, directionForward));
        return direction - Vector3.Dot(direction, normalCollision) * normalCollision;
    }
}
