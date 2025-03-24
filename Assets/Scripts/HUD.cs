using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image StaminaBar;

    public GameObject[] vidas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            GameManager.instance.Stamina -= GameManager.instance.AttackCost;
            if (GameManager.instance.Stamina < 0) GameManager.instance.Stamina = 0;
            StaminaBar.fillAmount = GameManager.instance.Stamina / GameManager.instance.MaxStamina;

            if (GameManager.instance.recharge != null) StopCoroutine(GameManager.instance.recharge);
            GameManager.instance.recharge = StartCoroutine(RechargeStamina());
        }
    }
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(3f);
        while (GameManager.instance.Stamina < GameManager.instance.MaxStamina)
        {
            GameManager.instance.Stamina += GameManager.instance.ChargeRate / 20f;
            if (GameManager.instance.Stamina > GameManager.instance.MaxStamina) GameManager.instance.Stamina = GameManager.instance.MaxStamina;
            StaminaBar.fillAmount = GameManager.instance.Stamina / GameManager.instance.MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }
}
