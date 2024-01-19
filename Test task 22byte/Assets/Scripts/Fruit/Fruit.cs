using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _fruitVariants;

    [HideInInspector]
    public int _fruitNumberCurrent;

    public void Init(int fruitNumber)
    {
        if (fruitNumber != 0)
        {
            _fruitVariants[fruitNumber - 1].SetActive(true);
            _fruitNumberCurrent = fruitNumber;
        }
        else
        {
            _fruitVariants[fruitNumber].transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GlobalEventManager.SendOnGetFruit(_fruitNumberCurrent);
            transform.gameObject.SetActive(false);
        }
    }
}
