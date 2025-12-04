using UnityEngine;

public class BridgeBehaviour : ActivatableBehaviour
{
    [SerializeField] private float degrees;
    
    public override void Activate()
    {
        transform.Rotate(0f, degrees, 0f);
    }
}
