using UnityEngine;

public class FruitTree : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fruit[] fruits = GetComponentsInChildren<Fruit>();

            foreach (Fruit fruit in fruits)
            {
                Rigidbody rb = fruit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }
        }
    }
}
