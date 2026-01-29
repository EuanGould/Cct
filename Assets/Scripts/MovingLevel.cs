using UnityEngine;

public class MovingLevel : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private float speed;
    [SerializeField] private GameObject trainDoor;

    private bool active = true;

    private void FixedUpdate()
    {
        if (active)
        {
            transform.position -= (transform.position - destination).normalized * speed * Time.fixedDeltaTime;

            if ((transform.position - destination).magnitude < speed * Time.fixedDeltaTime)
            {
                transform.position = destination;
                speed = 0;
                active = false;
                trainDoor.SetActive(false);
            }
        }
        

    }
}
