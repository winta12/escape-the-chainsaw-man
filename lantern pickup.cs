using UnityEngine;
using System.Collections;
written by wintana medhanie 

public class LanternPickup : MonoBehaviour
{
    private GameObject heldItem; // Reference to the item that will be destroyed when picked up.
    public GameObject interactionUI;
    public GameObject lanternPrefab;

    private bool playerIsNearby;

    void Start()
    {
        heldItem = gameObject; // Assign lantern pickup object to `heldItem`.
        interactionUI.SetActive(false); // Hide the interaction UI at the start.
        lanternPrefab.SetActive(false); // Ensure the lanternPrefab isn't visible until picked up.
    }

    /// <summary>
    /// Trigger logic to detect when the player enters the interaction range.
    /// </summary>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Reach")) // Only trigger if the player enters the correct area.
        {
            playerIsNearby = true; // Mark that the player is in the interaction range.
            interactionUI.SetActive(true); // Show the interaction prompt.
        }
    }

    /// <summary>
    /// Trigger logic to detect when the player exits the interaction range.
    /// </summary>
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Reach")) // Only deactivate if player exits the defined area.
        {
            playerIsNearby = false; // Mark that the player is no longer in range.
            interactionUI.SetActive(false); // Hide the interaction prompt.
        }
    }

    void Update()
    {
        // Allow the player to interact with the lantern if they are nearby and press the interact button.
        if (playerIsNearby && Input.GetButtonDown("Interact"))
        {
            PickupLantern();
        }
    }

    /// <summary>
    /// Handles the logic for picking up the lantern, hiding the UI, and destroying the pickup item.
    /// </summary>
    private void PickupLantern()
    {
        interactionUI.SetActive(false); // Hide the interaction prompt.
        lanternPrefab.SetActive(true); // Activate the lantern prefab in the game world.
        StartCoroutine(DestroyItemAfterDelay()); // Wait a short delay before destroying the pickup object.
    }

    /// <summary>
    /// Waits a short delay before destroying the object to ensure proper object initialization.
    /// </summary>
    private IEnumerator DestroyItemAfterDelay()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(heldItem); // Destroy the lantern pickup object after the delay.
    }
}

