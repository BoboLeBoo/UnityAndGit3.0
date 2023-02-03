using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0;
    [SerializeField] private Text melonsTxt;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CollectableItem")
        {
            Destroy(other.gameObject);
            melons ++;
            melonsTxt.text = "Melons  " + melons;
        }
    }

}
