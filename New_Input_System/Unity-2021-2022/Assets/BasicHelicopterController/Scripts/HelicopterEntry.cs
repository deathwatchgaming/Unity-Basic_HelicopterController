/*
 * File: Helicopter Entry
 * Name: HelicopterEntry.cs
 * Author: DeathwatchGaming
 * License: MIT
 * Unity Version(s): Unity 2021+ - 2022+ 
 */

// using
using UnityEngine;
using System.Collections;
using NavigationControl;

// namespace BasicHelicopterController
namespace BasicHelicopterController
{
    // RequireComponent typeof BoxCollider
    [RequireComponent(typeof(BoxCollider))]

    // public class HelicopterEntry 
    public class HelicopterEntry : MonoBehaviour
    {
        // Input Customizations
        [Header("Input Customizations")] 

            [Tooltip("The vehicle entry key code")]
            // KeyCode _enterKey
            [SerializeField] private KeyCode _enterKey = KeyCode.E;

            [Tooltip("The vehicle exit key code")]
            // KeyCode _exitKey
            [SerializeField] private KeyCode _exitKey = KeyCode.F;

        // Game Objects
        [Header("Game Objects")]

            [Tooltip("The helicopter game object")]
            // GameObject _helicopter
            [SerializeField] private GameObject _helicopter;

            [Tooltip("The player game object")]
            // GameObject _player
            [SerializeField] private GameObject _player;

            [Tooltip("The interface text game object")]
            // GameObject _interfaceTextObject
            [SerializeField] private GameObject _interfaceTextObject;

            [Tooltip("The interface HUD game object")]
            // GameObject _interfaceHUDObject
            [SerializeField] private GameObject _interfaceHUDObject;            
        
        // Active State
        [Header("Active State")]

            [Tooltip("The active state bool")]
            // bool _inHelicopter is false
            [SerializeField] private bool _inHelicopter = false;
        
        // HelicopterController _helicopterScript
        private HelicopterController _helicopterScript;

        // CameraSwitcher _helicopterCamScript
        private CameraSwitcher _helicopterCamScript;
        
        // Camera _helicopterCamera01
        private Camera _helicopterCamera01;

        // AudioListener _helicopterCamera01AudioListener
        private AudioListener _helicopterCamera01AudioListener;

        // Camera _helicopterCamera02
        private Camera _helicopterCamera02;

        // AudioListener _helicopterCamera02AudioListener
        private AudioListener _helicopterCamera02AudioListener;

        // Camera _helicopterCamera03
        private Camera _helicopterCamera03;

        // AudioListener _helicopterCamera03AudioListener
        private AudioListener _helicopterCamera03AudioListener;

        // AudioSource _helicopterAudioSource
        private AudioSource _helicopterAudioSource;

        // Rigidbody _rigidbody
        private Rigidbody _rigidbody;

        [Tooltip("The cameras ie: 0: Rear Camera, 1: Belly Camera & 2: Cockpit Camera")]
        // private Camera[] _cameras
        [SerializeField] private Camera[] _cameras;

        // GameObject FindInActiveObjectByName
        GameObject FindInActiveObjectByName(string name)
        {
            // Transform[] objs
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];

            // for 
            for (int i = 0; i < objs.Length; i++)
            {
                // if
                if (objs[i].hideFlags == HideFlags.None)
                {
                    // if
                    if (objs[i].name == name)
                    {
                        // return 
                        return objs[i].gameObject;

                    } // close if

                } // close if

            } // close for

            // return null
            return null;

        } // close GameObject FindInActiveObjectByName

        // Compass
        [Header("Compass")]

            [Tooltip("The player compass")]
            // PlayerCompass _playerCompass
            [SerializeField] private PlayerCompass _playerCompass;
            
            [Tooltip("The basic helicopter compass")]
            // BasicHelicopterCompass _helicopterCompass
            [SerializeField] private BasicHelicopterCompass _helicopterCompass;  

        //public static HelicopterEntry _helicopterEntry;

