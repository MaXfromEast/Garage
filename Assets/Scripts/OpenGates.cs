using UnityEngine;

public class OpenGates : MonoBehaviour
{
    private Transform halfGates;
    private bool isOpen;
    [SerializeField] private int angel;
    private void Start()
    {
        halfGates = GetComponent<Transform>();
    }
    private void Update()
    {
        if(isOpen)
        {
            Opening();
        }
    }

    private void Opening()
    {
        halfGates.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angel, 0), Time.deltaTime);
    }

    public void IsOpen()
    {
        isOpen = true;
    }
}
