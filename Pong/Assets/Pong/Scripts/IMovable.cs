using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
