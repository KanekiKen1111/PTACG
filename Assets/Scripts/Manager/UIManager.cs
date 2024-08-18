using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image shieldBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private TextMeshProUGUI currentShieldTMP;

    [Header("Weapon")]
    [SerializeField] private TextMeshProUGUI currentAmmoTMP;

    private float playerCurrentHealth;
    private float playerMaxHealth;
    public float playerMaxShield;
    public float playerCurrentShield;

    private int playerCurrentAmmo;
    private int playerMaxAmmo;

    private void Update()
    {
        InternalUpdate();
    }

    public void UpdateHealth(float currentHealth, float maxHealth, float currentShield, float maxShield)
    {
        playerCurrentHealth = currentHealth;
        playerMaxHealth = maxHealth;
        playerCurrentShield = currentShield;
        playerMaxShield = maxShield;
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        playerCurrentAmmo = currentAmmo;
        playerMaxAmmo = maxAmmo;
    }

    // Getter methods for shield values
    public float GetCurrentShield() => playerCurrentShield;
    public float GetMaxShield() => playerMaxShield;

    private void InternalUpdate()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
        currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();

        shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, playerCurrentShield / playerMaxShield, 10f * Time.deltaTime);
        currentShieldTMP.text = playerCurrentShield.ToString() + "/" + playerMaxShield.ToString();

        // Update Ammo
        currentAmmoTMP.text = playerCurrentAmmo + " / " + playerMaxAmmo;
    }
}
