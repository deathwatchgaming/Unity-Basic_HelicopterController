/*
 * Name: Basic Helicopter Controller (New Input System)
 * File: HelicopterController.cs
 * Author: DeathwatchGaming
 * License: MIT
 * Unity Version(s): Unity 2021+ - 2022+ 
*/

// Using
using TMPro;
using System; 
using UnityEngine;
using UnityEngine.InputSystem; 

// namespace BasicHelicopterController
namespace BasicHelicopterController
{
    // public enum HelicopterAirspeedType
    public enum HelicopterAirspeedType
    {
        mph,
        kmh 

    } // close public enum HelicopterAirspeedType

    // RequireComponent Rigidbody
    [RequireComponent(typeof(Rigidbody))]

    // RequireComponent MeshCollider
    [RequireComponent(typeof(MeshCollider))]

    // RequireComponent AudioSource
    [RequireComponent(typeof(AudioSource))] 

    // public class HelicopterController
    public class HelicopterController : MonoBehaviour 
    {
        // Components
        [Header("Components")]

            [Tooltip("The Rigidbody Component")]
            // Rigidbody _rigidbody
            [SerializeField] private Rigidbody _rigidbody;

            [Tooltip("The Mesh Collider Component")]
            // MeshCollider _meshCollider
            [SerializeField] private MeshCollider _meshCollider;

        // Rigidbody Adjustments
        [Header("Rb Adjustments")]

            [Tooltip("The Rigidbody Mass")] 
            // float _centerOfMassOffset
            [SerializeField] private float _rigidbodyMass = 360f;

            [Tooltip("The Center of Mass Offset")] 
            // Vector3 _centerOfMassOffset
            [SerializeField] private Vector3 _centerOfMassOffset = new Vector3(0.0f, 0.7f, 1.0f);

        // Transforms
        [Header("Transforms")] 

            [Tooltip("The Top Rotor Transform")]
            // Transform _rotorsTransformTop   
            [SerializeField] private Transform _rotorsTransformTop;

            [Tooltip("The Tail Rotor Transform")]
            // Transform _rotorsTransformTail
            [SerializeField] private Transform _rotorsTransformTail;

         // Amounts
        [Header("Amounts")]

            [Tooltip("The Sensitivity Amount")]
            // float _sensitivity
            [SerializeField] private float _sensitivity = 500f;

            [Tooltip("The Throttle Amount")]
            // float _throttleAmount
            [SerializeField] private float _throttleAmount = 25f;

            [Tooltip("The Max Thrust Amount")]
            // float _maxThrust
            [SerializeField] private float _maxThrust = 5f;

            [Tooltip("The Rotor Speed Modifier")]        
            // float _rotorSpeedModifier
            [SerializeField] private float _rotorSpeedModifier = 10f;

        // Speed
        [Header("Airspeed")]

            [Tooltip("The Airspeed Measurement Unit")]
            // HelicopterAirspeedType _airspeedType   
            [SerializeField] private HelicopterAirspeedType _airspeedType;            
        
            [Tooltip("The Maximum Airspeed Amount For Example: Say 152 For MPH Or Say 244 For KMH")]
            // float _maxAirspeed mph is default (152mph)
            [SerializeField] private float _maxAirspeed = 76;

        // HUD
        [Header("HUD")]

            [Tooltip("The Interface TextMeshPro HUD")]
            // TextMeshProUGUI _heliHUD
            [SerializeField] private TextMeshProUGUI _heliHUD;

        // Audio
        [Header("Audio")]

            [Tooltip("The Audio Source")]
            // AudioSource _audioSource
            [SerializeField] private AudioSource _audioSource;

            [Tooltip("The Rotor Sound Audio Clip")]
            // AudioClip _rotorSound
            [SerializeField] private AudioClip _rotorSound;

        // Input Actions
        [Header("Input Actions")]

            [Tooltip("The input action asset")]
            // InputActionAsset _helicopterControls
            [SerializeField] private InputActionAsset _helicopterControls;

        // InputAction _moveTwoAction (Pitch & Roll)
        private InputAction _moveTwoAction;

        // Vector2 _moveTwoInput (Pitch & Roll)
        private Vector2 _moveTwoInput;

        // InputAction _moveOneAction (Yaw)
        private InputAction _moveOneAction;

