using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;
using Vuplex.WebView;

public class UserWebInteraction : MonoBehaviour
{

    public InputActionReference pressA;
    public InputActionReference pressX;
    public InputActionReference leftTrigger;
    public CanvasWebViewPrefab canv;
    //public int zoomout = 1;
    

    void Awake()
    {
        //web = canv.WebView;

        leftTrigger.action.Enable();
        leftTrigger.action.performed += PressLeftTrigger;
        //InputSystem.onDeviceChange += OnDeviceChangeLController;

        pressA.action.Enable();
        pressA.action.performed += PressAKey;
        InputSystem.onDeviceChange += OnDeviceChangeRController;

        pressX.action.Enable();
        pressX.action.performed += PressXKey;
        InputSystem.onDeviceChange += OnDeviceChangeLController;
      //  ZoomAfterLoad();
    }
    
   
    private void OnDestroy()
    {

        leftTrigger.action.Enable();
        leftTrigger.action.performed -= PressLeftTrigger;

        pressA.action.Disable();
        pressA.action.performed -= PressAKey;
        InputSystem.onDeviceChange -= OnDeviceChangeRController;

        pressX.action.Disable();
        pressX.action.performed -= PressXKey;
        InputSystem.onDeviceChange -= OnDeviceChangeLController;
    }

   //we are using Resolution parameter instead
    /*private async void ZoomAfterLoad()
    {
        await canv.WaitUntilInitialized();
        await canv.WebView.WaitForNextPageLoadToFinish();
        for (int i = 0; i < zoomout; i++)
        {
            canv.WebView.ZoomOut();
        }
    }*/


    private void PressLeftTrigger(InputAction.CallbackContext context)
    {
        canv.WebView.SendKey("A");
    }
    private void PressXKey(InputAction.CallbackContext context)
    {
        canv.WebView.SendKey("F");
    }

    private void PressAKey(InputAction.CallbackContext context)
    {
        canv.WebView.SendKey("J");
    }

    private void OnDeviceChangeRController(InputDevice device, InputDeviceChange change)
    {
        switch(change)
        {
            case InputDeviceChange.Disconnected:
                pressA.action.Disable();
                pressA.action.performed -= PressAKey;
                break;
            case InputDeviceChange.Reconnected:
                pressA.action.Enable();
                pressA.action.performed += PressAKey;
                break;
        }
    }

    private void OnDeviceChangeLController(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                pressX.action.Disable();
                pressX.action.performed -= PressXKey;
                leftTrigger.action.performed -= PressLeftTrigger;
                break;
            case InputDeviceChange.Reconnected:
                pressX.action.Enable();
                pressX.action.performed += PressXKey;
                leftTrigger.action.performed += PressLeftTrigger;
                break; 
        }
    }

}
