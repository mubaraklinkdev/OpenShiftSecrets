using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace OpenShiftSecrets.Controllers
{
    [ApiController]
    [Route("Secrets")]
    public class SecretsController : Controller
    {
        private readonly IConfiguration iconfiguration;
        public SecretsController(IConfiguration configuration)
        {
            this.iconfiguration = configuration;
        }

        [HttpGet("Secret")]
        public string Get()
        {
            return "Alive";
        }

        /// <summary>
        /// folder=/etc
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
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
                string str = $"Dir : {folder} {Environment.NewLine} -------------- {Environment.NewLine}";

                foreach (FileInfo file in Files)                
                    str =  $" {str} {Environment.NewLine} {file.FullName}";

                return str;
            }
            catch (Exception ex)
            {
                return ex.ToString();           
            }

        }

        /// <summary>
        /// key=/etc/secret-volume/username
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        [HttpGet("ReadEnv")]
        public string ReadEnv(string env = "name")
        {
            try
            {
                return iconfiguration[env];
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
