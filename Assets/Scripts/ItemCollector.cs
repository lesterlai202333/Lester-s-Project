using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ItemCollector : MonoBehaviour
{
    private int kiwi = 0;
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] private AudioSource soundeffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kiwi"))
            {
            soundeffect.Play();
            Destroy(collision.gameObject);
            kiwi++;
            score.text = "Score:" + kiwi;
        }

    }
}
