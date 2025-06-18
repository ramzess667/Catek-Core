using UnityEngine;

public class TeleportTrigger2D : MonoBehaviour
{
    public Transform targetLocation; 
    private bool isPlayerInTrigger = false; 
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            canTeleport = true; 
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = targetLocation.position; 
                canTeleport = false; 
                Debug.Log("Игрок телепортирован!");
            }
        }
    }
}
