/*
 * Name: Basic Helicopter Controller
 * File: HelicopterController.cs
 * Author: DeathwatchGaming
 * License: MIT
*/

// Using
using UnityEngine;

// namespace BasicHelicopterController
namespace BasicHelicopterController
{

    // RequireComponent Rigidbody
    [RequireComponent(typeof(Rigidbody))]

    // RequireComponent MeshCollider
    [RequireComponent(typeof(MeshCollider))]

    // RequireComponent AudioSource
    [RequireComponent(typeof(AudioSource))] 

    // public class HelicopterController
    public class HelicopterController : MonoBehaviour 
    {
        // Header Inputs
        [Header("Inputs")]
        
            [Tooltip("Roll Movement Input")]
            // private string _rollInput
            [SerializeField] private string _rollInput = "Roll";

            [Tooltip("Pitch Movement Input")]
            // private string _pitchInput
            [SerializeField] private string _pitchInput = "Pitch";

            [Tooltip("Yaw Movement Input")]
            // private string _yawInput
            [SerializeField] private string _yawInput = "Yaw";

            [Tooltip("Minimum Throttle Input Key")]
            // private KeyCode _minThrottleKey
            [SerializeField] private KeyCode _minThrottleKey = KeyCode.LeftShift;

            [Tooltip("Maximum Throttle Input Key")]
            // private KeyCode _maxThrottleKey
            [SerializeField] private KeyCode _maxThrottleKey = KeyCode.LeftControl;        

        // Components
        [Header("Components")]

            [Tooltip("The Rigidbody Component")]
            // Rigidbody _rigidbody
    	    [SerializeField] private Rigidbody _rigidbody;

            [Tooltip("The Mesh Collider Component")]
            // MeshCollider _meshCollider
    	    [SerializeField] private MeshCollider _meshCollider;

        // Audio
        [Header("Audio")]

            [Tooltip("The Audio Source")]
            // AudioSource _audioSource
            [SerializeField] private AudioSource _audioSource;

            [Tooltip("The Rotor Sound Audio Clip")]
            // AudioClip _rotorSound
            [SerializeField] private AudioClip _rotorSound;

            [Tooltip("Rotor Check Bool")]        
            // Bool _rotorCheck
            private bool _rotorCheck = false;

         // Amounts
        [Header("Amounts")]

            [Tooltip("The Sensitivity Amount")]
            // _sensitivity
            [SerializeField] private float _sensitivity = 500f;

            [Tooltip("The Throttle Amount")]
            // _throttleAmount
            [SerializeField] private float _throttleAmount = 25f;

            [Tooltip("The Max Thrust Amount")]
            // _maxThrust
            [SerializeField] private float _maxThrust = 5f;

            // _throttle  
            private float _throttle;
       
            // _roll
            private float _roll;

            // _pitch
            private float _pitch;

            // _yaw
            private float _yaw;

            [Tooltip("The Rotor Speed Modifier")]        
            // _rotorSpeedModifier
            [SerializeField] private float _rotorSpeedModifier = 10f;

        // Transforms
        [Header("Transforms")] 

            [Tooltip("The Top Rotor Transform")]
            // _rotorsTransformTop   
            [SerializeField] private Transform _rotorsTransformTop;

            [Tooltip("The Tail Rotor Transform")]
            // _rotorsTransformTail
            [SerializeField] private Transform _rotorsTransformTail;

        // Awake is called even if the script is disabled
        // Awake
        private void Awake()
        {
            // _rigidbody GetComponent Rigidbody
       	    _rigidbody = GetComponent<Rigidbody>();

            // _rigidbody mass
            _rigidbody.mass = 360f;

            // Note: If using Unity 2021 LTS
            // 2021 does not have automaticCenterOfMass thus to curb error you would need to comment out
            // _rigidbody automaticCenterOfMass bool false
            _rigidbody.automaticCenterOfMass = false;
            
            // _rigidbody centerOfMass x: 0 y: 0.7 z: 1
            _rigidbody.centerOfMass = new Vector3(0.0f, 0.7f, 1.0f);

            // _meshCollider GetComponent MeshCollider
       	    _meshCollider = GetComponent<MeshCollider>();

            // _meshCollider convex
            _meshCollider.convex = true;
            
            // _audioSource GetComponent AudioSource
            _audioSource = GetComponent<AudioSource>();

        } // close private void Awake
        
        // Update is called every frame
        // private void Update
        private void Update()
        {
            // HandleInputs
            HandleInputs();
            
            // _rotorsTransformTop
            _rotorsTransformTop.Rotate(Vector3.up * (_maxThrust * _throttle) * _rotorSpeedModifier);
           
            // _rotorsTransformTail
            _rotorsTransformTail.Rotate(Vector3.left * _throttle * _rotorSpeedModifier);
            
            // _audioSource volume
            _audioSource.volume = (_throttle * 0.01f);  

            // if _rotorCheck is true
            if (_rotorCheck == true)
            {
                // PlayRotorSound
                PlayRotorSound(); 

            } // close if _rotorCheck is true

        } // close private void Update

        // FixedUpdate is called every physics step
        // private void FixedUpdate
        private void FixedUpdate()
        {
            // _rigidbody AddForce
            _rigidbody.AddForce(transform.up * _throttle, ForceMode.Impulse);
            
            // _rigidbody AddTorque
            _rigidbody.AddTorque(transform.right * _pitch * _sensitivity);

            // _rigidbody AddTorque
            _rigidbody.AddTorque(-transform.forward * _roll * _sensitivity);

            // _rigidbody AddTorque
            _rigidbody.AddTorque(transform.up * _yaw * _sensitivity); 

        } // close private void FixedUpdate    
        
        // private void HandleInputs
        private void HandleInputs()
        {
            // _roll
            _roll = Input.GetAxis(_rollInput);

            // _pitch
            _pitch = Input.GetAxis(_pitchInput); 

            // _yaw
            _yaw = Input.GetAxis(_yawInput);

            // _rotorCheck false
            _rotorCheck = false;
            
            // if Input GetKey LeftControl
            if (Input.GetKey(_maxThrottleKey))
            {
                // _throttle
                _throttle += Time.deltaTime * _throttleAmount;
                
                // if Input GetKeyDown LeftControl
                if (Input.GetKeyDown(_maxThrottleKey))
                {
                    // _rotorCheck true
                    _rotorCheck = true;

                } // close if Input GetKeyDown LeftControl

            } // close if Input GetKey LeftControl
            
            // else if Input GetKey LeftShift
            else if (Input.GetKey(_minThrottleKey))
            {
                // _throttle
                _throttle -= Time.deltaTime * _throttleAmount;
                
                // if Input GetKeyDown LeftShift
                if (Input.GetKeyDown(_minThrottleKey))
                {
                    // _rotorCheck true
                    _rotorCheck = true;

                } // close if Input GetKeyDown LeftShift

            } // close else if Input GetKey LeftShift 
            
            // _throttle
            _throttle = Mathf.Clamp(_throttle, 0f, 100f);

        } // close private void HandleInputs

        // private void PlayRotorSound
        private void PlayRotorSound()
        {
            // _audioSource clip
            _audioSource.clip = _rotorSound;

            // _audioSource loop is true
            _audioSource.loop = true; 

            // _audioSource Play      
            _audioSource.Play();

        } // close private void PlayRotorSound 

    } // close public class HelicopterController

} // close namespace BasicHelicopterController
