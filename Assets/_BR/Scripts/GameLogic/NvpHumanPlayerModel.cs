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

public class NvpComputerV1Model : IPlayerModel
{
    public Vector3 CalcNewForceVector(float input, float force, GameObject player, GameObject ball)
    {

        Vector3 dir;
        if (ball == null) return Vector3.zero;

        if (ball.transform.position.y - player.transform.position.y > 0)
        {
            
            dir = Vector3.up * force;
        }
        else
        {
            dir = Vector3.down * force;
        }

        return dir;
    }
}
