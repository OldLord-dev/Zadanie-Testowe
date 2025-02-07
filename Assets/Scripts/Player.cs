using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private Transform orienation;

    private Rigidbody rb;
    public Vector2 inputDirection;
    public float moveSpeed = 10f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    Vector3 moveDirection;
    void Update()
    {
        moveDirection = orienation.forward * inputDirection.y + orienation.right * inputDirection.x;
        rb.linearDamping = 6f;
    }
    void FixedUpdate()
    {
        if(inputDirection!=Vector2.zero)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Acceleration);
    }
    public void Move(Vector2 direction)
    {
        inputDirection = direction;
    }
}
