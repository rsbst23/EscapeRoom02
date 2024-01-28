using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public Vector3 pivot = new Vector3(0, 0, 0); // Set the pivot point (in local coordinates)


    private bool isOpen = false;

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            ToggleDoor();
        }
        
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;

        float targetAngle = isOpen ? openAngle : 0f;
        StartCoroutine(RotateDoor(targetAngle));
    }

    IEnumerator RotateDoor(float targetAngle)
    {
        Vector3 pivot = transform.position - transform.right * 0.5f; // Adjust the pivot point based on your door's configuration

        while (Mathf.Abs(transform.localRotation.eulerAngles.y - targetAngle) > 0.1f)

        {

            float step = openSpeed * Time.deltaTime;
            transform.RotateAround(pivot, Vector3.up, step);
            yield return null;
        }

        //string x = "Jackson";
    }
}