using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDrivenTestingWithSelenium
{
	[TestClass]
	public class TestExamples
	{
		[TestMethod]
		public void TestCase01()
		{
			using (var reader = new StreamReader(@"../../data/myData.csv"))

			{
				IWebDriver driver;
				driver = new ChromeDriver(@"C:\Program Files\");
				driver.Manage().Window.Maximize();

				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
					var searchContent = values[0];

					driver.Navigate().GoToUrl("http://www.google.com/ncr");
					driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(100));
					driver.FindElement(By.Id("lst-ib")).SendKeys(searchContent);

					Actions action = new Actions(driver);
					action.MoveByOffset(-500, 0).Click().Perform();
					driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(100));
					driver.FindElement(By.XPath("//*[@id='tsf']/DIV[2]/DIV[3]/CENTER/INPUT[1]")).Click();

					driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(100));
					string actualContent = driver.FindElement(By.Id("lst-ib")).GetAttribute("value");
					//Debug.WriteLine(actualContent);	
					Assert.IsTrue(actualContent.Equals(searchContent, StringComparison.InvariantCultureIgnoreCase));
					Debug.WriteLine("Test data =" + searchContent + ": Passed");
					
				}
				driver.Quit();
			}

		}

		[TestMethod]
		public void TestCase02()
		{
			Debug.WriteLine("This is Test Case02");

		}

		[TestMethod]
		public void TestCase03()
		{
			Debug.WriteLine("This is Test Case03");

		}
	}
}
