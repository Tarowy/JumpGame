using UnityEngine;
using UnityEngine.UI;

namespace Players
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public float maxHealth;

        public Image health;
        public Text healthText;
    
        public void ChangeHealthBar(float currentHealth)
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            health.fillAmount = currentHealth / maxHealth;
            healthText.text = currentHealth + "/" + maxHealth;
        }
    }
}
