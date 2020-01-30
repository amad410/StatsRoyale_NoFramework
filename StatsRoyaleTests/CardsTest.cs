using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StatsRoyaleTests
{
    [TestClass]
    public class CardsTest
    {
        public IWebDriver _driver = null;

        [TestMethod]
        public void Assert_IceSpiritCard_IsOnCardPage()
        {
            //Navigate to Cards Page
            var cardMenu = _driver.FindElement(By.CssSelector("a[href='/cards']"));
            cardMenu.Click();

            var card = _driver.FindElement(By.CssSelector("a[href='https://statsroyale.com/card/Ice+Spirit']"));
            //Verify Ice Spirit Card Shows Up

            Assert.IsTrue(card.Displayed,"The Ice Spirit Card is not displayed!");
        }
        [TestMethod]
        public void Assert_IceSpiritCardDetailStats_AreCorrect()
        {
            //Navigate to Cards Page
            var cardMenu = _driver.FindElement(By.CssSelector("a[href='/cards']"));
            cardMenu.Click();
            var card = _driver.FindElement(By.CssSelector("a[href='https://statsroyale.com/card/Ice+Spirit']"));

            card.Click();
            
            var cardRarityText = _driver.FindElement(By.CssSelector("div[class='card__rarity']")).Text.Split(',');

            Assert.AreEqual(cardRarityText[0], "Troop");
            Assert.AreEqual(cardRarityText[1], " Arena 8");


        }


        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://statsroyale.com/");
            _driver.Manage().Window.Maximize();
           

        }
        [TestCleanup]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
