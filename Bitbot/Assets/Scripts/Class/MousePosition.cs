using UnityEngine;

public class MousePosition
{
    public static Vector3 GetMouseWorldPos(float z, Camera cam)
    {
        Vector3 foo = CalcWorldPos(Input.mousePosition, cam);
        foo.z = z;
        return foo;
    }

    private static Vector3 CalcWorldPos(Vector3 screenPos, Camera worldCam)
    {
        Vector3 worldPos = worldCam.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}

