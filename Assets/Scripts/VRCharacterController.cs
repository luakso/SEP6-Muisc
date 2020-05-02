using UnityEngine;
using Valve.VR;

public class VRCharacterController : MonoBehaviour
{
    [SerializeField] private float Gravity = 30.0f;
    [SerializeField] private SteamVR_Action_Vector2 MoveValue = null;

    private CharacterController characterController = null;
    private Transform head = null;

    private Vector2 minimumSpeedValue = new Vector2(0.3f, 0.3f);

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if(SteamVR_Render.Top() != null)
        {
            head = SteamVR_Render.Top().head;
        }   
    }

    private void Update()
    {
        if(head != null)
        {
            HandleHeight();
            CalculateMovement();
        }
    }

    private void HandleHeight()
    {
        //Set the head in local space
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        characterController.height = headHeight;

        //Cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        // Move capsule in local space
        newCenter.x = head.localPosition.x;
        newCenter.z = head.localPosition.z;


        //Apply
        characterController.center = newCenter;
    }

    private void CalculateMovement()
    {
        //Figure out movement orientation
        Vector3 orientationEuler = new Vector3(0, head.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (CheckIfAllowedToMove())
        {
            movement += orientation * new Vector3(MoveValue.axis.x, 0.0f, MoveValue.axis.y);
        }
        else movement = Vector3.zero;


        //Gravity - I guess it is speed v = a * t
        movement.y -= Gravity * Time.deltaTime;

        //Apply - I guess it is distance s = v * t
        characterController.Move(movement * Time.deltaTime);
    }


    private bool CheckIfAllowedToMove()
    {
        if (MoveValue.axis.x > minimumSpeedValue.x || MoveValue.axis.y > minimumSpeedValue.y || MoveValue.axis.y < -minimumSpeedValue.y || MoveValue.axis.x < -minimumSpeedValue.y)
        {
            return true;
        }
        return false;
    }
}
