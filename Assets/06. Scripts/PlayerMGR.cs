using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMGR : MonoBehaviour
{
    public GameObject display = null;
    public Material failImage = null;
    public OVRPlayerController playerController = null;
    public AudioSource speaker_short, speaker_long;
    public AudioClip sound_damage, sound_dead, sound_success;

    private int HP = 100;
    private bool isFinished = false;


    public int getHP()
    {
        return HP;
    }
    
    public void causeDamage(int damage)
    {
        if (!isFinished)
        {
            HP -= damage;
            Debug.Log(damage + " 데미지");
            if (HP <= 0)
            {
                showDisplay(false, failImage);
            }
            else if(HP <= 50)
            {
                if (!speaker_long.isPlaying)
                    speaker_long.Play();
            }

            if (!speaker_short.isPlaying)
                speaker_short.PlayOneShot(sound_damage);
        }
    }

    public void showDisplay(bool success, Material image)
    {
        isFinished = true;

        if(success)
        {
            speaker_long.Stop();
            speaker_short.PlayOneShot(sound_success, 0.4f);

            display.GetComponent<MeshRenderer>().material = image;
            display.SetActive(true);
        }
        else
        {
            speaker_long.Stop();
            speaker_short.PlayOneShot(sound_dead, 0.4f);

            playerController.EnableLinearMovement = false;

            display.GetComponent<MeshRenderer>().material = image;
            display.SetActive(true);
        }
    }
}
