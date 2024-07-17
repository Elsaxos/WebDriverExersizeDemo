using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace Working_with_Web_Tables
{
    public class WebTablesTests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void WorkingWithTableElements()
        {
            //locate the table
            IWebElement productstable = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/div/div[2]/table"));

            ReadOnlyCollection<IWebElement> tableRows =
                 productstable.FindElements(By.XPath("//tbody//tr"));

            string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";

            if (File.Exists(path))
            {
                File.Delete(path);

            }

            foreach (IWebElement row in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableData = row.FindElements
                    (By.XPath(".//td"));

                foreach (var tData in tableData) 
                {
                  string data = tData.Text;
                    string[] productInfo = data.Split("\n");
                    File.AppendAllText(path, productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n");

                    Assert.IsTrue(File.Exists(path));
                    Assert.IsTrue(new FileInfo(path).Exists);
                
                }
            }
        }
    }
}