using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public Vector3 offset;

    void LateUpdate()
    {
        if (GameController.instance.body1 == null && GameController.instance.body2 == null)
            return;
            
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPos = centerPoint + offset;
        transform.position = newPos;
    }

    Vector3 GetCenterPoint()
    {
        if (GameController.instance.body1 == null) {
            return GameController.instance.body2.transform.position;
        }
        if (GameController.instance.body2 == null) {
            return GameController.instance.body1.transform.position;
        }

        var bounds = new Bounds(GameController.instance.body1.transform.position, Vector3.zero);
        bounds.Encapsulate(GameController.instance.body1.transform.position);
        bounds.Encapsulate(GameController.instance.body2.transform.position);

        return bounds.center;
    }
}
