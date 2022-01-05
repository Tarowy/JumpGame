using UnityEngine;
using UnityEngine.UI;

namespace Players
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [HideInInspector]
        public float maxHealth;

        public Image health;
        public Text healthText;
    
        public void ChangeHealthBar(float currentHealth)
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            // Debug.Log("currentHealth:"+currentHealth);
            health.fillAmount = currentHealth / maxHealth;
            healthText.text = currentHealth + "/" + maxHealth;
        }
    }
}
