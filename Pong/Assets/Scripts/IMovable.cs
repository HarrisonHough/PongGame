using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public interface IMovable<T>
    {

        void Move(T moveVector);

    }
}
