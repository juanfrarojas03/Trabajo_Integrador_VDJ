using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoBoss : MonoBehaviour
{
    public Animator ani;
    public Enemigo_Script boss;
    public int melee;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            melee = Random.Range(0, 3);
            switch (melee)
            {
                case 0:

                    ani.SetFloat("skills", 0);
                    boss.hit_select = 0;
                    break;
                case 1:

                    ani.SetFloat("skills", 0.5f);
                    boss.hit_select = 1;
                    break;
                case 2:

                    ani.SetFloat("skills", 1);
                    boss.hit_select = 2;
                    break;
            }

            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            boss.atacando = true;
            GetComponent<CapsuleCollider>().enabled = true;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
