using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    private InteractionHandler interactionHandler;
 

    private void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
        interactionHandler = GetComponent<InteractionHandler>();

        if (playerMovement == null || playerLook == null || interactionHandler == null)
        {
            Debug.LogError("PlayerController: Один или несколько компонентов не найдены.");
        }

    }

    private void Update()
    {      
        playerMovement.HandleMovement(InputManager.Instance.Horizontal, InputManager.Instance.Vertical, InputManager.Instance.JumpPressed);
        playerLook.LookAround(InputManager.Instance.MouseX, InputManager.Instance.MouseY);

        if (InputManager.Instance.InteractPressed)
        {
            interactionHandler.HandleInteraction();
        }
        if (InputManager.Instance.InteractRotate)
        {
            interactionHandler.RotateHeldItem();
        }
    }
}
