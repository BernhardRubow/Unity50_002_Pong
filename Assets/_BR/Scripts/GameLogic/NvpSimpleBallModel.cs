using nvp.interfaces;
using UnityEngine;

public class NvpSimpleBallModel : IBallModel
{
    private float speedIncrease = 0;

    public Vector3 CalculateNewDirAfterWallHit(Vector3 oldDirection)
    {
        Vector3 newDirection = oldDirection;
        newDirection.y *= -1f;
        return newDirection;
    }

    public Vector3 CalculateNewDirAfterPlayerHit(Vector3 oldDirection)
    {
        Vector3 newDirection = oldDirection;
        newDirection.x *= -1f;
        return newDirection;
    }

    public Vector3 GetStartupDirection()
    {
        Vector3 startUpDirection = new Vector3();

        startUpDirection.x = Mathf.Sign(Random.value - 0.5f);
        startUpDirection.y = (Random.value - 0.5f) * 2f;

        return startUpDirection;
    }

    public float CalcNewSpeed(float speedFactor)
    {
        if (speedIncrease == 0) speedIncrease = speedFactor / 5.0f;

        speedFactor += speedIncrease;
        return speedFactor;
    }
}