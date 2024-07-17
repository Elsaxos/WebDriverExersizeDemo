using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace HandlingForminputs
{
    public class HandlingForminputsTests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


        [Test]
        public void HandlingFormInputs()
        {
            // click in my account button
            driver.FindElement(By.XPath("//*[@id=\"tdb3\"]/span[2]")).Click();
            // click continue button
            driver.FindElement(By.LinkText("Continue")).Click();
            // click male radio button
            driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[2]/table/tbody/tr[1]/td[2]/input[1]")).Click();
            // fill value in first name field
            driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[2]/table/tbody/tr[2]/td[2]/input")).SendKeys("Kosta");
            // fill value in last name field
            driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[2]/table/tbody/tr[3]/td[2]/input")).SendKeys("Stefanov");
            // fill value in date of birth field
            driver.FindElement(By.Id("dob")).SendKeys("05/21/1970");

            // build random email address
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);
            string email = "kosta" + randomNumber.ToString() + "@gmail.com";

            // fill email field
            driver.FindElement(By.Name("email_address")).SendKeys(email);
            // fill company field
            driver.FindElement(By.Name("company")).SendKeys("Arcadia-Service LTD");
            // fill street address field
            driver.FindElement(By.Name("street_address")).SendKeys("Pelican 8");
            // fill post code field
            driver.FindElement(By.Name("postcode")).SendKeys("8130");
            // fill city field
            driver.FindElement(By.Name("city")).SendKeys("Sofia");
            // fill state field
            driver.FindElement(By.Name("state")).SendKeys("Sofia");
            // select from country dropdown
            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");
            // fill phone number field
            driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[5]/table/tbody/tr[1]/td[2]/input")).SendKeys("+359123456789");
            // click newsletter checkbox
            driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[5]/table/tbody/tr[3]/td[2]/input")).Click();

            // fill password field
            string password = "vFFDT6";
            driver.FindElement(By.Name("password")).SendKeys(password);
            // fill password confirm field
            driver.FindElement(By.Name("confirmation")).SendKeys(password);

            // click continue button
            driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span[2]")).Click();

            // assert message for success
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/h1")).Text, "Your Account Has Been Created!");

            // click logoff button
            driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span")).Click();

            // click continue button
            driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span[2]")).Click();

            Console.WriteLine("User Created Successfully");
        }
    }
}

