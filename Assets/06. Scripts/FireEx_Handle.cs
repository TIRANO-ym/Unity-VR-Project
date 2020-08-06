using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEx_Handle : MonoBehaviour
{
    public GameObject parent;
    public OVRGrabbable thisObject;
    public ParticleSystem particle;
    
    private Rigidbody rigid;
    private Vector3 position;

    private int durability;
    private bool isSetted = true;
    
    void Start()
    {
        durability = 1000;     // 내구도 설정
        rigid = thisObject.GetComponent<Rigidbody>();
        //position = new Vector3((float)-0.12, (float)0.233, 0);
        position = thisObject.transform.localPosition;
    }

    void Update()
    {
        if (thisObject.isGrabbed)        // 핸들을 잡으면
        {
            isSetted = false;       // 위치 변경됨
            if (durability <= 0)            // 내구도가 없으면
            {
                print("This Fire EX is empty.");
                if(particle.isPlaying)
                    particle.Stop();
            }
            else /*if (!particle.isPlaying)    // Play()는 한번만 해야하니까.
                */particle.Play();                // 내구도가 남아있으면 분말 분사
            
            durability--;                   // 작동 중엔 내구도 감소(약 10초 사용 가능?)
        }
        else
        {
            if (!isSetted)
            {
                isSetted = true;
                
                rigid.useGravity = false;   // 그랩 이후 자동으로 생기는 중력 제거
                rigid.isKinematic = true;   // 그랩 이후 자동으로 꺼지는 운동성 켜기

                // Grab을 하고 나면 계층에서 빠져나오기 때문에 다시 부모 밑으로 넣고 위치와 각도 조정
                thisObject.transform.SetParent(parent.transform);
                thisObject.transform.localPosition = position;
                thisObject.transform.localRotation = Quaternion.identity;

                particle.Stop();                // 핸들을 떼면 분말 분사를 멈춘다
            }
        }
    }
}
