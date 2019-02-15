using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;

public class NvpHumanPlayerModel : IPlayerModel
{
    public Vector3 CalcNewForceVector(float input, float force, GameObject player, GameObject ball)
    {
        var dir = Vector3.up * input * force;
        return dir;
    }
}