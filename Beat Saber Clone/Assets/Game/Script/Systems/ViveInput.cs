using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace HTCVIVE
{
    public class VR
    {
        public SteamVR_Action_Vibration haptic;
        public SteamVR_Behaviour_Pose testpose;

        #region HTCVIVE Input

        #region Right Controller
        //Trigger
        /// <summary>Returns true if trigger is used.</summary>
        public static bool RightTrigger()
        {
            if (SteamVR_Input._default.inActions.GrabPinch.GetState(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        public static bool RightTriggerUP()
        {
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns a float if trigger is being sqeezed.</summary>
        public static float RightTriggerSqeeze()
        {
            return SteamVR_Input._default.inActions.Squeeze.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        //Grip
        /// <summary>Returns true if the grip button is used.</summary>
        public static bool RightGrip()
        {
            if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        //Menu button
        /// <summary>Returns true if the menu button is used.</summary>
        public static bool RightMenuButton()
        {
            if (SteamVR_Input._default.inActions.Menu.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        //Touchpad
        /// <summary>Returns a Vector2 (touch position).</summary>
        public static Vector2 RightTouchpadTouchPos()
        {
            return SteamVR_Input._default.inActions.TouchpadTouch.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        //Touchpad buttons
        /// <summary>Returns true if touchpad up is used.</summary>
        public static bool RightTouchpadButtonUp()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonUp.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad down is used.</summary>
        public static bool RightTouchpadButtonDown()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonDown.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad right is used.</summary>
        public static bool RightTouchpadButtonRight()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonRight.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad left is used.</summary>
        public static bool RightTouchpadButtonLeft()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonLeft.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad center is used.</summary>
        public static bool RightTouchpadButtonCenter()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonCenter.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Left Controller
        //Trigger
        /// <summary>Returns true if trigger is used.</summary>
        public static bool LeftTrigger()
        {
            if (SteamVR_Input._default.inActions.GrabPinch.GetState(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        public static bool LeftTriggerUP()
        {
            if (SteamVR_Input._default.inActions.GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns a float if trigger is being sqeezed.</summary>
        public static float LeftTriggerSqeeze()
        {
            return SteamVR_Input._default.inActions.Squeeze.GetAxis(SteamVR_Input_Sources.LeftHand);
        }
        //Grip
        /// <summary>Returns true if the grip button is used.</summary>
        public static bool LeftGrip()
        {
            if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        //Menu button
        /// <summary>Returns true if the menu button is used.</summary>
        public static bool LeftMenuButton()
        {
            if (SteamVR_Input._default.inActions.Menu.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        //Touchpad
        /// <summary>Returns a Vector2 (touch position).</summary>
        public static Vector2 LeftTouchpadTouchPos()
        {
            return SteamVR_Input._default.inActions.TouchpadTouch.GetAxis(SteamVR_Input_Sources.LeftHand);
        }
        //Touchpad buttons
        /// <summary>Returns true if touchpad up is used.</summary>
        public static bool LeftTouchpadButtonUp()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonUp.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad down is used.</summary>
        public static bool LeftTouchpadButtonDown()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonDown.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad right is used.</summary>
        public static bool LeftTouchpadButtonRight()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonRight.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad left is used.</summary>
        public static bool LeftTouchpadButtonLeft()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonLeft.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        /// <summary>Returns true if touchpad center is used.</summary>
        public static bool LeftTouchpadButtonCenter()
        {
            if (SteamVR_Input._default.inActions.TouchpadButtonCenter.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Other

        public void RightHapticPulse(float duration, float intesity, float amplitude)
        {
            haptic.Execute(0, duration, intesity, amplitude, SteamVR_Input_Sources.RightHand);
        }
        public void LeftHapticPulse(float duration, float intesity, float amplitude)
        {
            haptic.Execute(0, duration, intesity, amplitude, SteamVR_Input_Sources.LeftHand);
        }
        #endregion

        #endregion







        //Pickup
        /// <summary>Returns GameObject.</summary>
        public static GameObject GetObject(GameObject obj)
        {
            if(obj.tag == "Interacteble")
            return obj;
            return null;
        }
    }
}
