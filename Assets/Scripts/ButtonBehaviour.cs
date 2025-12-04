using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] ActivatableBehaviour activatable;
    [SerializeField] float timePressed;

    private float timer = 0f;

    public void Activate()
    {
        activatable.Activate();
        timer = timePressed;
    }

    private void FixedUpdate()
    {
        if (timer > 0f)
        {
            gameObject.transform.localScale = new Vector3(1f, 0.1f, 1f);
            timer -= timePressed * Time.fixedDeltaTime;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 0.2f, 1f);
        }
    }
}
