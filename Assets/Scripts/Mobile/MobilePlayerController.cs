using UnityEngine;
using UnityEngine.InputSystem;

public class MobilePlayerController : PlayerController
{
    //for mobile
    public InputAction moveForward;
    public InputAction lookPosition;

    void Start()
    {
        Init();
    }

    protected override void Init()
    {
        moveForward.Enable();
        lookPosition.Enable();
    }

    protected override void MovePlayer()
    {
        if (moveForward.IsPressed())
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(lookPosition.ReadValue<Vector2>());
                Vector2 direction = (mousePos - transform.position).normalized;
                transform.up = direction;
                rb.AddForce(direction * thrustForce);

                if (rb.linearVelocity.magnitude > maxSpeed)
                {
                    rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
                }
            }
    }

    protected override void ActivateBoosterFlame()
    {
        if (moveForward.WasPressedThisFrame())
        {
            boosterFlame.SetActive(true);
        }
        else if (moveForward.WasReleasedThisFrame())
        {
            boosterFlame.SetActive(false);
        }
    }
}
