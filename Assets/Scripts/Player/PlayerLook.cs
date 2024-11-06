using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Sense")]
    public float mouseSensitivity = 300f;
    [Header("Player MainObject")]
    public Transform playerBody;
    [Header("Player Camera")]
    public Transform playerCamera;           

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Блокировка курсора
        Cursor.visible = false; // Скрытие курсора
    }

    public void LookAround(float mouseX, float mouseY)
    {
        // Применяем чувствительность и получаем значения для поворота
        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;

        // Поворот камеры по оси X (вверх/вниз)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Вращаем камеру вверх/вниз
        playerBody.Rotate(Vector3.up * mouseX); // Вращаем тело игрока (влево/вправ)
    }
}
