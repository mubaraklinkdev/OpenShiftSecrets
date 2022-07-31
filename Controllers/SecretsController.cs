using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenShiftSecrets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController : Controller
    {
        [HttpGet(Name = "Secret")]
        public string Get()
        {
            return "Hi";
        }

        [HttpGet(Name = "Secret")]
        public string Dir(string folder = @"ConfigMap/Secret")
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(folder);

                FileInfo[] Files = d.GetFiles("*.txt");
                string str = "";

                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                }
                return str;
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
           
            }

        }


    }
}
