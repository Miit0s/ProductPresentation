using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 100f; //Force unity a sérialiser une variable privée
    bool dragging = false; //Permet de savoir si le joueur est en train de d'attraper le model
    Rigidbody rb; //Va contenir le rigidbody qui permet d'appliquer de la physique à des objet

    Quaternion originalRotation; //Va contenir la ortation de départ
    [SerializeField] float duration = 1f; //Durée du retour

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //Si on détecte le relachement du clic droit
        {
            dragging = false; //On remet le booléen en false
        }
    }

    private void FixedUpdate() //Fonction appeler à chaque frame avec un taux fixe
    {
        if (dragging) //Si le joueur essaye de bouger l'objet
        {
            rb.isKinematic = false; //Débloque la rotation du téléphone

            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime; //X va prendre le mouvement de gauche à droite de la souris et va le multiplier 
                                                                                        //par la vitesse de rotation et par le temps pour pouvoir avoir la vitesse
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime; //Même chose mais sur l'axe y (haut/bas)

            rb.AddTorque(Vector3.down * x); //Va permttre de faire tourner l'objet sur l'axe des ordonné
            rb.AddTorque(Vector3.right * y); //Va permttre de faire tourner l'objet sur l'axe des abscisse
            
        }
    }

    private void OnMouseDrag() //Fonction appeler quand un joueur clique sur un colider et garde la clic droit enfoncé
    {
        dragging = true; //On passe le booléen en true
    }

    public void OriginalPosition()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, duration); //Va faire retoruner l'objet à sa position de départ
        rb.isKinematic = true; //Bloque la rotation du téléphone
    }
}
