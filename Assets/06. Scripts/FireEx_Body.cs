using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEx_Body : MonoBehaviour
{
    public OVRGrabbable thisObject;
    public MeshCollider mesh;       // 핸들

    // Update is called once per frame
    void Update()
    {
        if (thisObject.isGrabbed)
                mesh.enabled = true;
        else
                mesh.enabled = false;
    }
}
