using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 100f; //Force unity a s�rialiser une variable priv�e
    bool dragging = false; //Permet de savoir si le joueur est en train de d'attraper le model
    Rigidbody rb; //Va contenir le rigidbody qui permet d'appliquer de la physique � des objet

    Quaternion originalRotation; //Va contenir la ortation de d�part
    [SerializeField] float duration = 1f; //Dur�e du retour

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //Si on d�tecte le relachement du clic droit
        {
            dragging = false; //On remet le bool�en en false
        }
    }

    private void FixedUpdate() //Fonction appeler � chaque frame avec un taux fixe
    {
        if (dragging) //Si le joueur essaye de bouger l'objet
        {
            rb.isKinematic = false; //D�bloque la rotation du t�l�phone

            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime; //X va prendre le mouvement de gauche � droite de la souris et va le multiplier 
                                                                                        //par la vitesse de rotation et par le temps pour pouvoir avoir la vitesse
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime; //M�me chose mais sur l'axe y (haut/bas)

            rb.AddTorque(Vector3.down * x); //Va permttre de faire tourner l'objet sur l'axe des ordonn�
            rb.AddTorque(Vector3.right * y); //Va permttre de faire tourner l'objet sur l'axe des abscisse
            
        }
    }

    private void OnMouseDrag() //Fonction appeler quand un joueur clique sur un colider et garde la clic droit enfonc�
    {
        dragging = true; //On passe le bool�en en true
    }

    public void OriginalPosition()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, duration); //Va faire retoruner l'objet � sa position de d�part
        rb.isKinematic = true; //Bloque la rotation du t�l�phone
    }
}
