using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIJuego : MonoBehaviour
{

    //Variables 
    private UIDocument juegoUI;
    private Button regresar;

    void OnEnable()
    {
        //Encontrar botones y elementos
        juegoUI = GetComponent<UIDocument>();
        var root = juegoUI.rootVisualElement;

        regresar = root.Q<Button>("RegresarMenuPrincipal");
        
        regresar.RegisterCallback<ClickEvent>(RegresarTitulo);

    }
    
    private void RegresarTitulo(ClickEvent evt)
    {
        SceneManager.LoadScene("MenuPrincipal");
        
    }

}
