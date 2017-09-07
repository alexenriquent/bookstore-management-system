using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BookStoreManagementSystem {
    /// <summary>
    /// Summary description for DataStorage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataStorage : System.Web.Services.WebService {

        [WebMethod(Description = "This method reads data from the text file")]
        public string[] Read() {
            string[] books = new string[0];
            try {
                books = File.ReadAllLines(HttpRuntime.AppDomainAppPath + "books.txt");
            } catch(IOException e) {
                throw e;
            }
            return books;
        }

        [WebMethod(Description = "This method writes data to file")]
        public void Write(string data) {
            try {
                File.WriteAllText(HttpRuntime.AppDomainAppPath + "books.txt", data);
            } catch(IOException e) {
                throw e;
            }
        }
    }
}
