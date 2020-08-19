using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private CinemachineCameraOffset offset;
    void Start()
    {
        offset = GetComponent<CinemachineCameraOffset>();
    }

    void Update()
    {
        panCamera();
    }

    private void panCamera()
    {
        Vector3 mPos = MouseWorldPosition.getMouseWorldPos(0f);
        float tmp1 = mPos.x;
        if(mPos.x < Screen.width && mPos.y < Screen.height)
        {
            offset.m_Offset = mPos.normalized * 10f;
        }
    }
}
