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
        Cursor.lockState = CursorLockMode.Locked; // ���������� �������
        Cursor.visible = false; // ������� �������
    }

    public void LookAround(float mouseX, float mouseY)
    {
        // ��������� ���������������� � �������� �������� ��� ��������
        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;

        // ������� ������ �� ��� X (�����/����)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // ������� ������ �����/����
        playerBody.Rotate(Vector3.up * mouseX); // ������� ���� ������ (�����/�����)
    }
}
