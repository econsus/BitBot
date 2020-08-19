using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [Header("Constraint")]
    [SerializeField] private float y = 6f;
    [SerializeField] private float x = 3f;

    private Transform player;
    private AnimationScript anim;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        anim = GameObject.Find("Player").GetComponentInChildren<AnimationScript>();
    }
    void Update()
    {
        moveTarget();
        handleAnimation();
    }

    private void moveTarget()
    {
        this.transform.position = calcTargetPos(x, y);
    }
    private Vector3 calcTargetPos(float x, float y)
    {
        Vector3 mPos = MouseWorldPosition.getMouseWorldPos(6f);
        Vector3 tPos = (player.position + mPos) / 2f;

        tPos.x = Mathf.Clamp(tPos.x, -x + player.position.x, x + player.position.x);
        tPos.y = Mathf.Clamp(tPos.y, -y + player.position.y, y + player.position.y);

        return tPos;
    }
    private void handleAnimation()
    {
        if(this.transform.localPosition.y > -2.1f)
        {
            anim.setLookingUp(true);
        }
        else
        {
            anim.setLookingUp(false);
        }
        Debug.Log("POS: "+ this.transform.position);
        Debug.Log("LOPOS: " + this.transform.localPosition);
    }
}
