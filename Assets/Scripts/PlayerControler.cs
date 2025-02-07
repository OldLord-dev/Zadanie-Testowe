using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        if (player == null)
            Debug.LogError("Could not find Player component on PlayerController");
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
            player.Move(Vector2.zero);
        if (!context.performed)
            return;

        var input = context.ReadValue<Vector2>();
        player.Move(input);
    }

    //public void Interact(InputAction.CallbackContext context)
    //{
    //    if (!context.started)
    //        return;
    //    player.Interact();
    //}
}