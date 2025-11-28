using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] ActivatableBehaviour activatable;

    public void Activate()
    {
        activatable.Activate();
    }
}
