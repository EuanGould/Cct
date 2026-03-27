using UnityEngine;

public class SpecialButtonBehaviour : ButtonBehaviour
{
    public override void Activate()
    {
        timer = timePressed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().able_move = true;
        activatable.Activate();
    }
}
