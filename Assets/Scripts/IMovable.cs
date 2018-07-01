using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: IMovable Class 
*/

namespace Pong
{
    /// <summary>
    /// A Interface to be used for moveable objects
    /// such as the player paddle
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMovable<T>
    {

        void Move(T moveVector);

    }
}
