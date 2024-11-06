using UnityEngine;


public class InteractionHandler : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactRange = 2f;  
    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private float distanceFromCamera = 1.5f;


    private Transform heldItem;


    public void HandleInteraction()
    {
        TryInteractItem();

        if (heldItem == null)
            TryPickupItem();
        else
            ReleaseItem();

        if (heldItem != null)
        {
            FollowCamera();
            RotateHeldItem();
           
        }

    }

    public void RotateHeldItem()
    {
        if (heldItem != null)
            heldItem.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); 
    }

    private void FollowCamera()
    {
        heldItem.position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
    }

    private void TryInteractItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            if (hit.transform.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }

    private void TryPickupItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            if (hit.transform.TryGetComponent(out IInteractable interactable))
            {
                heldItem = hit.transform;
                
                heldItem.gameObject.GetComponent<Rigidbody>().useGravity = false;
                heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = true; 
                
                
                heldItem.SetParent(Camera.main.transform); 
            }
        }
    }

    
    private void ReleaseItem()
    {
        heldItem.SetParent(null);
        heldItem.gameObject.GetComponent<Rigidbody>().useGravity = true;
        heldItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        heldItem = null;
    }


   
}
 