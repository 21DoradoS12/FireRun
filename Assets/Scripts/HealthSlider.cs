using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider HPslider;
    [SerializeField] private Vector3 shift;
    public Vector3 TargetPosition;
    public void Start()
    {
        TargetPosition = this.transform.position;
        this.HPslider.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        HPslider.transform.position = Camera.main.WorldToViewportPoint(TargetPosition + shift);
    }
    public void SetHealthValue(int CurrentHealth, int MaxHealth)
    {
        Debug.Log(gameObject.transform.parent.gameObject.name);
        if (CurrentHealth < MaxHealth)
        {
            this.HPslider.gameObject.SetActive(true);
        }
        this.HPslider.value = CurrentHealth;
        this.HPslider.maxValue = MaxHealth;
        if (CurrentHealth == 0)
        {
            this.HPslider.gameObject.SetActive(false);
        }
    }
    /*
    public void SetUphpBar(Canvas canvas, Camera camera)
    {
        HPslider.transform.SetParent(canvas.transform);
    }
    */
}