        // Vector2 _moveOneInput (Yaw)
        private Vector2 _moveOneInput;

        // InputAction _maxThrottleAction (Max)
        private InputAction _maxThrottleAction;

        // InputAction _minThrottleAction (Min)
        private InputAction _minThrottleAction;

        // bool _maxThrottleIsPressed
        private bool _maxThrottleIsPressed;

        // bool _minThrottleIsPressed
        private bool _minThrottleIsPressed;

        // bool _maxThrottleWasPressed
        private bool _maxThrottleWasPressed;

        // bool _minThrottleWasPressed
        private bool _minThrottleWasPressed;        

        // bool _rotorCheck
        private bool _rotorCheck = false;

        // float _throttle  
        private float _throttle;
       
        // float _heliRoll
        private float _heliRoll;

        // float _heliPitch
        private float _heliPitch;

        // float _heliYaw
        private float _heliYaw;

        // Awake is called even if the script is disabled
            
        // private void Awake
        private void Awake()
        {
            // _rigidbody GetComponent Rigidbody
            _rigidbody = GetComponent<Rigidbody>();

            // _rigidbody mass is _rigidbodyMass
            _rigidbody.mass = _rigidbodyMass;

            // Adjust the rigibody center of mass on X,Y,Z to help prevent the helicopter from tipping over
            // _rigidbody centerOfMass is _centerOfMassOffset
            _rigidbody.centerOfMass = _centerOfMassOffset; 

            // _meshCollider GetComponent MeshCollider
            _meshCollider = GetComponent<MeshCollider>();

            // _meshCollider convex is true
            _meshCollider.convex = true;
            
            // _audioSource GetComponent AudioSource
            _audioSource = GetComponent<AudioSource>();

            // Cursor lockState is CursorLockMode Locked
            Cursor.lockState = CursorLockMode.Locked;

            // Cursor visible is false
            Cursor.visible = false;

            // Input Actions

            // _moveTwoAction
            _moveTwoAction = _helicopterControls.FindActionMap("Helicopter").FindAction("MoveTwo");

            // _moveTwoAction performed
            _moveTwoAction.performed += context => _moveTwoInput = context.ReadValue<Vector2>();

            // _moveTwoAction canceled
            _moveTwoAction.canceled += context => _moveTwoInput = Vector2.zero;

            // _moveOneAction
            _moveOneAction = _helicopterControls.FindActionMap("Helicopter").FindAction("MoveOne");

            // _moveOneAction performed
            _moveOneAction.performed += context => _moveOneInput = context.ReadValue<Vector2>();

            // _moveOneAction canceled
            _moveOneAction.canceled += context => _moveOneInput = Vector2.zero;

            // _maxThrottleAction
            _maxThrottleAction = _helicopterControls.FindActionMap("Helicopter").FindAction("MaxThrottle");

            // _minThrottleAction
            _minThrottleAction = _helicopterControls.FindActionMap("Helicopter").FindAction("MinThrottle");

        } // close private void Awake
        
        // private void OnEnable
        private void OnEnable()
        {
            // Input Actions Enable

            // _moveTwoAction Enable
            _moveTwoAction.Enable();

            // _moveOneAction Enable
            _moveOneAction.Enable();

            // _maxThrottleAction Enable
            _maxThrottleAction.Enable();

            // _minThrottleAction Enable
            _minThrottleAction.Enable();

        } // close private void OnEnable

        // private void OnDisable
        private void OnDisable()
        {
            // Input Actions Disable

            // _moveTwoAction Disable
            _moveTwoAction.Disable();

            // _moveOneAction Disable
            _moveOneAction.Disable();

            // _maxThrottleAction Disable
            _maxThrottleAction.Disable();

            // _minThrottleAction Disable
            _minThrottleAction.Disable();

        } // close private void OnDisable

        // Update is called every frame

        // private void Update
        private void Update()
        {
            // Handle Press State
            HandlePressState();

            // Handle Inputs
            HandleInputs();

            // Handle Airspeed
            HandleAirspeed();

            // Update HUD
            UpdateHUD();
              
            // Handle Rotors
            HandleRotors();

        } // close private void Update

        // FixedUpdate is called every physics step

