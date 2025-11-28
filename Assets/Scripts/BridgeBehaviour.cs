using UnityEngine;

public class BridgeBehaviour : ActivatableBehaviour
{
    public override void Activate()
    {
        transform.Rotate(0f, 90f, 0f);
    }
}
