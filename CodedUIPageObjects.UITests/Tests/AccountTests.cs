using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using CodedUIPageObjects.UITests.PageObjects;

namespace CodedUIPageObjects.UITests.Tests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class AccountTests
    {
        string siteUrl = "http://localhost/Account/Login";
        string username = "admin@admin.com";
        string password = "Admin@123456";

        [TestMethod]
        public void LoginUserTest()
        {
            var browserWindow = BrowserWindow.Launch(new Uri(siteUrl));

            MainObjects accountLogin = new MainObjects(browserWindow);
            Assert.IsTrue(
                accountLogin.LoginUser(username, password)
                .CheckLogin(username)
                .Logout()
                .IsCurrentPageValid());
        }

        [TestMethod]
        public void LoginInvalidUserTest()
        {
            var browserWindow = BrowserWindow.Launch(new Uri(siteUrl));

            MainObjects accountLogin = new MainObjects(browserWindow);
            Assert.IsTrue(
                accountLogin.LoginUser("u@user.com", "User")
                .CheckInvalidLogin());
        }


    }
}
