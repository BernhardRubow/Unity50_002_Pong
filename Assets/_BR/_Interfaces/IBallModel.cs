using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nvp.interfaces
{
    public interface IBallModel
    {
        Vector3 CalculateNewDirAfterWallHit(Vector3 oldDirection);

        Vector3 CalculateNewDirAfterPlayerHit(Vector3 oldDirection);

        Vector3 GetStartupDirection();

        float CalcNewSpeed(float speedFactor);

        float CalcNewStartSpeed(float speedFactor);
    }
}
