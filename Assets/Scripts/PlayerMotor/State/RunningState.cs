using UnityEngine;

public class RunningState : BaseState
{
    public override void Construct()
    {
        motor.verticalVelocity = 0;
    }
    public override Vector3 ProcessMotion()
    {
        Vector3 m = Vector3.zero;

        m.x = motor.SnapToLane();
        m.y = -1.0f;
        m.z = motor.baseRunSpeed;

        return m;
    }
    public override void Transition()
    {
        if(InputManager.Instance.SwipeLeft)
        {
            // Change lane, go left
            motor.ChangeLane(-1);
        }

        if (InputManager.Instance.SwipeRight)
        {
            // Change lane, go right
            motor.ChangeLane(1);
        }

        if (InputManager.Instance.SwipeUp && motor.isGrounded)
        {
            // Change to jumping state
            motor.ChangeState(GetComponent<JumpingState>());
        }

        if (!motor.isGrounded)
            motor.ChangeState(GetComponent<FallingState>());

        if (InputManager.Instance.SwipeDown && motor.isGrounded)
            motor.ChangeState(GetComponent < SlidingState>());
    }
}
