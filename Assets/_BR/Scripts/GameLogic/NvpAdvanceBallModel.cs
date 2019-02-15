using nvp.interfaces;
using UnityEngine;

public class NvpAdvanceBallModel : IBallModel
{
    private float speedIncrease = 0;
    private float initialSpeed = 0;

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
        newDirection.y = newDirection.x * ((Random.value - 0.5f) * 2);
        
        return newDirection.normalized;
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
        if (speedIncrease == 0)
        {
            initialSpeed = speedFactor;
            speedIncrease = speedFactor / 5.0f;
        }

        speedFactor += speedIncrease;
        return speedFactor;
    }

    public float CalcNewStartSpeed(float speedFactor)
    {
        initialSpeed = Mathf.Clamp(initialSpeed + 1, initialSpeed, 15);
        return initialSpeed;
    }
}