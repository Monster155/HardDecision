using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    
    [SerializeField] private int moneyAmount;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
        
        UpdateMoneyText();
    }

    public void AddMoney(int money)
    {
        moneyAmount += money;
        UpdateMoneyText();
    }

    public bool TrySpendMoney(int money)
    {
        if (money > moneyAmount)
        {
            return false;
        }

        moneyAmount -= money;
        UpdateMoneyText();
        return true;
    }

    public int GetCurrentMoney()
    {
        return moneyAmount;
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "$ " + moneyAmount.ToString();
    }
}
