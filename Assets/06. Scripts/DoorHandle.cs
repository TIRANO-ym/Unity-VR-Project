using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public GameObject door;
    public OVRGrabbable thisHandle;
    public OVRGrabbable otherHandle;

    private OVRGrabbable[] handles = new OVRGrabbable[2];
    private Rigidbody rigid;
    private Vector3[] handles_position = new Vector3[2];
    private Vector3[] handles_scale = new Vector3[2];
    private Vector3 door_position;
    private AudioSource audio;

    private bool isOpen = false;
    private bool done = false;

    void Start()
    {
        audio = door.GetComponent<AudioSource>();
        rigid = thisHandle.GetComponent<Rigidbody>();

        handles[0] = thisHandle;
        handles[1] = otherHandle;

        for(int i = 0; i < 2; i++)
        {
            handles_position[i] = handles[i].transform.localPosition;
            handles_scale[i] = handles[i].transform.localScale;
        }

        door_position = door.transform.localPosition;
    }
    

    void Update()
    {
        if (thisHandle.isGrabbed)
        {
            if (!done)
            {
                execute();
                done = true;
            }
        }
        else
        {
            if (done)
            {
                done = false;
                rigid.useGravity = false;
                rigid.isKinematic = true;

                // 핸들 위치 조정
                for(int i = 0; i < 2; i++)
                {
                    handles[i].transform.SetParent(door.transform);
                    handles[i].transform.localRotation = Quaternion.identity;
                    handles[i].transform.localPosition = handles_position[i];
                    handles[i].transform.localScale = handles_scale[i];
                }
            }
        }

    }

    void execute()
    {
        if (isOpen)
        {
            isOpen = false;
            close();
        }
        else
        {
            isOpen = true;
            open();
        }
            
    }

    void close()
    {
        door.transform.localEulerAngles = new Vector3(0, 90, 0);
        door.transform.localPosition = new Vector3((float)(door_position.x + 0.41), 0, (float)(door_position.z - 0.43));
        door_position = door.transform.localPosition;
        audio.Play();
    }

    void open()
    {
        door.transform.localEulerAngles = new Vector3(0, 0, 0);
        door.transform.localPosition = new Vector3((float)(door_position.x - 0.41), 0, (float)(door_position.z + 0.43));
        door_position = door.transform.localPosition;
        audio.Play();
    }
}
