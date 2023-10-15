using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // カメラの移動速度

    void Update()
    {
        // カメラの現在の位置
        Vector3 currentPosition = transform.position;

        // カメラの新しい位置を計算
        if (Input.GetKey(KeyCode.W))
        {
            currentPosition += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPosition -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPosition -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentPosition += transform.right * moveSpeed * Time.deltaTime;
        }

        // 新しい位置にカメラを移動
        transform.position = currentPosition;
    }
}
