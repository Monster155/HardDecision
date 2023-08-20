using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int moneyInStackAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (moneyInStackAmount is 0 or < 0)
            {
                return;
            }
            MoneyManager.Instance.AddMoney(moneyInStackAmount);
            Destroy(gameObject);
        }
    }
}
