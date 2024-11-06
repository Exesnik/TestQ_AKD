using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public float Horizontal => Input.GetAxis("Horizontal");
    public float Vertical => Input.GetAxis("Vertical");
    public float MouseX => Input.GetAxis("Mouse X");
    public float MouseY => Input.GetAxis("Mouse Y");

    public bool JumpPressed => Input.GetButtonDown("Jump");
    public bool InteractPressed => Input.GetKeyDown(KeyCode.E);
    public bool InteractRotate => Input.GetKeyDown(KeyCode.R);

    private void Awake()
    {
        // Реализуем Singleton для InputManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
