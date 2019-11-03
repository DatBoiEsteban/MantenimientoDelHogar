using UnityEngine;
using UnityEngine.XR;

// Attach this controller to the main camera, or an appropriate
// ancestor thereof, such as the "player" game object.
public class CameraControl : MonoBehaviour
{
    // Optional, allows user to drag left/right to rotate the world.
    private const float DRAG_RATE = .2f;
    float dragYawDegrees;

    void Start()
    {
        // Make sure orientation sensor is enabled.
        Input.gyro.enabled = true;
    }

    void FixedUpdate()
    {
        if (XRSettings.enabled)
        {
            // Unity takes care of updating camera transform in VR.
            return;
        }

        // android-developers.blogspot.com/2010/09/one-screen-turn-deserves-another.html
        // developer.android.com/guide/topics/sensors/sensors_overview.html#sensors-coords
        //
        //     y                                       x
        //     |  Gyro upright phone                   |  Gyro landscape left phone
        //     |                                       |
        //     |______ x                      y  ______|
        //     /                                       \
        //    /                                         \
        //   z                                           z
        //
        //
        //     y
        //     |  z   Unity
        //     | /
        //     |/_____ x
        //

        // Update `dragYawDegrees` based on user touch.
        //CheckDrag();

        transform.rotation = Input.gyro.attitude;
        if(Input.touchCount == 3)
        {
            transform.Rotate(new Vector3(transform.localRotation.x, 0 , transform.localRotation.z));
        }
    }

    void CheckDrag()
    {
        if (Input.touchCount != 1)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Moved)
        {
            return;
        }

        dragYawDegrees += touch.deltaPosition.x * DRAG_RATE;
    }
}