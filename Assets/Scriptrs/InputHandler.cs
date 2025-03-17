using UnityEngine;
namespace CarControllers
{
    public class InputHandler : MonoBehaviour
    {
        public float GasInput { get; private set; }
        public float SteerInput { get; private set; }
        public float BrakeInput { get; private set; }

        public void HandleInput(float speed)
        {
            GasInput = Input.GetAxis("Vertical");
            SteerInput = Input.GetAxis("Horizontal");
            float slipAngle = Vector3.Angle(transform.forward, GetComponent<Rigidbody>().linearVelocity - transform.forward);

            if (slipAngle < 120 && GasInput < 0)
            {
                BrakeInput = Mathf.Abs(GasInput);
                GasInput = 0;
            }
            else
            {
                BrakeInput = 0;
            }
        }
    }

}
