using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public float minSize = 5, maxSize = 10;
    public Vector3 offset;

    private float minX, minY, maxX, maxY;
    private Camera camera;

    void Start() {
        camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (GameController.instance.body1 == null && GameController.instance.body2 == null)
            return;
        
        CalculateBounds();
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPos = centerPoint + offset;
        transform.position = newPos;

        float sizeX = maxX - minX;
        float sizeY = maxY - minY;
        float camSize = (sizeX > sizeY ? sizeX : sizeY);
        camera.orthographicSize = camSize > minSize ? (camSize > maxSize ? maxSize : camSize) : minSize;
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

    void CalculateBounds() {
        minX = Mathf.Infinity;
        maxX = -Mathf.Infinity;
        minY = Mathf.Infinity;
        maxY = -Mathf.Infinity;

        Vector3 body1 = GameController.instance.body1.transform.position;
        if (body1.x < minX) minX = body1.x;
        if (body1.x > maxX) maxX = body1.x;
        if (body1.y < minY) minY = body1.y;
        if (body1.y > maxY) maxY = body1.y;

        Vector3 body2 = GameController.instance.body2.transform.position;
        if (body2.x < minX) minX = body2.x;
        if (body2.x > maxX) maxX = body2.x;
        if (body2.y < minY) minY = body2.y;
        if (body2.y > maxY) maxY = body2.y;
    }
}
