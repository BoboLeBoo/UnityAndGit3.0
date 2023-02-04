using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0;
    [SerializeField] private Text melonsTxt;

    private Animator anim;
    [SerializeField] AudioSource collectionSound;
  
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CollectableItem")
        {
            anim = other.GetComponent<Animator>();
            anim.SetBool("IsCollected", true);
            collectionSound.Play();
            melons ++;
            melonsTxt.text = "Melons " + melons + "/14";
            Destroy(other.gameObject, 0.3f);
        }
    }


}
