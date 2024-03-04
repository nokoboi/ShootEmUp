using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    //dependencia del input system que hemos importado desde el package manager
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour 
    {
        PlayerInput playerInput;
        InputAction moveAction;

        public Vector2 Move => moveAction.ReadValue<Vector2>();
        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
        }
    }
}
