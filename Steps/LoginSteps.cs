using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Test.Hooks;

namespace Test.Steps
{
    [Binding]
    public class LoginSteps
    {
        LoginHooks loginHooks = null;

        [Given(@"El actor ingresa a la URL del portal")]
        public void GivenElActorIngresaALaURLDelPortal()
        {
            IWebDriver webDriver = new ChromeDriver();
            loginHooks = new LoginHooks(webDriver);
            loginHooks.MaxWindow();
            loginHooks.OpenPortal();
            loginHooks.Prinpal();
            loginHooks.SingUp();
           
        }
        
        [Given(@"El actor da de alta un usuario")]
        public void GivenElActorDaDeAltaUnUsuario()
        {
            loginHooks.Registro();
        }
        
        [Given(@"El actor inicia y cierra sesíon con el usuario creado")]
        public void GivenElActorIniciaYCierraSesionConElUsuarioCreado()
        {
            loginHooks.LogIn();
        }
        
        [Given(@"El actor agrega una laptop al carrito de compras")]
        public void GivenElActorAgregaUnaLaptopAlCarritoDeCompras()
        {
            loginHooks.AgregaCarrito();
        }
        
        [Then(@"EL actor valida que el producto se agrego correctamente")]
        public void ThenELActorValidaQueElProductoSeAgregoCorrectamente()
        {
            loginHooks.Verifica();
            loginHooks.CerrarSesion();
        }
    }
}
