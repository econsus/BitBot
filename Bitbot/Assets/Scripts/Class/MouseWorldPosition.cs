using UnityEngine;

public class MouseWorldPosition
{
    public static Vector3 getMouseWorldPos(float z)
    {
        Vector3 foo = calcWorldPos(Input.mousePosition, Camera.main);
        foo.z = z;
        return foo;
    }

    public static Vector3 calcWorldPos(Vector3 screenPos, Camera worldCam)
    {
        Vector3 worldPos = worldCam.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}

