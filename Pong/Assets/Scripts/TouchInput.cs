using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong
{
    public class TouchInput : MonoBehaviour
    {

        public enum playerNum { none, one, two };
        public playerNum player;

        private PlayerMovement playerMovement;

        private void Reset()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        // Use this for initialization
        void Start()
        {
            if (playerMovement == null)
                playerMovement = GetComponent<PlayerMovement>();
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

        void CheckPlayerTwoInput()
        {

        }
    }
}
