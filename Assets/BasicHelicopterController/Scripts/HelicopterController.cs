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

        // Rigidbody
        [Header("Rigid")]

            // Rigidbody _rigidbody
    	    [SerializeField] private Rigidbody _rigidbody;

        // Mesh Collider
        [Header("Collider")]

            // MeshCollider _meshCollider
    	    [SerializeField] private MeshCollider _meshCollider;

        // Audio
        [Header("Audio")]

            // AudioSource _audioSource
            [SerializeField] private AudioSource _audioSource;

            // AudioClip _rotorSound
            [SerializeField] private AudioClip _rotorSound;
        
            // Bool _rotorCheck
            private bool _rotorCheck = false;

         // Amounts
        [Header("Amounts")]

            // _sensitivity
            [SerializeField] private float _sensitivity = 500f;

            // _throttleAmount
            [SerializeField] private float _throttleAmount = 25f;

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
        
            // _rotorSpeedModifier
            [SerializeField] private float _rotorSpeedModifier = 10f;

        // Transforms
        [Header("Transforms")]    

            // _rotorsTransformTop   
            [SerializeField] private Transform _rotorsTransformTop;

            // _rotorsTransformTail
            [SerializeField] private Transform _rotorsTransformTail;

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

            // Cursor lockState is CursorLockMode Locked
            Cursor.lockState = CursorLockMode.Locked;

            // Cursor.visible is false
            Cursor.visible = false; 

        } // close private void Awake

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
            _roll = Input.GetAxis("Roll");

            // _pitch
            _pitch = Input.GetAxis("Pitch"); 

            // _yaw
            _yaw = Input.GetAxis("Yaw");

            // _rotorCheck false
            _rotorCheck = false;
            
            // if Input GetKey LeftControl
            if (Input.GetKey(KeyCode.LeftControl))
            {
                // _throttle
                _throttle += Time.deltaTime * _throttleAmount;
                
                // if Input GetKeyDown LeftControl
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    // _rotorCheck true
                    _rotorCheck = true;

                } // close if Input GetKeyDown LeftControl

            } // close if Input GetKey LeftControl
            
            // else if Input GetKey LeftShift
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                // _throttle
                _throttle -= Time.deltaTime * _throttleAmount;
                
                // if Input GetKeyDown LeftShift
                if (Input.GetKeyDown(KeyCode.LeftShift))
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
