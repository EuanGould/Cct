using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float looksens = 1f;
    [SerializeField] private GameObject mainCamera;

    private Vector2 input = Vector2.zero;
    private Vector2 lookInput = Vector2.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Vector3 step = transform.forward * input.y + transform.right * input.x;
        float lookStep = lookInput.x * looksens * Time.fixedDeltaTime;

        GetComponent<Rigidbody>().linearVelocity = step.normalized * speed;

        transform.Rotate(new Vector3(0, 1, 0), lookStep);
        mainCamera.transform.Rotate(Vector3.right, lookInput.y * looksens * Time.fixedDeltaTime * -1);
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void LookLeftRight(InputAction.CallbackContext context)
    {
        lookInput.x = context.ReadValue<float>();
    }

    public void LookUpDown(InputAction.CallbackContext context)
    {
        lookInput.y = context.ReadValue<float>();
    }
}
