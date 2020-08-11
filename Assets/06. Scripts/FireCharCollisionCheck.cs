using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCharCollisionCheck : MonoBehaviour
{
    public PlayerMGR playerMGR = null;
    public Transform playerTr = null;
    public AudioClip sound = null;

    private Transform fireTr = null;
    private int fireDamage = 3;
    private float current_dist, damage_dist;

    void Start()
    {
        fireTr = this.gameObject.transform;
        damage_dist = 2f;
    }

    void Update()
    {
        current_dist = Vector3.Distance(playerTr.position, fireTr.position);

        if (current_dist <= damage_dist)        // 불에 가까워지면
        {
            if (playerMGR.getHP() > 0)
            {
                // 화재와 캐릭터 충돌
                playerMGR.causeDamage(fireDamage);
            }
        }
    }

    public void reduceDamageDist()
    {
        damage_dist -= 0.2f;        // 불 크기가 작아질수록 데미지 입는 범위도 감소
    }
}
