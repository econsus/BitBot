using UnityEngine;

public class MousePosition
{
    public static Vector3 getMouseWorldPos(float z, Camera cam)
    {
        Vector3 foo = calcWorldPos(Input.mousePosition, cam);
        foo.z = z;
        return foo;
    }

    private static Vector3 calcWorldPos(Vector3 screenPos, Camera worldCam)
    {
        Vector3 worldPos = worldCam.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}