        // private void Start
        private void Start() 
        {
            //_helicopterEntry = this;

            // _helicopterScript is GetComponent HelicopterController
            _helicopterScript = GetComponent<HelicopterController>();

            // _helicopterScript enabled is false
            _helicopterScript.enabled = false;

            // _helicopterCamScript is GetComponent CameraSwitcher
            _helicopterCamScript = GetComponent<CameraSwitcher>();

            // _helicopterCamScript enabled is false
            _helicopterCamScript.enabled = false;

            // _helicopterCamera01 is GetComponentInChildren Camera
            _helicopterCamera01 = _cameras[0].GetComponentInChildren<Camera>();

            // _helicopterCamera01 enabled is false
            _helicopterCamera01.enabled = false;

            // _helicopterCamera01AudioListener is GetComponentInChildren AudioListener
            _helicopterCamera01AudioListener = _cameras[0].GetComponentInChildren<AudioListener>();

            // _helicopterCamera01AudioListener enabled is false
            _helicopterCamera01AudioListener.enabled = false;

            // _helicopterCamera02 is GetComponentInChildren Camera
            _helicopterCamera02 = _cameras[1].GetComponentInChildren<Camera>();

            // _helicopterCamera02 enabled is false
            _helicopterCamera02.enabled = false;

            // _helicopterCamera02AudioListener is GetComponentInChildren AudioListener
            _helicopterCamera02AudioListener = _cameras[1].GetComponentInChildren<AudioListener>();

            // _helicopterCamera02AudioListener enabled is false
            _helicopterCamera02AudioListener.enabled = false;

            // _helicopterCamera03 is GetComponentInChildren Camera
            _helicopterCamera03 = _cameras[2].GetComponentInChildren<Camera>();

            // _helicopterCamera03 enabled is false
            _helicopterCamera03.enabled = false;

            // _helicopterCamera03AudioListener is GetComponentInChildren AudioListener
            _helicopterCamera03AudioListener = _cameras[2].GetComponentInChildren<AudioListener>();

            // _helicopterCamera03AudioListener enabled is false
            _helicopterCamera03AudioListener.enabled = false;

            // _helicopterAudioSource
            _helicopterAudioSource = GetComponent<AudioSource>();

            // _helicopterAudioSource enabled is false
            _helicopterAudioSource.enabled = false;            

            // _rigidbody
            _rigidbody = GetComponent<Rigidbody>();

            // GameObject _interfaceTextObject 
            GameObject _interfaceTextObject = FindInActiveObjectByName("Helicopter_EntryKey");

            // _interfaceTextObject SetActive is false
            _interfaceTextObject.SetActive(false); 

            // GameObject _interfaceHUDObject 
            GameObject _interfaceHUDObject = FindInActiveObjectByName("Helicopter_HUD");
            
            // _interfaceHUDObject SetActive is false
            _interfaceHUDObject.SetActive(false);

            // Compass

            // _playerCompass enabled is true
            _playerCompass.enabled = true;

            // _playerCompass compassEnabled is true
            _playerCompass.compassEnabled = true;

            // Debug Log
            //Debug.Log("The Player compass is enabled");

            // _helicopterCompass enabled is false
            _helicopterCompass.enabled = false;

            // _helicopterCompass compassEnabled is false
            _helicopterCompass.compassEnabled = false;

            // Debug Log
            //Debug.Log("The Helicopter compass is disabled");

        } // close private void Start

        // Update is called once per frame

