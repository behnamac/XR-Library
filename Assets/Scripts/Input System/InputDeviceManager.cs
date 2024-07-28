using UnityEngine;
using UnityEngine.InputSystem;

public class InputDeviceManager : MonoBehaviour
{
    void Start()
    {
        // List all currently connected input devices
        foreach (var device in InputSystem.devices)
        {
            Debug.Log("Device: " + device.name + ", Characteristics: " + device.description);
        }

        // Register a callback for when a device is connected
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Added:
                Debug.Log("Device added: " + device.name);
                break;
            case InputDeviceChange.Removed:
                Debug.Log("Device removed: " + device.name);
                break;
            case InputDeviceChange.Disconnected:
                Debug.Log("Device disconnected: " + device.name);
                break;
            case InputDeviceChange.Reconnected:
                Debug.Log("Device reconnected: " + device.name);
                break;
        }
    }

    void Update()
    {
        // Check for specific device characteristics during the game update loop
        foreach (var device in InputSystem.devices)
        {
            if (device is Keyboard)
            {
                Debug.Log("Keyboard detected: " + device.name);
            }
            else if (device is Mouse)
            {
                Debug.Log("Mouse detected: " + device.name);
            }
            else if (device is Gamepad)
            {
                Debug.Log("Gamepad detected: " + device.name);
            }
            else if (device is Touchscreen)
            {
                Debug.Log("Touchscreen detected: " + device.name);
            }
            else if (device is Pen)
            {
                Debug.Log("Stylus detected: " + device.name);
            }
        }
    }
}
