using UnityEngine;
using System.Collections.Generic;

public class Keyring : MonoBehaviour
{
	public AudioClip getKeySound;
	public float keyPickUpDistance = 5f;
	
	private List<Key> _keys = new List<Key>();
	
	public void AddKey(Key key)
	{
		_keys.Add(key);
		
		if (getKeySound != null)
		{
			GetComponent<AudioSource>().PlayOneShot(getKeySound);
		}
	}
	
	
	public bool HasKey(Key key)
	{
		return _keys.Contains(key);
	}
	
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
        	if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, keyPickUpDistance)) 
			{
				Key key = hit.transform.GetComponent<Key>();
				if (key != null)
				{
					AddKey(key);
					key.gameObject.SetActive(false);
				}
			}
		}
	}
}
