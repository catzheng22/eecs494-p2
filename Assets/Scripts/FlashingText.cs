using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingText : MonoBehaviour
{
    public float flashRate = 0.7f;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Flash());   
    }

    private IEnumerator Flash() {
        while (true) {
            yield return new WaitForSeconds(flashRate);
            text.enabled = !text.enabled;
        }
    }
}
