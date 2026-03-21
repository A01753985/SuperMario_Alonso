using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class MenuController : MonoBehaviour
{
    
    //Variables de botones y elementos
    private UIDocument menuPrincipal;
    private Button jugar;
    private Button ayuda;
    private Button creditos;
    private Button salir;
    private Button salirAyuda;
    private Button salirCreditos;
    private ScrollView creditosScroll;

    private Image mario;
    private Image estrella;
    
    //Contenedores
    private VisualElement menu;
    private VisualElement botones;
    private VisualElement ayudaElement;
    private VisualElement creditosElement;
    
    //Booleano para saber si esta abierta la pantalla de créditos
    private bool enCreditos;
    



    void OnEnable()
    {

        enCreditos = false;
        
        //Encontrar botones y elementos
        menuPrincipal = GetComponent<UIDocument>();
        var root = menuPrincipal.rootVisualElement;
        
        jugar = root.Q<Button>("Jugar");
        ayuda = root.Q<Button>("Ayuda");
        creditos = root.Q<Button>("Creditos");
        salir = root.Q<Button>("Salir");
        salirAyuda = root.Q<Button>("SalirAyuda");
        salirCreditos = root.Q<Button>("SalirCreditos");
        creditosScroll = root.Q<ScrollView>("CreditosScroll");
        mario = root.Q<Image>("ImagenMario");
        estrella = root.Q<Image>("ImagenEstrella");
        
        menu = root.Q<VisualElement>("Menu");
        ayudaElement = root.Q<VisualElement>("AyudaElement");
        botones = root.Q<VisualElement>("Botones");
        creditosElement = root.Q<VisualElement>("CreditosElement");

        // Callbacks
        jugar.RegisterCallback<ClickEvent>(AbrirJuego);
        ayuda.RegisterCallback<ClickEvent>(AbrirAyuda);
        creditos.RegisterCallback<ClickEvent>(AbrirCreditos);
        salir.RegisterCallback<ClickEvent>(Cerrar);
        salirAyuda.RegisterCallback<ClickEvent>(CerrarAyuda);
        salirCreditos.RegisterCallback<ClickEvent>(CerrarCreditos);
        
    }

    private void AbrirJuego(ClickEvent evt)
    {
        SceneManager.LoadScene("Juego");
    }
    
    private void AbrirAyuda(ClickEvent evt)
    {
        botones.style.display = DisplayStyle.None;
        ayudaElement.style.display = DisplayStyle.Flex;
    }
    
    private void Cerrar(ClickEvent evt)
    {
        Debug.Log("Cerrando Juego...");
        Application.Quit();
    }

    private void CerrarAyuda(ClickEvent evt)
    {
        ayudaElement.style.display = DisplayStyle.None;
        botones.style.display = DisplayStyle.Flex;
        
    }

    
    private void AbrirCreditos(ClickEvent evt)
    {
        menu.style.display = DisplayStyle.None;
        creditosElement.style.display = DisplayStyle.Flex;
        enCreditos = true;
    }
    
    
    private void CerrarCreditos(ClickEvent evt)
    {
        creditosElement.style.display = DisplayStyle.None;
        menu.style.display = DisplayStyle.Flex;
        enCreditos = false;
    }

    void OnDisable()
    {
        jugar.UnregisterCallback<ClickEvent>(AbrirJuego);
        ayuda.UnregisterCallback<ClickEvent>(AbrirAyuda);
        creditos.UnregisterCallback<ClickEvent>(AbrirCreditos);
        salirCreditos.UnregisterCallback<ClickEvent>(CerrarCreditos);
        salir.UnregisterCallback<ClickEvent>(Cerrar);
    }

    void Update()
    {
        //Código para scroll en los créditos
        if (enCreditos)
        {
            
        Vector2 scroll = creditosScroll.scrollOffset;
        scroll.y += 70f * Time.deltaTime;

        //Scrollear hasta pasar la altura del texto
        float height = creditosScroll.contentContainer[0].layout.height;
        if (scroll.y >= height)
        {
            //Regresar al inicio del primer texto cuando se pase completamente
            scroll.y -= height;
        }

        //Aplicar scroll
        creditosScroll.scrollOffset = scroll;
        }
        
        
        //Código para animar imágenes
        //Rotar estrella
        float rotacion = estrella.style.rotate.value.angle.value;
        estrella.style.rotate = new Rotate(new Angle(rotacion + (100f * Time.deltaTime)));
        
        //Mario voltear
        float flip = Mathf.Cos(Time.time * 10);
        mario.style.scale = new Scale(new Vector2(flip, 1f));    

        }


}
