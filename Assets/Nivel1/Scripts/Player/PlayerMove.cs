using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField]
    private float velocidadMovimiento = 6f;

    public Vector2 entradaMovimiento;

    private Rigidbody2D rb;

    private SpriteRenderer sprite;

    public bool mirandoDerecha = true;

    public bool enSuelo = true;

    [Header("Sonidos")]
        [SerializeField] private AudioSource sonidoCaminar;
        [SerializeField] private AudioSource sonidoSaltar;
        [SerializeField] private AudioSource sonidoSaltoPared;
    

    [Header("Doble Salto")]
        [Header("Salto")][SerializeField] private float fuerzaSalto = 7f;
        [SerializeField] private int saltosMaximos = 2;
        private int numeroSaltos = 0;

    [Header("Salto Pared")]
        [SerializeField] private float fuerzaSaltoParedX = 6f;
        [SerializeField] private float fuerzaSaltoParedY = 7f;
        private bool enPared = false;
        private bool saltoParedRealizado = false;



    [SerializeField] private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!sprite)
            sprite = GetComponent<SpriteRenderer>();
    }

    public void Parar()
    {
        GetComponent<PlayerInput>().enabled = false;
    }

    public bool EnSuelo()
    {
        return enSuelo;
    }


    public void OnJump(InputValue valor)
    {
        
        if(enPared && !enSuelo && !saltoParedRealizado)
        {
            rb.linearVelocity  = new Vector2(-Mathf.Sign(transform.localScale.x) * fuerzaSaltoParedX, fuerzaSaltoParedY);
            if(!sonidoSaltoPared.isPlaying)    
                sonidoSaltoPared.Play();
            saltoParedRealizado = true;
            numeroSaltos = 1;
            return;
        }
        else if (enSuelo)
        {
            Saltar();
            if(!sonidoSaltar.isPlaying)    
                sonidoSaltar.Play();
            numeroSaltos = 1;
            animator.SetTrigger("Salto");
        }
        else if(numeroSaltos < saltosMaximos)
        {
            Saltar();
            if(!sonidoSaltar.isPlaying)    
                sonidoSaltar.Play();
            numeroSaltos++;
            animator.ResetTrigger("Salto");
            animator.SetTrigger("DobleSalto");
        }
         
    }

    private void Saltar()
    {
        Vector2 v =rb.linearVelocity ;
        v.y = 0f;
        rb.linearVelocity  = v;
        rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        if (!saltoParedRealizado && animator != null)
            animator.SetTrigger(numeroSaltos == 0 ? "Salto" : "DobleSalto");
    }


    public void OnMove(InputValue valor)
    {
        entradaMovimiento = valor.Get<Vector2>();

        if (entradaMovimiento.x > 0 && !mirandoDerecha)
            Girar(false);
        else if (entradaMovimiento.x < 0 && mirandoDerecha)
            Girar(true);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(entradaMovimiento.x * velocidadMovimiento, rb.linearVelocity .y);
    }


    // Update is called once per frame
    void Update()
    {
        if (enSuelo)
            numeroSaltos = 0;

        bool estaAndando = Mathf.Abs(entradaMovimiento.x) > 0.1 && enSuelo;

        if (estaAndando)
        {
            if (!sonidoCaminar.isPlaying)
            {
                sonidoCaminar.Play();
            }
        }
        else
        {
            if (sonidoCaminar.isPlaying)
            {
                sonidoCaminar.Stop();
            }
        }
    }


    private void Girar(bool aIzquierda)
    {
        mirandoDerecha = !mirandoDerecha;
        if (sprite)
            sprite.flipX = aIzquierda;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (other.gameObject.CompareTag("Pared"))
        {
            enPared = true;
            animator.SetBool("enPared", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
            numeroSaltos = 0;
            saltoParedRealizado = false;
        }

        if (other.gameObject.CompareTag("Pared"))
        {
            enPared = false;
            saltoParedRealizado = false;
            animator.SetBool("enPared", false);
        }
    }


}
