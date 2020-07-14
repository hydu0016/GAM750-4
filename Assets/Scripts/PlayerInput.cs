using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerInput : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;

    public bool Grabbing { get; set; } = false;

    void Update()
    {
        if (targetDevice.name != null)
        {
            UpdatePlayerInput();
        }
        else
        {
            //Get Device if none is found yet
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
            if (devices.Count > 0)
            {
                targetDevice = devices[0];
            }
        }
    }

    private void UpdatePlayerInput()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonValue) &&
            triggerButtonValue > 0)
        {

        }

        var grabbing = targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonValue);

        if (grabbing && gripButtonValue)
        {
            Grabbing = true;
        }
        else
        {
            Grabbing = false;
        }
    }
}
