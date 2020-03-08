
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Transform pfHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        //healthBar.Setup(healthSystem);
        healthSystem.Damage(10);
        Debug.Log("Health: " + healthSystem.GetHealthPercent());
        healthSystem.Heal(100);
        Debug.Log("Health: " + healthSystem.GetHealth());
        healthSystem.Damage(90);
    }

}
