using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong
{
    public class RacketMovement : MonoBehaviour
    {

        private float moveSpeed = 5f;
        private float currentTime = 0;
        private float racketSize = 0.7f;

        public void MoveRacket(Vector3 targetPosition)
        {
            
            targetPosition.z = 0;
            targetPosition.y = transform.position.y;
            targetPosition.x = Mathf.Clamp(targetPosition.x, PlaySpace.xMin + (racketSize / 2), PlaySpace.xMax - (racketSize / 2));
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }

        public void StopMovement()
        {
            currentTime = 0f;
        }

    }
}
