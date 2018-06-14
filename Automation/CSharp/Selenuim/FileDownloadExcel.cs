using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Globalization;       

namespace SukuAutp
{
    public class ChromeUse
    {


 public static IWebDriver Initialize()
        {
            var options = new ChromeOptions();
            //options.AddAdditionalCapability("ChromeOptions.page.settings.resourceTimeout", TimeSpan.FromMinutes(15));
            options.AddUserProfilePreference("myFiles.default_directory", @"D:\myFiles");
            IWebDriver wb = new ChromeDriver(@"D:\AutomationOfOrgsnxt\AutomationOfOrgsnxt\bin\Debug\", options,TimeSpan.FromMinutes(4));
            return wb;
        }

 public string EmpReport()
        {
            IWebDriver driver = Initialize();
            try
            {
                if (File.Exists(@"D:\myFiles\EmployeeReportRoles.xlsx"))
                {
                    File.Delete(@"D:\myFiles\EmployeeReportRoles.xlsx");
                }
                if (File.Exists(@"EmployeeReport.xlsx"))
                {
                    File.Delete(@"EmployeeReport.xlsx");
                }
                driver.Navigate().GoToUrl("http://Suku.com/Orgs/aspx/OrgsEmpReport.aspx?role=MyRole&level=top");
                IWebElement element = driver.FindElement(By.Id("cboOrgIN"));
                SelectByValue(element, "Roles");
                driver.FindElement(By.Id("btnProceed")).Click();
                driver.FindElement(By.Id("btnmyFiles1")).Click();
                for (int i = 0; i < 30; i++)
                {
                    if (File.Exists(@"D:\myFiles\EmployeeReport.xlsx"))
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
                File.Move(@"D:\myFiles\EmployeeReport.xlsx",@"D:\myFiles\EmployeeReportRoles.xlsx");
                return "Success";
            }
            catch(Exception ex)
            {
                using (StreamWriter str = new StreamWriter(@"D:\myFiles\Errors.txt",true))
                {
                    str.Write("Empreport" + ex.Message);
                }
                    return ex.Message;
            }
            finally
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
