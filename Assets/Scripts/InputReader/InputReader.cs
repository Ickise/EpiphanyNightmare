using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public UnityEvent onMoveEvent = new UnityEvent();
    public UnityEvent onJumpEvent = new UnityEvent();
    public UnityEvent onShootEvent = new UnityEvent();
    public UnityEvent onCounterEvent = new UnityEvent();
    public UnityEvent onRandomThingsEvent = new UnityEvent();

    public Vector2 direction;
    
    public bool jump;

    public bool doCounterAnimation;

    public static InputReader _instance;

    private void Awake()
    {
        _instance = this;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            direction = context.ReadValue<Vector2>();
            onMoveEvent.Invoke();
        }
        else
        {
            direction = Vector2.zero;
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump = true;
            onJumpEvent.Invoke();
        }
        if(context.canceled)
        {
            jump = false;
        }
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onShootEvent.Invoke();
        }
    }
    
    public void OnCounter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onCounterEvent.Invoke();
        }
    }

    public void OnRandomThings(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onRandomThingsEvent.Invoke();
        }
    }
}
