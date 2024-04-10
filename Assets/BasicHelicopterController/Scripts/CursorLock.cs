/*
 * Name: Cursor Lock State
 * File: CursorLock.cs
 * Author: DeathwatchGaming
 * License: MIT
*/

/*
* How to use:
* 1 - Attach this script to the player / controller
*/  

// Using
using UnityEngine;

// namespace CursorLockState
namespace CursorLockState
{
    // public class HelicopterController
    public class CursorLock : MonoBehaviour 
    {
        // private bool CursorLockEnabled
        [SerializeField] private bool CursorLockEnabled = true;

        // Start is called before the first frame update
        // private void Start
        private void Start()
        {
            // Cursor Start State
            CursorStartState();

        } // close private void Start
        
        // Update is called every frame
        // private void Update
        private void Update()
        {
            // if CursorLockEnabled is true
            if (CursorLockEnabled == true)
            {
                // GetComponent CursorLock enabled is true
                GetComponent<CursorLock>().enabled = true;
                
                // Debug Log CursorLock is enabled
                Debug.Log("The CursorLock is enabled.");

            } // close if CursorLockEnabled is true
            
            // if CursorLockEnabled is false
            if (CursorLockEnabled == false)
            {
                // GetComponent CursorLock enabled is false
                GetComponent<CursorLock>().enabled = false;
                
                // Debug Log CursorLock is disabled
                Debug.Log("The CursorLock is disabled.");

            } // close if CursorLockEnabled is false

            // CursorUpdateState
            CursorUpdateState();

        } // close private void Update
        
        // Method called during Start 
        // private void CursorStartState
        private void CursorStartState()
        {
            // Cursor Lock State on Start

            // if CursorLockEnabled is true
            if (CursorLockEnabled == true)
            {
                // Cursor lockState is CursorLockMode Locked
                Cursor.lockState = CursorLockMode.Locked;

                // Cursor visible is false
                Cursor.visible = false; 

            } // close if CursorLockEnabled is true
            
            // if CursorLockEnabled is false
            if (CursorLockEnabled == false)
            {
                // Cursor lockState is CursorLockMode None
                Cursor.lockState = CursorLockMode.None;

                // Cursor visible is true
                Cursor.visible = true; 

            } // close if CursorLockEnabled is false

        } // close private void CursorStartState 
        
        // Method called during Update 
        // private void CursorUpdateState
        private void CursorUpdateState()
        {
            // Cursor Lock State on Update

            //  if CursorLockEnabled is true
            if (CursorLockEnabled == true)
            {            
                // Update Cursor State by escape

                // if Input GetKeyDown escape
                if (Input.GetKeyDown("escape")) 
                { 
                    // if Input GetKeyDown escape and Cursor lockState is CursorLockMode Locked
                    if (Input.GetKeyDown("escape") && Cursor.lockState == CursorLockMode.Locked) 
                    {
                        // Cursor lockState CursorLockMode None
                        Cursor.lockState = CursorLockMode.None;

                        // Cursor visible is true
                        Cursor.visible = true; 

                    } // close if Input GetKeyDown escape and Cursor lockState is CursorLockMode Locked
                    
                    // if Input GetKeyDown escape and Cursor lockState is CursorLockMode None
                    if (Input.GetKeyDown("escape") && Cursor.lockState == CursorLockMode.None) 
                    {
                        // Cursor lockState CursorLockMode Locked
                        Cursor.lockState = CursorLockMode.Locked;

                        // Cursor visible is false
                        Cursor.visible = false; 
                        
                    } // close if Input GetKeyDown escape and Cursor lockState is CursorLockMode None            

                } // close if Input GetKeyDown escape

            } // close if CursorLockEnabled is true
            
            // if CursorLockEnabled is false
            if (CursorLockEnabled == false)
            {
                // Cursor lockState CursorLockMode None
                Cursor.lockState = CursorLockMode.None;

                // Cursor visible is true
                Cursor.visible = true; 

            } // close if CursorLockEnabled is false          

        } // close private void CursorUpdateState 

    } // close public class CursorLock

} // close namespace CursorLockState
