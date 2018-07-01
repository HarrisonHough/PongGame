using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Touch Input Class 
*/


namespace Pong
{
    /// <summary>
    /// This Class handles the touch input for mobile devices
    /// </summary>
    public class TouchInput : MonoBehaviour
    {
        //This enum is used to ID whether the this reads the input from player 1 or 2
        public enum playerNum { none, one, two };
        public playerNum player;

        // store reference to player movement component
        private PlayerMovement playerMovement;

        /// <summary>
        /// Reassigned PlayerMovement component
        /// </summary>
        private void Reset()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            if (playerMovement == null)
                playerMovement = GetComponent<PlayerMovement>();
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            if (player == playerNum.one)
                CheckPlayerOneInput();
            else
                CheckPlayerTwoInput();
        }

        /// <summary>
        /// Checks for player 1 input
        /// </summary>
        void CheckPlayerOneInput()
        {
            if (Input.touchCount > 0)
            {
                playerMovement.Move(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            }
            else if (Input.touchCount == 0)
            {
                playerMovement.StopMovement();
            }
            if (Input.GetMouseButton(0))
            {
                playerMovement.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButtonUp(0))
            {
                playerMovement.StopMovement();
            }
        }

        /// <summary>
        /// Checks for player 2 inpuut
        /// TODO Remove
        /// </summary>
        void CheckPlayerTwoInput()
        {

        }
    }
}
