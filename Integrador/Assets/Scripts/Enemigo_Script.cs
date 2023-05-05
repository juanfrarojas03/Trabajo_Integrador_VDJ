using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo_Script : MonoBehaviour
{
    // Codigo Boss Final //
    public int rutina;
    public float cronometro;
    public float time_rutinas;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;
    public RangoBoss rango;
    public float speed;
    public GameObject[] hit;
    public int hit_select;



    // Ataque Salto //
    public float dist_salto;
    public bool direc_skill;
    public GameObject point;

    //---------------------//

    public int fase = 1;
    public float hp_min;
    public float hp_max;
    public Image barra;
    public bool muerto;


    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Boss()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < 15)
        {
            var lookPos = target.transform.position-transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(target.transform.position);

            if(Vector3.Distance(transform.position, target.transform.position)>1 && !atacando)
            {
                switch (rutina)
                {
                    case 0:
                        Debug.Log("Caso0");
                        //walk
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", true);
                        ani.SetBool("run", false);

                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward *speed *Time.deltaTime);
                        }

                        ani.SetBool("attack", false);

                        cronometro += 1 * Time.deltaTime;
                        if(cronometro > time_rutinas)
                        {
                            rutina = Random.Range(0,2);
                        }

                        break;
                    case 1:
                        //run
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        ani.SetBool("walk", false);
                        ani.SetBool("run", true);

                        if (transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed*2 * Time.deltaTime);
                        }

                        ani.SetBool("attack", false);

                        break;
                    case 2:
                        //jump

                        if(fase == 2)
                        {
                            dist_salto += 1 * Time.deltaTime;
                            ani.SetBool("walk", false);
                            ani.SetBool("run", false);
                            ani.SetBool("attack", true);
                            ani.SetFloat("skills", 1);
                            hit_select = 3;
                            rango.GetComponent<CapsuleCollider>().enabled = false;

                            if (direc_skill)
                            {
                                if (dist_salto < 1f)
                                {
                                    transform.rotation =Quaternion.RotateTowards(transform.rotation,rotation, 2);
                                }

                                transform.Translate(Vector3.forward *8*Time.deltaTime);
                            }
                        }
                        else
                        {
                            rutina = 0;
                            cronometro = 0;
                        }


                        break;
                        
                }
            }
        }
    }

    public void Final_Ani()
    {
        rutina = 0;
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent <CapsuleCollider>().enabled = true;

        dist_salto = 0;
        direc_skill = false;
    }

    public void Direction_Attack_Start()
    {
        direc_skill = true;
    }
    public void Direction_Attack_Final()
    {
        direc_skill = false;
    }

    //Melee

    public void ColliderWeaponTrue()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = false;
    }

    public void Vivo()
    {
        if (hp_min < 500)
        {
            fase = 2;
            time_rutinas = 1;
        }

        Comportamiento_Boss();

    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = hp_min / hp_max;
        if (hp_min > 0)
        {
            Vivo();
            Comportamiento_Boss();
        }
        else
        {
            if (!muerto)
            {
                ani.SetTrigger("dead");
                muerto = true;
            }
        }
    }
}
