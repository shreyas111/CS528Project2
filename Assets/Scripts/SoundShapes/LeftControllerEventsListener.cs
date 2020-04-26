namespace VRTK
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.Networking;
    using VRTK.Examples;
    using UnityEngine.UI;
    using TMPro;

    public class LeftControllerEventsListener : MonoBehaviour
    {
        ObjectCounter script;
        private float objectSize;
        bool triggerPressed;
        private int TriggerCounter;

        
        public GameObject audioMenu;
        public GameObject CanvasMenu;
        public bool audioMenuActive;
        RightControllerEventsListener script1;

        public string nameOfObjectWhoseAudioMenuOpen;

        public GameObject circleMarker;
        public GameObject cubeMarker;

        public Material circleMaterial1;
        public Material circleMaterial2;
        public Material circleMaterial3;
        public Material circleMaterial4;
        public Material cubeMaterial1;
        public Material cubeMaterial2;
        public Material cubeMaterial3;
        public Material cubeMaterial4;

        //public Material originalMatOfObjectWhoseMenuIsOpen;
        //public Material materialforObjectWhoseMenuisOpen;



        public enum EventQuickSelect
        {
            Custom,
            None,
            All,
            ButtonOnly,
            AxisOnly,
            SenseAxisOnly
        }

        [Header("Quick Select")]

        public EventQuickSelect quickSelect = EventQuickSelect.All;

        [Header("Button Events Debug")]

        public bool triggerButtonEvents = true;
        public bool gripButtonEvents = true;
        public bool touchpadButtonEvents = true;
        public bool buttonOneButtonEvents = true;
        public bool buttonTwoButtonEvents = true;
        public bool startMenuButtonEvents = true;

        [Header("Axis Events Debug")]

        public bool triggerAxisEvents = true;
        public bool gripAxisEvents = true;
        public bool touchpadAxisEvents = true;
        public bool touchpadTwoAxisEvents = true;

        [Header("Sense Axis Events Debug")]

        public bool triggerSenseAxisEvents = true;
        public bool touchpadSenseAxisEvents = true;
        public bool middleFingerSenseAxisEvents = true;
        public bool ringFingerSenseAxisEvents = true;
        public bool pinkyFingerSenseAxisEvents = true;

        private VRTK_ControllerEvents controllerEvents;
        void Awake()
        {
            script = GameObject.Find("HolderObject").GetComponent<ObjectCounter>();
            objectSize = 0f;
            triggerPressed = false;
            TriggerCounter = 0;

            audioMenuActive = false;
            script1=GameObject.Find("RightController").GetComponent<RightControllerEventsListener>();

            nameOfObjectWhoseAudioMenuOpen = "";

            circleMarker.GetComponent<Renderer>().material = circleMaterial1;
            cubeMarker.SetActive(false);
        }
        void Update()
        {
            if(triggerPressed)
            {
                if (objectSize < 2.0f)
                {
                    objectSize = objectSize + 0.02f;
                }
                else
                {
                    objectSize = 2.0f;
                }
            }
            
        }

        private void OnEnable()
        {
            controllerEvents = GetComponent<VRTK_ControllerEvents>();
            if (controllerEvents == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }

            //Setup controller event listeners
            controllerEvents.TriggerPressed += DoTriggerPressed;
            controllerEvents.TriggerReleased += DoTriggerReleased;
            controllerEvents.TriggerTouchStart += DoTriggerTouchStart;
            controllerEvents.TriggerTouchEnd += DoTriggerTouchEnd;
            controllerEvents.TriggerHairlineStart += DoTriggerHairlineStart;
            controllerEvents.TriggerHairlineEnd += DoTriggerHairlineEnd;
            controllerEvents.TriggerClicked += DoTriggerClicked;
            controllerEvents.TriggerUnclicked += DoTriggerUnclicked;
            controllerEvents.TriggerAxisChanged += DoTriggerAxisChanged;
            controllerEvents.TriggerSenseAxisChanged += DoTriggerSenseAxisChanged;

            controllerEvents.GripPressed += DoGripPressed;
            controllerEvents.GripReleased += DoGripReleased;
            controllerEvents.GripTouchStart += DoGripTouchStart;
            controllerEvents.GripTouchEnd += DoGripTouchEnd;
            controllerEvents.GripHairlineStart += DoGripHairlineStart;
            controllerEvents.GripHairlineEnd += DoGripHairlineEnd;
            controllerEvents.GripClicked += DoGripClicked;
            controllerEvents.GripUnclicked += DoGripUnclicked;
            controllerEvents.GripAxisChanged += DoGripAxisChanged;

            controllerEvents.TouchpadPressed += DoTouchpadPressed;
            controllerEvents.TouchpadReleased += DoTouchpadReleased;
            controllerEvents.TouchpadTouchStart += DoTouchpadTouchStart;
            controllerEvents.TouchpadTouchEnd += DoTouchpadTouchEnd;
            controllerEvents.TouchpadAxisChanged += DoTouchpadAxisChanged;
            controllerEvents.TouchpadTwoAxisChanged += DoTouchpadTwoAxisChanged;
            controllerEvents.TouchpadSenseAxisChanged += DoTouchpadSenseAxisChanged;

            controllerEvents.ButtonOnePressed += DoButtonOnePressed;
            controllerEvents.ButtonOneReleased += DoButtonOneReleased;
            controllerEvents.ButtonOneTouchStart += DoButtonOneTouchStart;
            controllerEvents.ButtonOneTouchEnd += DoButtonOneTouchEnd;

            controllerEvents.ButtonTwoPressed += DoButtonTwoPressed;
            controllerEvents.ButtonTwoReleased += DoButtonTwoReleased;
            controllerEvents.ButtonTwoTouchStart += DoButtonTwoTouchStart;
            controllerEvents.ButtonTwoTouchEnd += DoButtonTwoTouchEnd;

            controllerEvents.StartMenuPressed += DoStartMenuPressed;
            controllerEvents.StartMenuReleased += DoStartMenuReleased;

            controllerEvents.ControllerEnabled += DoControllerEnabled;
            controllerEvents.ControllerDisabled += DoControllerDisabled;
            controllerEvents.ControllerIndexChanged += DoControllerIndexChanged;

            controllerEvents.MiddleFingerSenseAxisChanged += DoMiddleFingerSenseAxisChanged;
            controllerEvents.RingFingerSenseAxisChanged += DoRingFingerSenseAxisChanged;
            controllerEvents.PinkyFingerSenseAxisChanged += DoPinkyFingerSenseAxisChanged;
        }

        private void OnDisable()
        {
            if (controllerEvents != null)
            {
                controllerEvents.TriggerPressed -= DoTriggerPressed;
                controllerEvents.TriggerReleased -= DoTriggerReleased;
                controllerEvents.TriggerTouchStart -= DoTriggerTouchStart;
                controllerEvents.TriggerTouchEnd -= DoTriggerTouchEnd;
                controllerEvents.TriggerHairlineStart -= DoTriggerHairlineStart;
                controllerEvents.TriggerHairlineEnd -= DoTriggerHairlineEnd;
                controllerEvents.TriggerClicked -= DoTriggerClicked;
                controllerEvents.TriggerUnclicked -= DoTriggerUnclicked;
                controllerEvents.TriggerAxisChanged -= DoTriggerAxisChanged;
                controllerEvents.TriggerSenseAxisChanged -= DoTriggerSenseAxisChanged;

                controllerEvents.GripPressed -= DoGripPressed;
                controllerEvents.GripReleased -= DoGripReleased;
                controllerEvents.GripTouchStart -= DoGripTouchStart;
                controllerEvents.GripTouchEnd -= DoGripTouchEnd;
                controllerEvents.GripHairlineStart -= DoGripHairlineStart;
                controllerEvents.GripHairlineEnd -= DoGripHairlineEnd;
                controllerEvents.GripClicked -= DoGripClicked;
                controllerEvents.GripUnclicked -= DoGripUnclicked;
                controllerEvents.GripAxisChanged -= DoGripAxisChanged;

                controllerEvents.TouchpadPressed -= DoTouchpadPressed;
                controllerEvents.TouchpadReleased -= DoTouchpadReleased;
                controllerEvents.TouchpadTouchStart -= DoTouchpadTouchStart;
                controllerEvents.TouchpadTouchEnd -= DoTouchpadTouchEnd;
                controllerEvents.TouchpadAxisChanged -= DoTouchpadAxisChanged;
                controllerEvents.TouchpadTwoAxisChanged -= DoTouchpadTwoAxisChanged;
                controllerEvents.TouchpadSenseAxisChanged -= DoTouchpadSenseAxisChanged;

                controllerEvents.ButtonOnePressed -= DoButtonOnePressed;
                controllerEvents.ButtonOneReleased -= DoButtonOneReleased;
                controllerEvents.ButtonOneTouchStart -= DoButtonOneTouchStart;
                controllerEvents.ButtonOneTouchEnd -= DoButtonOneTouchEnd;

                controllerEvents.ButtonTwoPressed -= DoButtonTwoPressed;
                controllerEvents.ButtonTwoReleased -= DoButtonTwoReleased;
                controllerEvents.ButtonTwoTouchStart -= DoButtonTwoTouchStart;
                controllerEvents.ButtonTwoTouchEnd -= DoButtonTwoTouchEnd;

                controllerEvents.StartMenuPressed -= DoStartMenuPressed;
                controllerEvents.StartMenuReleased -= DoStartMenuReleased;

                controllerEvents.ControllerEnabled -= DoControllerEnabled;
                controllerEvents.ControllerDisabled -= DoControllerDisabled;
                controllerEvents.ControllerIndexChanged -= DoControllerIndexChanged;

                controllerEvents.MiddleFingerSenseAxisChanged -= DoMiddleFingerSenseAxisChanged;
                controllerEvents.RingFingerSenseAxisChanged -= DoRingFingerSenseAxisChanged;
                controllerEvents.PinkyFingerSenseAxisChanged -= DoPinkyFingerSenseAxisChanged;
            }
        }

        private void LateUpdate()
        {
            switch (quickSelect)
            {
                case EventQuickSelect.None:
                    triggerButtonEvents = false;
                    gripButtonEvents = false;
                    touchpadButtonEvents = false;
                    buttonOneButtonEvents = false;
                    buttonTwoButtonEvents = false;
                    startMenuButtonEvents = false;

                    triggerAxisEvents = false;
                    gripAxisEvents = false;
                    touchpadAxisEvents = false;
                    touchpadTwoAxisEvents = false;

                    triggerSenseAxisEvents = false;
                    touchpadSenseAxisEvents = false;
                    middleFingerSenseAxisEvents = false;
                    ringFingerSenseAxisEvents = false;
                    pinkyFingerSenseAxisEvents = false;
                    break;
                case EventQuickSelect.All:
                    triggerButtonEvents = true;
                    gripButtonEvents = true;
                    touchpadButtonEvents = true;
                    buttonOneButtonEvents = true;
                    buttonTwoButtonEvents = true;
                    startMenuButtonEvents = true;

                    triggerAxisEvents = true;
                    gripAxisEvents = true;
                    touchpadAxisEvents = true;
                    touchpadTwoAxisEvents = true;

                    triggerSenseAxisEvents = true;
                    touchpadSenseAxisEvents = true;
                    middleFingerSenseAxisEvents = true;
                    ringFingerSenseAxisEvents = true;
                    pinkyFingerSenseAxisEvents = true;
                    break;
                case EventQuickSelect.ButtonOnly:
                    triggerButtonEvents = true;
                    gripButtonEvents = true;
                    touchpadButtonEvents = true;
                    buttonOneButtonEvents = true;
                    buttonTwoButtonEvents = true;
                    startMenuButtonEvents = true;

                    triggerAxisEvents = false;
                    gripAxisEvents = false;
                    touchpadAxisEvents = false;
                    touchpadTwoAxisEvents = false;

                    triggerSenseAxisEvents = false;
                    touchpadSenseAxisEvents = false;
                    middleFingerSenseAxisEvents = false;
                    ringFingerSenseAxisEvents = false;
                    pinkyFingerSenseAxisEvents = false;
                    break;
                case EventQuickSelect.AxisOnly:
                    triggerButtonEvents = false;
                    gripButtonEvents = false;
                    touchpadButtonEvents = false;
                    buttonOneButtonEvents = false;
                    buttonTwoButtonEvents = false;
                    startMenuButtonEvents = false;

                    triggerAxisEvents = true;
                    gripAxisEvents = true;
                    touchpadAxisEvents = true;
                    touchpadTwoAxisEvents = true;

                    triggerSenseAxisEvents = false;
                    touchpadSenseAxisEvents = false;
                    middleFingerSenseAxisEvents = false;
                    ringFingerSenseAxisEvents = false;
                    pinkyFingerSenseAxisEvents = false;
                    break;
                case EventQuickSelect.SenseAxisOnly:
                    triggerButtonEvents = false;
                    gripButtonEvents = false;
                    touchpadButtonEvents = false;
                    buttonOneButtonEvents = false;
                    buttonTwoButtonEvents = false;
                    startMenuButtonEvents = false;

                    triggerAxisEvents = false;
                    gripAxisEvents = false;
                    touchpadAxisEvents = false;
                    touchpadTwoAxisEvents = false;

                    triggerSenseAxisEvents = true;
                    touchpadSenseAxisEvents = true;
                    middleFingerSenseAxisEvents = true;
                    ringFingerSenseAxisEvents = true;
                    pinkyFingerSenseAxisEvents = true;
                    break;
            }
        }

        private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
        {
            string debugString = "Controller on index '" + index + "' " + button + " has been " + action
                                 + " with a pressure of " + e.buttonPressure + " / Primary Touchpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)" + " / Secondary Touchpad axis at: " + e.touchpadTwoAxis + " (" + e.touchpadTwoAngle + " degrees)";
            VRTK_Logger.Info(debugString);
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "pressed", e);
            }
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "released", e);
            }
        }

        private void DoTriggerTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "touched", e);
            }
        }

        private void DoTriggerTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "untouched", e);
            }
        }

        private void DoTriggerHairlineStart(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "hairline start", e);
            }
        }

        private void DoTriggerHairlineEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "hairline end", e);
            }
        }

        private void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                triggerPressed = true;
                TriggerCounter++;
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "clicked", e);
            }
        }

        private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerButtonEvents)
            {
                triggerPressed = false;
                //Debug.Log("Object Size is" + objectSize);
                createObject(objectSize);
                objectSize = 0f;


            }
        }

        //private IEnumerator loadSound(string soundPathRoot, string soundClipName)
        //{
        //    //UnityWebRequest request = getSoundFromFile(soundPathRoot, soundClipName);
        //    //yield return request;
        //    //AudioClip audioClip = request.GetAudioClip();
        //    string soundPath = soundPathRoot + soundClipName;
        //    using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(soundPath, AudioType.WAV))
        //    {
        //        yield return www.SendWebRequest();

        //        if (www.isNetworkError)
        //        {
        //            Debug.Log(www.error);
        //        }
        //        else
        //        {
        //            AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
        //        }
        //    }
        //}
        //private UnityWebRequest getSoundFromFile(string soundPathRoot, string soundClipName)
        //{
        //    string soundToLoad = soundPathRoot + soundClipName;
        //    UnityWebRequest request = new UnityWebRequest(soundToLoad);
        //    return request;
        //}

        private void loadSound(AudioSource audioSource, ObjectProperties obj)
        {

            audioSource.clip = obj.AudioClip;
            audioSource.Play();
            audioSource.loop = obj.IsAudioLooped;
        }
        private void createObject(float objectSize)
        {
            ObjectProperties objectProperties= script.ObjectProperties[script.Counter];
            GameObject shape;
            Renderer shapeRenderer;
            AudioSource shapeAudioSource;

            switch (objectProperties.Shape)
            {

                case "Cube":
                    shape = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    shape.name = "soundObject" + TriggerCounter;
                    //shape.transform.position = new Vector3(0f, 0f, 0f);
                    shape.transform.position = GameObject.Find("CreationLocation").GetComponent<Transform>().position;
                    shape.transform.localScale = new Vector3(objectSize, objectSize, objectSize);

                    shape.AddComponent<Rigidbody>();
                    shape.GetComponent<Rigidbody>().useGravity = false;
                    shape.GetComponent<Rigidbody>().isKinematic = true;

                    shapeRenderer = shape.GetComponent<Renderer>();
                    shapeRenderer.material = objectProperties.Mat;
                    
                    shapeAudioSource = shape.AddComponent<AudioSource>();
                    loadSound(shapeAudioSource, objectProperties);

                    shape.AddComponent<OscilatePlayingObject>();
                    shape.AddComponent<VRTK_InteractableObject>();
                    shape.GetComponent<VRTK_InteractableObject>().enabled = true;
                    shape.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
                    shape.AddComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                    shape.GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>().enabled = true;
                    shape.AddComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                    shape.GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>().enabled = true;

                    shape.AddComponent<VRTK_InteractObjectHighlighter>();


                    //StartCoroutine(loadSound(script.SoundPathRoot,objectProperties.AudioClipName));
                    break;

                case "Sphere":
                    shape = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    shape.name = "soundObject" + TriggerCounter;
                    shape.transform.position = GameObject.Find("CreationLocation").GetComponent<Transform>().position;
                    shape.transform.localScale = new Vector3(objectSize, objectSize, objectSize);

                    shape.AddComponent<Rigidbody>();
                    shape.GetComponent<Rigidbody>().useGravity = false;
                    shape.GetComponent<Rigidbody>().isKinematic = true;

                    shapeRenderer = shape.GetComponent<Renderer>();
                    shapeRenderer.material = objectProperties.Mat;

                    shapeAudioSource = shape.AddComponent<AudioSource>();
                    loadSound(shapeAudioSource, objectProperties);

                    shape.AddComponent<OscilatePlayingObject>();
                    shape.AddComponent<VRTK_InteractableObject>();
                    shape.GetComponent<VRTK_InteractableObject>().enabled = true;
                    shape.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
                    shape.AddComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                    shape.GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>().enabled = true;
                    shape.AddComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                    shape.GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>().enabled = true;

                    shape.AddComponent<VRTK_InteractObjectHighlighter>();
                    //shape.AddComponent<VRTK_InteractObjectHighlighter>();
                    //shape.GetComponent<VRTK_InteractObjectHighlighter>().enabled = true;
                    //shape.AddComponent<VRTK.UnityEventHelper.VRTK_InteractObjectHighlighter_UnityEvents>();
                    //VRTK_InteractObjectHighlighter s = shape.GetComponent<VRTK_InteractObjectHighlighter>();
                    break;

                default:
                    shape = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    shape.transform.position = new Vector3(0f, 0f, 0f);
                    break;
            }

            //marker.transform.position = t.position;
            //marker.transform.localScale = new Vector3(markerScale, markerScale, markerScale);
            //marker.transform.SetParent(parent.transform, true);
            //Renderer markerRender = marker.GetComponent<Renderer>();

            //markerRender.material = script.markerMaterials[script.materialsCounter];
            //DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "unclicked", e);
        }

        private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "axis changed", e);
            }
        }

        private void DoTriggerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (triggerSenseAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "sense axis changed", e);
            }
        }

        private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "pressed", e);
            }
        }

        private void DoGripReleased(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "released", e);
            }
        }

        private void DoGripTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "touched", e);
            }
        }

        private void DoGripTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "untouched", e);
            }
        }

        private void DoGripHairlineStart(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "hairline start", e);
            }
        }

        private void DoGripHairlineEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "hairline end", e);
            }
        }

        private void DoGripClicked(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "clicked", e);
            }
        }

        private void DoGripUnclicked(object sender, ControllerInteractionEventArgs e)
        {
            if (gripButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "unclicked", e);
            }
        }

        private void DoGripAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (gripAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "axis changed", e);
            }
        }

        private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "pressed down", e);
            }
        }

        private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "released", e);
            }
        }

        private void DoTouchpadTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "touched", e);
            }
        }

        private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "untouched", e);
            }
        }

        private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "axis changed", e);
            }
        }

        private void DoTouchpadTwoAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadTwoAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPADTWO", "axis changed", e);
            }
        }

        private void DoTouchpadSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (touchpadSenseAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "sense axis changed", e);
            }
        }

        private void DoButtonOnePressed(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonOneButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "pressed down", e);
            }
        }

        private void DoButtonOneReleased(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonOneButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "released", e);
            }
        }

        private void DoButtonOneTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonOneButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "touched", e);
            }
        }

        private void DoButtonOneTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonOneButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "untouched", e);
            }
        }

        private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonTwoButtonEvents)
            {
                if(script.ObjectTouchedForLooping.Count>0)
                {
                    string ObjectTouchedForLooping = script.ObjectTouchedForLooping[0];
                    if (GameObject.Find(ObjectTouchedForLooping) != null)
                    {
                        AudioSource audioS = GameObject.Find(ObjectTouchedForLooping).GetComponent<AudioSource>();
                        if (audioS != null)
                        {
                            //audioS.loop = !audioS.loop;

                            if (script1.canvasMenuActive)
                            {
                                script1.canvasMenuActive = false;
                                CanvasMenu.SetActive(false);
                            }
                            audioMenuActive = !audioMenuActive;
                            if (audioMenuActive)
                            {
                                nameOfObjectWhoseAudioMenuOpen = ObjectTouchedForLooping;
                                //originalMatOfObjectWhoseMenuIsOpen = GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<Renderer>().material;
                                //GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<Renderer>().material = materialforObjectWhoseMenuisOpen;
                            }
                            else
                            {
                                //GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<Renderer>().material = originalMatOfObjectWhoseMenuIsOpen;
                                //originalMatOfObjectWhoseMenuIsOpen = null;
                                nameOfObjectWhoseAudioMenuOpen = "";
                            }
                            audioMenu.SetActive(audioMenuActive);

                            foreach (Transform trans in audioMenu.GetComponentInChildren<Transform>())
                            {
                                if (trans.name == "VolumeSlider")
                                {
                                    trans.gameObject.GetComponent<Slider>().value = audioS.volume;
                                }
                                if (trans.name == "LoopToggle")
                                {
                                    trans.gameObject.GetComponent<Toggle>().isOn = audioS.loop;
                                }
                                if (trans.name == "NameText")
                                {
                                    trans.gameObject.GetComponent<TextMeshProUGUI>().text = nameOfObjectWhoseAudioMenuOpen;
                                }
                                if (trans.name == "PlayPauseButton")
                                {
                                    if (audioS.isPlaying)
                                    {
                                        trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
                                        
                                    }
                                    else
                                    {
                                        trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Play";
                                    }

                                }
                                if (trans.name == "StopButton")
                                {
                                    if (!audioS.isPlaying)
                                    {
                                        trans.gameObject.GetComponent<Button>().enabled = false;
                                        //trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Stop";
                                    }
                                    else
                                    {
                                        trans.gameObject.GetComponent<Button>().enabled = true;
                                    }
                                  
                                }
                            }

                        }
                        ////Destroy(GameObject.Find(objectToDeleteName));
                        ////script.ObjectsDelete.Remove(objectToDeleteName);
                    }
                }
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "pressed down", e);
            }
        }
        public void UpdateVolume(float value)
        {
            AudioSource audioS = GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<AudioSource>();
            foreach (Transform trans in audioMenu.GetComponentInChildren<Transform>())
            {
                if (trans.name == "VolumeSlider")
                {
                    audioS.volume = trans.gameObject.GetComponent<Slider>().value;
                }
            }
        }

        public void UpdateLoop(bool value)
        {

            Debug.Log("UpdateLoop Value is" + value);
            AudioSource audioS = GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<AudioSource>();
            foreach (Transform trans in audioMenu.GetComponentInChildren<Transform>())
            {
                if (trans.name == "LoopToggle")
                {
                    audioS.loop = value;
                }
            }
        }

        public void UpdatePlay()
        {
            AudioSource audioS = GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<AudioSource>();
            foreach (Transform trans in audioMenu.GetComponentInChildren<Transform>())
            {
                if (trans.name == "PlayPauseButton")
                {
                    if (trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text.Equals("Play"))
                    {
                        audioS.Play();
                        trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
                    }
                    else
                    {
                        audioS.Pause();
                        trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Play";
                    }
                }
                if (trans.name == "StopButton")
                {
                    if (!audioS.isPlaying)
                    {
                        trans.gameObject.GetComponent<Button>().enabled = false;
                        //trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Stop";
                    }
                    else
                    {
                        trans.gameObject.GetComponent<Button>().enabled = true;
                    }

                }
            }
        }

        public void UpdateStop()
        {
            AudioSource audioS = GameObject.Find(nameOfObjectWhoseAudioMenuOpen).GetComponent<AudioSource>();
            audioS.Stop();
            foreach (Transform trans in audioMenu.GetComponentInChildren<Transform>())
            {
                if (trans.name == "PlayPauseButton")
                {
                        trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Play";                   
                }
                if (trans.name == "StopButton")
                {
                    if (!audioS.isPlaying)
                    {
                        trans.gameObject.GetComponent<Button>().enabled = false;
                        //trans.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Stop";
                    }
                    else
                    {
                        trans.gameObject.GetComponent<Button>().enabled = true;
                    }

                }
            }
        }

        private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonTwoButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "released", e);
            }
        }

        private void DoButtonTwoTouchStart(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonTwoButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "touched", e);
            }
        }

        private void DoButtonTwoTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            if (buttonTwoButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "untouched", e);
            }
        }

        private void DoStartMenuPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (startMenuButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "START MENU", "pressed down", e);
            }
        }

        private void DoStartMenuReleased(object sender, ControllerInteractionEventArgs e)
        {
            if (startMenuButtonEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "START MENU", "released", e);
            }
        }

        private void DoControllerEnabled(object sender, ControllerInteractionEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "CONTROLLER STATE", "ENABLED", e);
        }

        private void DoControllerDisabled(object sender, ControllerInteractionEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "CONTROLLER STATE", "DISABLED", e);
        }

        private void DoControllerIndexChanged(object sender, ControllerInteractionEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "CONTROLLER STATE", "INDEX CHANGED", e);
        }

        private void DoMiddleFingerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (middleFingerSenseAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "MIDDLE FINGER", "sense axis changed", e);
            }
        }

        private void DoRingFingerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (ringFingerSenseAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "RING FINGER", "sense axis changed", e);
            }
        }

        private void DoPinkyFingerSenseAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            if (pinkyFingerSenseAxisEvents)
            {
                DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "PINKY FINGER", "sense axis changed", e);
            }
        }
        public void RadialMenuButtonOne()
        {
            //Debug.Log("Radial Menu Button One Pressed");
            script.Counter = 0;

            circleMarker.SetActive(true);            
            circleMarker.GetComponent<Renderer>().material = circleMaterial1;
            cubeMarker.SetActive(false);
        }
        public void RadialMenuButtonTwo()
        {
            //Debug.Log("Radial Menu Button Two Pressed");
            script.Counter = 1;

            circleMarker.SetActive(true);
            circleMarker.GetComponent<Renderer>().material = circleMaterial2;
            cubeMarker.SetActive(false);
        }
        public void RadialMenuButtonThree()
        {
            //Debug.Log("Radial Menu Button Three Pressed");
            script.Counter = 2;

            circleMarker.SetActive(true);
            circleMarker.GetComponent<Renderer>().material = circleMaterial3;
            cubeMarker.SetActive(false);
        }
        public void RadialMenuButtonFour()
        {
            //Debug.Log("Radial Menu Button Four Pressed");
            script.Counter = 3;

            circleMarker.SetActive(true);
            circleMarker.GetComponent<Renderer>().material = circleMaterial4;
            cubeMarker.SetActive(false);
        }
        public void RadialMenuButtonFive()
        {
            //Debug.Log("Radial Menu Button Five Pressed");
            script.Counter = 4;

            cubeMarker.SetActive(true);
            cubeMarker.GetComponent<Renderer>().material = cubeMaterial1;
            circleMarker.SetActive(false);
        }
        public void RadialMenuButtonSix()
        {
            //Debug.Log("Radial Menu Button Six Pressed");
            script.Counter = 5;

            cubeMarker.SetActive(true);
            cubeMarker.GetComponent<Renderer>().material = cubeMaterial2;
            circleMarker.SetActive(false);
        }
        public void RadialMenuButtonSeven()
        {
            //Debug.Log("Radial Menu Button Seven Pressed");
            script.Counter = 6;

            cubeMarker.SetActive(true);
            cubeMarker.GetComponent<Renderer>().material = cubeMaterial3;
            circleMarker.SetActive(false);
        }
        public void RadialMenuButtonEight()
        {
            //Debug.Log("Radial Menu Button Seven Pressed");
            script.Counter = 7;

            cubeMarker.SetActive(true);
            cubeMarker.GetComponent<Renderer>().material = cubeMaterial4;
            circleMarker.SetActive(false);
        }
    }
}