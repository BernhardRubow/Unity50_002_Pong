using nvp.interfaces;
using UnityEngine;

public class NvpComputerV4Model : IPlayerModel
{
    private float _lastVerticalDistance = 0;
    private Vector3 _lastBallPosition = Vector3.zero;
    private float _reactionThreshold = 0.3f;
    private float _timer = 0;

    public Vector3 CalcNewForceVector(float input, float force, GameObject player, GameObject ball)
    {
        Vector3 dir = Vector3.zero;
        if (ball == null) return Vector3.zero;

        var verticalDistance = Mathf.Abs(ball.transform.position.x - player.transform.position.x);
        var horizontalDistance = Mathf.Abs(ball.transform.position.y - player.transform.position.y);
        var deltaX = (ball.transform.position.x - _lastBallPosition.x);
        var deltaY = (ball.transform.position.y - _lastBallPosition.y);

        var targetY = verticalDistance * deltaY / deltaX  + ball.transform.position.y;

        if (targetY > 26) targetY = 26 - (targetY - 26);
        if (targetY < -26) targetY = -26 - (targetY + 26);

       

        if (verticalDistance < _lastVerticalDistance)
        {
            
            _timer += Time.deltaTime;
            if (_timer < _reactionThreshold) return Vector3.zero;
            if (targetY - player.transform.position.y > 0)
            {
                dir = Vector3.up * force * Mathf.Clamp(horizontalDistance, -1, 1);
            }
            else
            {
                dir = Vector3.down * force * Mathf.Clamp(horizontalDistance, -1, 1);
            }
        }
        else
        {
            _timer = 0f;
            dir = Vector3.up * force * Mathf.Clamp(-player.transform.position.y, -1f, 1f);
            targetY = 0;
        }

        _lastVerticalDistance = verticalDistance;
        _lastBallPosition = ball.transform.position;
        return dir;
    }
}