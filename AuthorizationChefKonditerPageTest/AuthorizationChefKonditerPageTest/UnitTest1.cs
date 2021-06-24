using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AuthorizationChefKonditerPageTest
{
    public class Tests{
        private IWebDriver driver;
        private readonly By authorizButton = By.XPath("//a[@class='auth_popup']");
        private readonly By logInpField = By.XPath("//input[@class='hk_form_input']");
        private readonly By passInpField = By.XPath("//input[@name='password']");
        private readonly By submitButton = By.XPath("//input[@class='btn_submit']");
        private readonly By userEnter = By.XPath("//a[text()='Инфо и заказы']");

        private const string loginName = "lopata.ad@gmail.com";
        private const string password = "123124125kv";
        private const string expectEnter = "Инфо и заказы";
        [SetUp]
        public void setup(){
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://chef-konditer.com.ua/");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void test1(){
            var signIn = driver.FindElement(authorizButton);
                signIn.Click();
            var loginIn = driver.FindElement(logInpField);
                loginIn.SendKeys(loginName);
            var passIn = driver.FindElement(passInpField);
                passIn.SendKeys(password);
            var submitIn = driver.FindElement(submitButton);
                submitIn.Click();
            var actualEnter = driver.FindElement(userEnter).Text;
            Assert.AreEqual(expectEnter, actualEnter, "Authorization failed");
        }
        [TearDown]
        public void tearDown(){
            driver.Quit();
        }
    }
}
