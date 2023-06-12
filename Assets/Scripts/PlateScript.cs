using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Height = 0;
    public bool ProductAddNow = false;
    public List< GameObject> burger;
    public List<int> Ids;


    public void BurgerEnd()
    {
        burger.ForEach(b => Destroy(b));
        burger.Clear();

        Ids.Clear();

        Height= 0;


    }
    
}
