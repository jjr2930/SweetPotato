using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UI_SweetPotato : MonoBehaviour
{
    [SerializeField]
    float burnQuality;

    [Range(0,1)]
    [SerializeField]
    float burnSpeed = 10.0f;

    [SerializeField]
    Image img = null;

    public float BurnQuality
    {
        get { return burnQuality; }
    }

    private void Awake()
    {
        burnQuality = 0.0f;
    }

    public void Update()
    {
        Color nextColor = img.color;
        float amount = burnSpeed * Time.deltaTime;
        nextColor.r -= amount;
        nextColor.g -= amount;
        nextColor.b -= amount;

        img.color = nextColor;
        burnQuality += amount;
        burnQuality = Mathf.Clamp01(burnQuality);
    }
}
