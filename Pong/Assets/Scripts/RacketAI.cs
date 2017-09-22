using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class RacketAI : MonoBehaviour
    {

        public float speed = 8f;
        [SerializeField]
        private Transform ball;
        [SerializeField]
        private float racketSize = 1;
        private bool activeAI = false;

        private void Reset()
        {
            ball = FindObjectOfType<Ball>().GetComponent<Transform>();
        }
        // Use this for initialization
        void Start()
        {
            ball = FindObjectOfType<Ball>().GetComponent<Transform>();
            StartCoroutine(TrackBall());
        }

        IEnumerator TrackBall()
        {
            activeAI = true;
            Vector3 targetPosition = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
            while (activeAI)
            {
                
                targetPosition.x = Mathf.Clamp(ball.position.x, PlaySpace.xMin + (racketSize/2), PlaySpace.xMax - (racketSize/2));
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
                yield return null;
            }
        }

    }
}
