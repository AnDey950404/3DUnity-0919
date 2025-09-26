using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // 滑鼠靈敏度
    public float moveSpeed = 5f;           // 鍵盤平移速度
    public float flySpeed = 5f;            // 空白鍵向上移動速度

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 鎖定滑鼠
    }

    void Update()
    {
        // -------- 滑鼠旋轉視角 --------
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制上下旋轉角度

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // -------- 鍵盤平移 --------
        float moveX = Input.GetAxis("Horizontal"); // A / D
        float moveZ = Input.GetAxis("Vertical");   // W / S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // -------- 空白鍵向上飛 --------
        if (Input.GetKey(KeyCode.Space))
        {
            move += Vector3.up * flySpeed;
        }

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
