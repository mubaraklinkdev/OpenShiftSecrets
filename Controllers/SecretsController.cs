using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenShiftSecrets.Controllers
{
    [ApiController]
    [Route("Secrets")]
    public class SecretsController : Controller
    {
        [HttpGet("Secret")]
        public string Get()
        {
            return "Hi";
        }

        [HttpGet("Dir")]
        public string Dir(string folder = @"ConfigMap/Secret")
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(folder);

                FileInfo[] Files = d.GetFiles();
                string str = "";

                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                }
                return str;
            }
            catch (Exception ex)
            {
                return ex.ToString();
           
            }

        }


    }
}
