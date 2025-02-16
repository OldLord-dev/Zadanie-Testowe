using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] 
    private Transform playerCamera;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private LayerMask layerMask;

    private Rigidbody rb;
    private Vector2 inputDirection = Vector2.zero;
    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void Update()
    {      
        moveDirection = Vector3.Cross(playerCamera.right, Vector3.up) * inputDirection.y 
            + playerCamera.right * inputDirection.x;
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

    public void Interact()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, 20, layerMask))
        {
            hit.collider.gameObject.GetComponentInParent<Door>().OpenDoor();
        }
    }
    public void Esc()
    {
        GameManager.RestartGame();
    }
}