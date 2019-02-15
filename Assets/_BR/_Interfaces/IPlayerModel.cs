using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nvp.interfaces
{
    public interface IPlayerModel
    {
        Vector3 CalcNewForceVector(float input, float force, GameObject player = null, GameObject ball = null);
    }
}
