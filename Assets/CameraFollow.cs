
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        transform.position = target.position+ new Vector3(0,0,-10);
    }
}
