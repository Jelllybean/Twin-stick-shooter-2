using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private float _fillAmount = 1f;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private Image _fillBar;

    [HideInInspector] public float MaxValue = 100f;
    public float Value
    {
        set
        {
            _fillAmount = map(value, 0, MaxValue, 0, 1);
        }
    }

    private void Update()
    {
        _fillBar.fillAmount = _fillAmount;
    }

    private float map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    /*
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    [SerializeField]
    private float lerpspeed;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = map(value, 0, MaxValue, 0, 1);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        handleHealtBar();
    }

    // deze fuctie gaat de healthbar updaten
    private void handleHealtBar()
    {
        if (fillAmount != content.fillAmount)
        {
            float autism = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpspeed);
            if(autism >= 1)
            {
                autism = 1;
            }
            content.fillAmount = autism;
        }
    }

    private float map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
    */
}

