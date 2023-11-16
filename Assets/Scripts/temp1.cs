using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class temp1 : MonoBehaviour
{
    public float Speed = 5;
    public float RotationSpeed = 3;

    void Update()
    {
        // Перемещение по клавишам W, S, A, D
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        // Вращение при помощи мыши
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Поворот по горизонтали
        transform.Rotate(Vector3.up, mouseX * RotationSpeed);

        // Поворот по вертикали (ограничиваем угол)
        float newRotationX = Mathf.Clamp(transform.rotation.eulerAngles.x - mouseY * RotationSpeed, 0f, 45f);
        transform.rotation = Quaternion.Euler(newRotationX, transform.rotation.eulerAngles.y, 0f);
    }
}