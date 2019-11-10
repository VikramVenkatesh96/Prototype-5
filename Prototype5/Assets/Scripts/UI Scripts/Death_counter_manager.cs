using UnityEngine;
using UnityEngine.UI;

public class Death_counter_manager : MonoBehaviour
{
    public float Fill_amount;
    public float Fill_decreamentor;
    public float Fill_incrementor;

    public Image Death_bar_outline_image;
    public Image Death_bar_filler_image;
    public Text Death_counter_filled_text;

    void Start()
    {
        Death_bar_filler_image.fillAmount = 0.0f;

        Fill_amount = 0.1f;
        Fill_incrementor = 0.1f;
        Fill_decreamentor = -0.1f;

        Death_counter_filled_text.gameObject.SetActive(false);
    }

    void Update()
    {
        Death_count_manager_script();

        All_degug_here();
    }

    //inputs for temporary usage
    void Death_count_manager_script()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Death_bar_filler_image.fillAmount = Fill_amount + Fill_incrementor;
            Fill_amount = Death_bar_filler_image.fillAmount;
        }

        else if (Input.GetKeyDown(KeyCode.J))
        {
            Death_bar_filler_image.fillAmount = Fill_amount + Fill_decreamentor;
            Fill_amount = Death_bar_filler_image.fillAmount;
        }
    }

    void All_degug_here()
    {
        //Debug.Log(Death_bar_filler_image.fillAmount);
    }
}
