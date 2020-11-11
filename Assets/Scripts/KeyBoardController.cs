using UnityEngine;
using UnityEngine.UI;

public class KeyBoardController : MonoBehaviour
{
    private CharacterController charController;
    [SerializeField] private float speed = 6;
    [SerializeField] private Text speedLabel;
    private float rotationY;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement = transform.TransformDirection(movement);
        movement *= Time.deltaTime;

        charController.Move(movement);
    }
}