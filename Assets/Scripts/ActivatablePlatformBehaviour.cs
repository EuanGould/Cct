using UnityEngine;

public class ActivatablePlatformBehaviour : ActivatableBehaviour
{
    [SerializeField] private Vector3 destination;

    private bool activated = false;

    public override void Activate()
    {
        activated = true;
    }

    private void FixedUpdate()
    {
        if (activated)
        {
            transform.position -= (transform.position - destination) * Time.deltaTime;
        }
    }
}
