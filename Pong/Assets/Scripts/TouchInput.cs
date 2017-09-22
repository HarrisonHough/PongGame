using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong
{
    public class TouchInput : MonoBehaviour
    {

        public enum playerNum { none, one, two };
        public playerNum player;

        private RacketMovement racket;

        private void Reset()
        {
            racket = GetComponent<RacketMovement>();
        }
        // Use this for initialization
        void Start()
        {
            if (racket == null)
                racket = GetComponent<RacketMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            if (player == playerNum.one)
                CheckPlayerOneInput();
            else
                CheckPlayerTwoInput();
        }

        void CheckPlayerOneInput()
        {
            if (Input.touchCount > 0)
            {
                racket.MoveRacket(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            }
            else if (Input.touchCount == 0)
            {
                racket.StopMovement();
            }
            if (Input.GetMouseButton(0))
            {
                racket.MoveRacket(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButtonUp(0))
            {
                racket.StopMovement();
            }
        }

        void CheckPlayerTwoInput()
        {

        }
    }
}
