using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollisionCheck : MonoBehaviour
{
    public GameObject fire = null;
    private int collision_count = 0;
    private float reduction_size = 0.1f;

    private void OnParticleCollision(GameObject other)
    {
        if(collision_count <= 100)
        {
            collision_count++;
            Debug.Log("소화기 분말과 화재 충돌");
            if (collision_count % 10 == 0)
                ReductionScale();
        }
        else
            Destroy(fire);
    }

    private void ReductionScale()
    {
        fire.transform.localScale -= new Vector3(reduction_size, reduction_size, reduction_size);
    }
}
