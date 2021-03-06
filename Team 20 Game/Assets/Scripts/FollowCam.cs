using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float smoothTime = 0.2f;
    public Transform target;
    private Vector3 _velocity = Vector3.zero;

    public Transform defaultTran;

    private void LateUpdate()
    {
        if (ChosenGummy.chosenPlayer != null)
        {
            target = ChosenGummy.chosenPlayer.transform;
        }
        else
        {
            target = defaultTran;
        }

        if (target.position.y > -100)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 1, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        }
    }
}
