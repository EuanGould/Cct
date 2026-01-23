using UnityEngine;

public class UIEventColliderBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject UItoToggle;
    [SerializeField] private bool turnOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UItoToggle.SetActive(turnOn);
        }
    }
}
