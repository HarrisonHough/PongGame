using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong
{
    public class PlayerMovement : MonoBehaviour
    {

        private float moveSpeed = 5f;
        private float currentTime = 0;
        private float playerSize = 0.7f;

        public void Move(Vector3 targetPosition)
        {
            
            targetPosition.z = 0;
            targetPosition.y = transform.position.y;
            targetPosition.x = Mathf.Clamp(targetPosition.x, PlaySpace.xMin + (playerSize / 2), PlaySpace.xMax - (playerSize / 2));
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }

        public void StopMovement()
        {
            currentTime = 0f;
        }

    }
}