        // private void Update
        private void Update()
        {
            // if _inHelicopter and Input GetKey KeyCode _exitKey
            if (_inHelicopter && Input.GetKey(_exitKey))
            {
                // _player SetActive is true
                _player.SetActive(true);

                // _player transform parent is null
                _player.transform.parent = null;

                // _helicopterScript enabled is false
                _helicopterScript.enabled = false;

                // _helicopterCamScript enabled is false
                _helicopterCamScript.enabled = false;                
                
                // _helicopterCamera01 enabled is false
               _helicopterCamera01.enabled = false;

                // _helicopterCamera01AudioListener enabled is false
                _helicopterCamera01AudioListener.enabled = false;

                // _helicopterCamera02 enabled is false
                _helicopterCamera02.enabled = false;

                // _helicopterCamera02AudioListener enabled is false
                _helicopterCamera02AudioListener.enabled = false;

                // _helicopterCamera03 enabled is false
                _helicopterCamera03.enabled = false;

                // _helicopterCamera03AudioListener enabled is false
                _helicopterCamera03AudioListener.enabled = false;

                // _helicopterAudioSource enabled is false
                _helicopterAudioSource.enabled = false;          

                // _inHelicopter is false
                _inHelicopter = false;

                // Compass

                // _playerCompass enabled is true
                _playerCompass.enabled = true;

                // _playerCompass compassEnabled is true
                _playerCompass.compassEnabled = true;

                // Debug Log
                //Debug.Log("The Player compass is enabled");

                // _helicopterCompass enabled is false
                _helicopterCompass.enabled = false;

                // _helicopterCompass compassEnabled is false
                _helicopterCompass.compassEnabled = false;

                // Debug Log
                //Debug.Log("The Helicopter compass is disabled");

            } // close if _inHelicopter and Input GetKey KeyCode _exitKey

        } // close private void Update     

        // private void OnTriggerStay Collider other
        private void OnTriggerStay(Collider other)
        {
            // if not _inHelicopter and gameObject tag is Player
            if (!_inHelicopter && other.gameObject.tag == "Player")
            {
                // _interfaceTextObject SetActive is true
                _interfaceTextObject.SetActive(true);

                // _interfaceHUDObject SetActive is false
                _interfaceHUDObject.SetActive(false); 

            } // close if not _inHelicopter and gameObject tag is Player
            
            // if not _inHelicopter and gameObject tag is Player and Input GetKey KeyCode _enterKey
            if (!_inHelicopter && other.gameObject.tag == "Player" && Input.GetKey(_enterKey))
            {
                // _interfaceTextObject SetActive is false
                _interfaceTextObject.SetActive(false);

                // _interfaceHUDObject SetActive is true
                _interfaceHUDObject.SetActive(true);                

                // _player SetActive is false 
                _player.SetActive(false);

                // _player transform parent is _helicopter transform
                _player.transform.parent = _helicopter.transform;

                // _helicopterScript enabled is true
                _helicopterScript.enabled = true;

                // _helicopterCamScript enabled is true
                _helicopterCamScript.enabled = true;                

                // _helicopterCamera01 enabled is true                    
                _helicopterCamera01.enabled = true;

                // _helicopterCamera01AudioListener enabled is true
                _helicopterCamera01AudioListener.enabled = true;

                // _helicopterCamera02 enabled is true
                _helicopterCamera02.enabled = true;

                // _helicopterCamera02AudioListener enabled is true
                _helicopterCamera02AudioListener.enabled = true;

                // _helicopterCamera03 enabled is true
                _helicopterCamera03.enabled = true;

                // _helicopterCamera03AudioListener enabled is true
                _helicopterCamera03AudioListener.enabled = true;

                // _helicopterAudioSource enabled is true
                _helicopterAudioSource.enabled = true; 

                // _inHelicopter is true
                _inHelicopter = true;

                // Compass

                // _playerCompass enabled is false
                _playerCompass.enabled = false;

                // _playerCompass compassEnabled is false
                _playerCompass.compassEnabled = false;

                // Debug Log
                //Debug.Log("The Player compass is disabled");

                // _helicopterCompass enabled is true
                _helicopterCompass.enabled = true;

                // _helicopterCompass compassEnabled is true
                _helicopterCompass.compassEnabled = true;

                // Debug Log
                //Debug.Log("The Helicopter compass is enabled"); 
                
            } // close if not _inHelicopter and gameObject tag is Player and Input GetKey KeyCode _enterKey

        } // close private void OnTriggerStay Collider other
        
        // private void OnTriggerExit Collider other
        private void OnTriggerExit(Collider other)
        {
            // if gameObject tag is Player
            if (other.gameObject.tag == "Player")
            {
                // _interfaceTextObject SetActive is false
                _interfaceTextObject.SetActive(false);

                // _interfaceHUDObject SetActive is false
                _interfaceHUDObject.SetActive(false);                  
             
            } // close if gameObject tag is Player

        } // close private void OnTriggerExit Collider other

    } // close public class HelicopterEntry  

} // close namespace BasicHelicopterController
