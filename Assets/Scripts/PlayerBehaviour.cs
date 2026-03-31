using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float looksens = 1f;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float jump_force = 1f;

    private Vector2 input = Vector2.zero;
    private Vector2 lookInput = Vector2.zero;
    private Vector3 respawn_point;
    private Quaternion respawn_rotation;

    public bool able_move = true;
    public bool crosshair_on = true;
    public bool able_look = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawn_point = new Vector3(-2.99000001f, 0.870999992f, -0.438700676f);
        respawn_rotation = Quaternion.Euler(Vector3.zero);
    }

    void FixedUpdate()
    {
        Vector3 step = transform.forward * input.y + transform.right * input.x;

        if (!able_move)
        {
            step = Vector3.zero;
        }

        GetComponent<Rigidbody>().linearVelocity = new Vector3(step.normalized.x * speed, GetComponent<Rigidbody>().linearVelocity.y, step.normalized.z * speed);
    }

    private void Update()
    {
        float lookStep = lookInput.x * looksens * Time.deltaTime;
        if (able_look)
        {
            transform.Rotate(new Vector3(0, 1, 0), lookStep);
        }

        float camera_x_rotation = 0f;

        camera_x_rotation += -1f * lookInput.y * looksens * Time.deltaTime;

        if (mainCamera.transform.localRotation.x * 90 > 60)
        {
            camera_x_rotation = Mathf.Clamp(camera_x_rotation, -Mathf.Infinity, 0);
        }
        else if (mainCamera.transform.localRotation.x * 90 < -60)
        {
            camera_x_rotation = Mathf.Clamp(camera_x_rotation, 0, Mathf.Infinity);
        }

        if (able_look)
        {
            mainCamera.transform.Rotate(camera_x_rotation, 0, 0);
        }

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

    public void Jump(InputAction.CallbackContext context)
    {
        LayerMask layerMask = LayerMask.GetMask("Ground");
        // Does the ray intersect any objects excluding the player layer
        if (IsGrounded() && able_move)
        {
            GetComponent<Rigidbody>().linearVelocity += new Vector3(0f, jump_force, 0f);
        }
        
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject button = FindButton();

            if (button != null)
            {
                button.GetComponent<ButtonBehaviour>().Activate();
            }
        }
    }

    bool IsGrounded()
    {
        float GroundedDistance = 0.2f;
        RaycastHit info;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Mathf.Abs(rb.linearVelocity.y) <= 0.03)
        {
            return Physics.SphereCast(transform.position, GroundedDistance, Vector3.down, out info);
        }
        else
        {
            return false;
        }
    }

    GameObject FindButton()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 2f))
        {
            if (hit.collider.gameObject.CompareTag("Button"))
            {
                return hit.collider.gameObject;
            }
        }
        
        return null;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Hazard"))
        {
            transform.position = respawn_point;
            transform.rotation = respawn_rotation;
            mainCamera.transform.rotation = respawn_rotation;
        }
    }

    public void ChangeRespawn(Vector3 newValue, Quaternion newrotValue)
    {
        respawn_point = newValue;
        respawn_rotation = newrotValue;
    }
}
