using nvp.interfaces;
using UnityEngine;

public class NvpComputerV2Model : IPlayerModel
{
    private float _lastDistance = 0;

    public Vector3 CalcNewForceVector(float input, float force, GameObject player, GameObject ball)
    {
        Vector3 dir;
        if (ball == null) return Vector3.zero;

        var distance = Mathf.Abs(ball.transform.position.x - player.transform.position.x);

        if (distance < _lastDistance)
        {
            if (ball.transform.position.y - player.transform.position.y > 0)
            {

                dir = Vector3.up * force;
            }
            else
            {
                dir = Vector3.down * force;
            }
        }
        else
        {
            if (player.transform.position.y > 0)
            {

                dir = Vector3.down * force;
            }
            else
            {
                dir = Vector3.up * force;
            }
        }

        _lastDistance = distance;
        return dir;
    }
}