        // private void FixedUpdate
        private void FixedUpdate()
        {
            // _rigidbody AddForce
            _rigidbody.AddForce(transform.up * _throttle, ForceMode.Impulse);
            
            // _rigidbody AddTorque
            _rigidbody.AddTorque(transform.right * _heliPitch * _sensitivity);

            // _rigidbody AddTorque
            _rigidbody.AddTorque(-transform.forward * _heliRoll * _sensitivity);

            // _rigidbody AddTorque
            _rigidbody.AddTorque(transform.up * _heliYaw * _sensitivity); 

        } // close private void FixedUpdate

        // private void HandlePressState
        private void HandlePressState()
        {
            // _maxThrottleIsPressed
            _maxThrottleIsPressed = _maxThrottleAction.IsPressed();

            // _minThrottleIsPressed
            _minThrottleIsPressed = _minThrottleAction.IsPressed();

            // _maxThrottleWasPressed
            _maxThrottleWasPressed = _maxThrottleAction.WasPressedThisFrame();

            // _minThrottleWasPressed
            _minThrottleWasPressed = _minThrottleAction.WasPressedThisFrame();            

        } // close private void HandlePressState
        
        // private void HandleInputs
        private void HandleInputs()
        {
            // _heliRoll (Roll)
            _heliRoll = _moveTwoInput.x;

            // _heliPitch (Pitch)
            _heliPitch = _moveTwoInput.y; 

            // _heliYaw (Yaw)
            _heliYaw = _moveOneInput.x;

            // _rotorCheck is false
            _rotorCheck = false;
            
            // if Input GetKey _maxThrottleKey
            if (_maxThrottleIsPressed)
            {
                // _throttle
                _throttle += Time.deltaTime * _throttleAmount;
                
                // if Input GetKeyDown _maxThrottleKey
                if (_maxThrottleWasPressed)
                {
                    // _rotorCheck is true
                    _rotorCheck = true;

                } // close if Input GetKeyDown _maxThrottleKey

            } // close if Input GetKey _maxThrottleKey
            
            // else if Input GetKey _minThrottleKey
            else if (_minThrottleIsPressed)
            {
                // _throttle
                _throttle -= Time.deltaTime * _throttleAmount;

                // if Input GetKeyDown _minThrottleKey
                if (_minThrottleWasPressed)
                {
                    // _rotorCheck is true
                    _rotorCheck = true;

                } // close if Input GetKeyDown _minThrottleKey

            } // close else if Input GetKey _minThrottleKey
            
            // _throttle
            _throttle = Mathf.Clamp(_throttle, 0f, 100f);

        } // close private void HandleInputs

        // private void HandleAirspeed
        private void HandleAirspeed()
        {
            // Take care of airspeed unit type and max airspeed

            // float _airspeed
            float _airspeed = _rigidbody.velocity.magnitude;

            // _airspeedType equals HelicopterAirspeedType.mph
            if (_airspeedType == HelicopterAirspeedType.mph)
            {
                // 2.23694 is the constant to convert a value from m/s to mph

                // _airspeed
                _airspeed *= 2.23694f;

                // if _airspeed > _maxAirspeed
                if (_airspeed > _maxAirspeed)
                {
                    // _rigidbody.velocity
                    _rigidbody.velocity = (_maxAirspeed / 2.23694f) * _rigidbody.velocity.normalized;

                } // close if _airspeed > _maxAirspeed
                        
            } // close if _airspeedType equals HelicopterAirspeedType.mph

            // else if _airspeedType equals HelicopterAirspeedType.kmh
            else if (_airspeedType == HelicopterAirspeedType.kmh)
            {
                // 3.6 is the constant to convert a value from m/s to km/h
                
                // _airspeed
                _airspeed *= 3.6f;

                // if _airspeed > _maxAirspeed
                if (_airspeed > _maxAirspeed)
                {
                    // _rigidbody.velocity
                    _rigidbody.velocity = (_maxAirspeed / 3.6f) * _rigidbody.velocity.normalized;

                } // close if _airspeed > _maxAirspeed
                       
            } // close else if _airspeedType equals HelicopterAirspeedType.kmh

        } // close private void HandleAirspeed

