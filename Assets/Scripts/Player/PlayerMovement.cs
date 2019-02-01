using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Player Movement Class 
*/

namespace Pong
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5f;
        private float currentTime = 0;
        [SerializeField]
        private float playerSizeX = 0.7f;

        private void Start()
        {
            playerSizeX = transform.localScale.x;
        }

        /// <summary>
        /// Moves towards target position at predefined speed
        /// </summary>
        /// <param name="targetPosition"></param>
        public void Move(Vector3 targetPosition)
        {
            targetPosition.z = 0;
            targetPosition.y = transform.position.y;
            targetPosition.x = Mathf.Clamp(targetPosition.x, PlaySpace.xMin + (playerSizeX / 2), PlaySpace.xMax - (playerSizeX / 2));
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }

        /// <summary>
        /// Stops movement
        /// </summary>
        public void StopMovement()
        {
            currentTime = 0f;
        }

    }
}
