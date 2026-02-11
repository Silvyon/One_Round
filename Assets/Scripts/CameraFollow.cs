using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    void LateUpdate()
    {
        this.transform.position = followObject.GetComponent<Transform>().position + Vector3.forward * 10;
    }
}
