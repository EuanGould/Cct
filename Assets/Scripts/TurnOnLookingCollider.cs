using UnityEngine;

public class TurnOnLookingCollider : MonoBehaviour
{
    [SerializeField] private GameObject UItoToggle;
    [SerializeField] private bool turnOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UItoToggle.SetActive(turnOn);
            other.gameObject.GetComponent<PlayerBehaviour>().able_look = true;
        }
    }
}
