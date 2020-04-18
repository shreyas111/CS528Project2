﻿namespace VRTK.Examples
{
    using UnityEngine;
    public class LeftControllerInteractListener : MonoBehaviour
    {
        ObjectCounter script;
        private void Awake()
        {
            script = GameObject.Find("HolderObject").GetComponent<ObjectCounter>();
        }
        private void Start()
        {
            if (GetComponent<VRTK_InteractTouch>() == null || GetComponent<VRTK_InteractGrab>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerInteract_ListenerExample", "VRTK_InteractTouch and VRTK_InteractGrab", "the Controller Alias"));
                return;
            }

            //Setup controller event listeners
            GetComponent<VRTK_InteractTouch>().ControllerTouchInteractableObject += new ObjectInteractEventHandler(DoInteractTouch);
            GetComponent<VRTK_InteractTouch>().ControllerUntouchInteractableObject += new ObjectInteractEventHandler(DoInteractUntouch);
            GetComponent<VRTK_InteractGrab>().ControllerGrabInteractableObject += new ObjectInteractEventHandler(DoInteractGrab);
            GetComponent<VRTK_InteractGrab>().ControllerUngrabInteractableObject += new ObjectInteractEventHandler(DoInteractUngrab);
        }

        private void DebugLogger(uint index, string action, GameObject target)
        {
            VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " an object named " + target.name);
        }

        private void DoInteractTouch(object sender, ObjectInteractEventArgs e)
        {
            if (e.target)
            {
                script.ObjectTouchedForLooping.Add(e.target.name.ToString());
                if (GameObject.Find(e.target.name.ToString()) != null)
                { 
                    GameObject.Find(e.target.name.ToString()).GetComponent<Rigidbody>().isKinematic = false;
                }
                Debug.Log("Target Object Touched for looping  is" + e.target);
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHING", e.target);
            }
        }

        private void DoInteractUntouch(object sender, ObjectInteractEventArgs e)
        {
            if (e.target)
            {
                if (GameObject.Find(e.target.name.ToString()) != null)
                {
                    GameObject.Find(e.target.name.ToString()).GetComponent<Rigidbody>().isKinematic = true;
                }
                script.ObjectTouchedForLooping.Remove(e.target.name.ToString());  
                Debug.Log("Target Object Not for looping  is" + e.target);
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "NO LONGER TOUCHING", e.target);
            }
        }

        private void DoInteractGrab(object sender, ObjectInteractEventArgs e)
        {
            if (e.target)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRABBING", e.target);
            }
        }

        private void DoInteractUngrab(object sender, ObjectInteractEventArgs e)
        {
            if (e.target)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "NO LONGER GRABBING", e.target);
            }
        }
    }
}