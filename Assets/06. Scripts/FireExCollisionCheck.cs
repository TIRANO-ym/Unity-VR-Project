using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExCollisionCheck : MonoBehaviour
{
    public GameObject fire = null;
    public FireCharCollisionCheck fireCharCollisionCheck = null;

    private FireMGR fireMGR;
    private int collision_count = 0;
    private float reduction_size = 0.1f;

    private void Start()
    {
        fireMGR = GameObject.Find("FireManager").GetComponent<FireMGR>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(fire != null)
        {
            if (collision_count <= 100)
            {
                collision_count++;              // 소화기 분말과 화재 충돌
                if (collision_count % 10 == 0)
                    reduceScale();
            }
            else
            {
                Destroy(fire);
                fire = null;
                fireMGR.reduceFire();
            }
        }
    }

    private void reduceScale()
    {
        fire.transform.localScale -= new Vector3(reduction_size, reduction_size, reduction_size);
        fireCharCollisionCheck.reduceDamageDist();
    }
}
