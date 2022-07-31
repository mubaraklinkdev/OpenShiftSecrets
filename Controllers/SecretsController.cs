using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public string Dir(string folder = @"test")
        {
            if (folder is "test")
            {
                folder = @"";
            }

            try
            {
                DirectoryInfo d = new DirectoryInfo(folder);

                FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories);
                string str = "";

                foreach (FileInfo file in Files)
                {
                    str =  str + Environment.NewLine  + file.FullName;
                }

                //var json = JsonSerializer.Serialize(Files);

                return str;
            }
            catch (Exception ex)
            {
                return ex.ToString();
           
            }

        }

        [HttpGet("Read")]
        public string Read(string key = "username")
        {
            try
            {
                return System.IO.File.ReadAllText(key);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            

        }


    }
}
