
using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using Test.Drivers;

namespace Test.Hooks
{
    public class LoginHooks : QsTester
    {

        public LoginHooks(IWebDriver Driver) : base(Driver)
        {
            WebDriver = Driver;
        }
        public IWebDriver WebDriver { get; }

        readonly By Tienda = By.Id("nava");
        readonly By Sing = By.Id("signin2");
        readonly By Username = By.Id("sign-username");
        readonly By Password = By.Id("sign-password");
        readonly By BtnRegistro = By.CssSelector("#signInModal > div > div > div.modal-footer > button.btn.btn-primary");
        readonly By BtnSesion = By.Id("login2");
        readonly By UserLogin = By.Id("loginusername");
        readonly By PassLogin = By.Id("loginpassword");
        readonly By BtnSing = By.CssSelector("#logInModal > div > div > div.modal-footer > button.btn.btn-primary");
        readonly By Producto = By.CssSelector("#tbodyid > div:nth-child(8) > div > div > h4 > a");
        readonly By BtnAgrega = By.CssSelector("#tbodyid > div.row > div > a");
        readonly By Cerrar = By.CssSelector("#logout2");

        public void OpenPortal()
        {
            this.Visit(QSTestConstantes.URLSERVER);
            this.Sleep(100);
        }


        public void Prinpal()
        {
            ExpectedCondition(Tienda);
            this.Sleep(60);
        }

        public void SingUp()
        {
            this.Sleep(60);
            this.ExpectedCondition(Sing);
            this.click(Sing);
            this.Sleep(60);
        }

        public void Registro()
        {
            this.Sleep(1000);
            this.ExpectedCondition(Username);
            this.type("M1rand4535e", Username);
            this.ExpectedCondition(Password);
            this.type("M1r4nd40434g", Password);
            this.Sleep(60);
            this.ExpectedCondition(BtnRegistro);
            this.click(BtnRegistro);
            this.Sleep(500);
            Assert.That(Driver.SwitchTo().Alert().Text, Is.EqualTo("Sign up successful."));
            Driver.SwitchTo().Alert().Accept();


        }

        public void LogIn()
        {
            this.Sleep(300);
            this.ExpectedCondition(BtnSesion);
            this.click(BtnSesion);
            this.ExpectedCondition(UserLogin);
            this.Sleep(300);
            this.type("M1rand4000000", UserLogin);
            this.ExpectedCondition(PassLogin);
            this.Sleep(300);
            this.type("M1r4nd40000", PassLogin);
            this.ExpectedCondition(BtnSing);
            this.click(BtnSing);
            this.Sleep(200);
        }

        public void AgregaCarrito()
        {
            this.Sleep(600);
            this.ExpectedCondition(Producto);
            this.click(Producto);
            this.Sleep(200);
            this.ExpectedCondition(BtnAgrega);
            this.Sleep(200);
            this.click(BtnAgrega);

        }

        public void Verifica()
        {
            this.Sleep(200);
            Assert.That(Driver.SwitchTo().Alert().Text, Is.EqualTo("Product added."));
            Driver.SwitchTo().Alert().Accept();
        }

        public void CerrarSesion()
        {
            this.Sleep(200);
            this.ExpectedCondition(Cerrar);
            this.click(Cerrar);
        }

    }
}