        // private void UpdateHUD
        private void UpdateHUD()
        {
            // _heliHUD.text Throttle
            _heliHUD.text = "Throttle: " + _throttle.ToString("F0") + " %\n";

            // if _airspeedType is HelicopterAirspeedType.mph
            if (_airspeedType == HelicopterAirspeedType.mph)
            {
                // 2.23694 is the constant to convert a value from m

                // _heliHUD.text Airspeed
                _heliHUD.text += "Airspeed: " + (_rigidbody.velocity.magnitude * 2.23694f).ToString("F0") + " mph\n";

                // 0.3048 is the constant to convert from m to ft ie: 0.3048 m = 1 ft thus altitude in m divided by 0.3048 gets feet

                // _heliHUD.text Altitude
                _heliHUD.text += "Altitude: " + (transform.position.y / 0.3048f).ToString("F0") + " ft";                

            } // close if _airspeedType is HelicopterAirspeedType.mph

            // else if _airspeedType is HelicopterAirspeedType.kmh
            else if (_airspeedType == HelicopterAirspeedType.kmh)
            {
                // 3.6 is the constant to convert a value from m/s to km/h

                // _heliHUD.text Airspeed
                _heliHUD.text += "Airspeed: " + (_rigidbody.velocity.magnitude * 3.6f).ToString("F0") + " kmh\n";

                // m is default measurement unit hence keep as is since we want to keep m when kmh speed type selected

                // _heliHUD.text Altitude
                _heliHUD.text += "Altitude: " + transform.position.y.ToString("F0") + " m";

            } // close else if _speedType is HelicopterAirspeedType.kmh

        } // close private void UpdateHUD

        // private void HandleRotors
        private void HandleRotors()
        {              
            // Top Rotor Rotate
            
            // _rotorsTransformTop Rotate
            _rotorsTransformTop.Rotate(Vector3.up * (_maxThrust * _throttle) * _rotorSpeedModifier);

            // Tail Rotor Rotate Roll or Yaw is 0

            // if Input GetAxis _heliRollInput is 0 or Input GetAxis _heliYawInput is 0
            if (_heliRoll == 0 || _heliYaw == 0)
            {
                // _rotorsTransformTail Rotate
                _rotorsTransformTail.Rotate(Vector3.right * _throttle * _rotorSpeedModifier);

            } // close if Input GetAxis _heliRollInput is 0 or Input GetAxis _heliYawInput is 0

            // Tail Rotor Yaw Rotate

            // if Input GetAxis _heliYawInput is less than 0
            if (_heliYaw < 0)
            {
                // _rotorsTransformTail Rotate
                _rotorsTransformTail.Rotate(Vector3.left * (_maxThrust * _throttle) * _rotorSpeedModifier);

            } // close if Input GetAxis _heliYawInput is less than 0

            // if Input GetAxis _heliYawInput is greater than 0
            if (_heliYaw > 0)
            {
                // _rotorsTransformTail Rotate
                _rotorsTransformTail.Rotate(Vector3.right * (_maxThrust * _throttle) * _rotorSpeedModifier);

            } // close if Input GetAxis _heliYawInput is greater than 0

            // Tail Rotor Roll Rotate

            // if Input GetAxis _heliRollInput is less than 0
            if (_heliRoll < 0)
            {
                // _rotorsTransformTail Rotate
                _rotorsTransformTail.Rotate(Vector3.left * (_maxThrust * _throttle) * _rotorSpeedModifier);

            } // close if Input GetAxis _heliRollInput is less than 0

            // if Input GetAxis _heliRollInput is greater than 0
            if (_heliRoll > 0)
            {
                // _rotorsTransformTail Rotate
                _rotorsTransformTail.Rotate(Vector3.right * (_maxThrust * _throttle) * _rotorSpeedModifier);

            } // close if Input GetAxis _heliRollInput is greater than 0
            
            // _audioSource volume
            _audioSource.volume = (_throttle * 0.01f);  

            // if _rotorCheck is true
            if (_rotorCheck == true)
            {
                // PlayRotorSound
                PlayRotorSound(); 

            } // close if _rotorCheck is true

        } // close private void HandleRotors

        // private void PlayRotorSound
        private void PlayRotorSound()
        {
            // _audioSource clip is _rotorSound
            _audioSource.clip = _rotorSound;

            // _audioSource loop is true
            _audioSource.loop = true; 

            // _audioSource Play      
            _audioSource.Play();

        } // close private void PlayRotorSound     

    } // close public class HelicopterController

} // close namespace BasicHelicopterController
