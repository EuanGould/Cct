using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPos;
    [SerializeField] private Quaternion respawnRot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehaviour>().ChangeRespawn(respawnPos, respawnRot);
        }
    }
}
