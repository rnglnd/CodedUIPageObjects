using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUIPageObjects.UITests.PageObjects
{
    public partial class MainObjects
    {
        private BrowserWindow _bw;

        public MainObjects(BrowserWindow bw)
        {
            _bw = bw;
        }

        public bool IsCurrentPageValid()
        {
            var loginButton = GetLoginButton();
            loginButton.Find();

            return loginButton.DisplayText == "Log in";
        }

        public MainObjects LoginUser(string username, string password)
        {
            HtmlEdit txtUserName = new HtmlEdit(_bw);
            txtUserName.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "Email");
            Keyboard.SendKeys(txtUserName, username);

            HtmlEdit txtPassWord = new HtmlEdit(_bw);
            txtPassWord.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "Password");
            Keyboard.SendKeys(txtPassWord, password);

            var btn = GetLoginButton();
            Mouse.Click(btn);

            return this;
        }

        public MainObjects CheckLogin(string username)
        {
            HtmlDiv searchscopeButton = new HtmlDiv(_bw);
            searchscopeButton.SearchProperties.Add(HtmlDiv.PropertyNames.Class, "navbar-right");
            searchscopeButton.Find();

            HtmlControl text = new HtmlControl(searchscopeButton);
            text.SearchProperties.Add(HtmlTextArea.PropertyNames.InnerText, "Hello " + username + "!");
            text.Find();

            return this;
        }

        public MainObjects Logout()
        {
            HtmlDiv searchscopeButton = new HtmlDiv(_bw);
            searchscopeButton.SearchProperties.Add(HtmlDiv.PropertyNames.Class, "navbar-right");
            searchscopeButton.Find();

            HtmlHyperlink btn = new HtmlHyperlink(searchscopeButton);
            btn.SearchProperties.Add(HtmlTextArea.PropertyNames.Id, "helloLink");
            Mouse.Click(btn);

            HtmlHyperlink btn2 = new HtmlHyperlink(searchscopeButton);
            btn2.SearchProperties.Add(HtmlHyperlink.PropertyNames.Id, "logoutLink");
            Mouse.Click(btn2);

            return this;
        }

        public bool CheckInvalidLogin()
        {
            var loginMessage = CheckValidationMessage();
            loginMessage.Find();

            return loginMessage.InnerText == "Invalid login attempt.";
        }

        private HtmlControl CheckValidationMessage()
        {
            HtmlDiv searchscopeButton = new HtmlDiv(_bw);
            searchscopeButton.SearchProperties.Add(HtmlDiv.PropertyNames.Class, "validation-summary-errors text-danger");
            searchscopeButton.Find();

            HtmlControl text = new HtmlControl(searchscopeButton);
            text.SearchProperties.Add(HtmlTextArea.PropertyNames.InnerText, "Invalid login attempt.");

            return text;
        }


        private HtmlInputButton GetLoginButton()
        {
            HtmlDiv searchscopeButton = new HtmlDiv(_bw);
            searchscopeButton.SearchProperties.Add(HtmlDiv.PropertyNames.Id, "login-button");
            searchscopeButton.Find();

            HtmlInputButton btn = new HtmlInputButton(searchscopeButton);
            btn.SearchProperties.Add(HtmlButton.PropertyNames.Type, "submit");
            btn.SearchProperties.Add(HtmlButton.PropertyNames.ValueAttribute, "Log in");

            return btn;
        }
    }
}
