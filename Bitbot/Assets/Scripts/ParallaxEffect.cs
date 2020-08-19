using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("Parallax Multiplier")]
    [SerializeField] private float parallaxMultiplier = 0f;

    private float startPos;

    void Start()
    {
        startPos = this.transform.position.x;
    }
    void FixedUpdate()
    {
        float dist = Camera.main.transform.position.x * parallaxMultiplier;
        float x = startPos + dist;
        Vector3 tPos = new Vector3(x, this.transform.position.y, this.transform.position.z);

        //this.transform.position = Vector3.Lerp(this.transform.position, tPos, 8f);
        this.transform.position = tPos;
    }
}
