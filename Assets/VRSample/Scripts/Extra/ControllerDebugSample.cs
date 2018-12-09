using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class ControllerDebugSample : VRObjectBase
{
    private bool IsAttached;
    void Update()
    {
        if (device != null)
        {
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを浅く引いた");
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを深く引いた");
            }
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを離した");
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドをクリックした");
            }
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドをクリックしている");
            }
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドをクリックして離した");
            }
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドに触った");
            }
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドを離した");
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                Debug.Log("メニューボタンをクリックした");
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                Debug.Log("グリップボタンをクリックした");
            }

            if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを浅く引いている");
                float value = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
                Debug.Log("トリガーが" + value * 100 + "%押されている");
            }
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを深く引いている");
                float value = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
                Debug.Log("トリガーが" + value * 100 + "%押されている");
            }
            if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドに触っている");
                Vector2 position = device.GetAxis();
                Debug.Log("x: " + position.x + " y: " + position.y+"らへんを触っている");
            }
        }
    }
}
