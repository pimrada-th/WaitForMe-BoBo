using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Climber : MonoBehaviour
{
    private CharacterController character;
    public static XRController climbingHand;
    public float gravity = -3;
    private float fallingSpeed;
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        
        if (climbingHand)
        {
            fallingSpeed = 0;
            Climb();
        }
        else
        {
            if(ClimbableEvents.countClimbed==0)
                fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    void Climb()
    {
        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}

