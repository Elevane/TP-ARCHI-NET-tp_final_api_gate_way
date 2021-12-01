using Newtonsoft.Json;
using tp_final_api_gate_way.Configuration;

namespace tp_final_api_gate_way.Extensions
{
    public static class JsonExtension
    {
        private static string ACTUALPATH = Directory.GetCurrentDirectory();
        private static string PATH = "\\Configuration\\";
        private static string FILENAME = "Services-config";
        private static string EXTENSION = ".json";
        private static string ABSOLUTEPATH = ACTUALPATH + PATH + FILENAME + EXTENSION;


        /// <summary>
        ///  vérifie que le ficheir json est dans le bon format et existe
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void VerifyConfig()
        {
            // existe ?
            bool exist = File.Exists(ABSOLUTEPATH);
            if (!exist)
                throw new Exception("File doesn't exist of is placed in the wrong directory");

            // bonne arboresence
            using(StreamReader r = new StreamReader(ABSOLUTEPATH))
            {
                string json;
                try {  json = r.ReadToEnd(); } catch(Exception e) { throw new Exception("Can't read json file"); }
                Services services = new Services();
                try{  services = JsonConvert.DeserializeObject<Services>(json); }catch(Exception e) { throw new Exception($"Could Not parse Json file, service-config.json format is wrong : {e}"); }
                if (services.services.Count == 0)
                    Console.WriteLine("config file is empty");
            }

            
            
        }
        /// <summary>
        /// Retourne tous les services
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Services GetServices()
        {
            Services services = new Services();
            using (StreamReader r = new StreamReader(ABSOLUTEPATH))
            {
                string json;
                try { json = r.ReadToEnd(); } catch (Exception e) { throw new Exception("Can't read json file"); }
                
                try { services = JsonConvert.DeserializeObject<Services>(json); } catch (Exception e) { throw new Exception($"Could Not parse Json file, service-config.json format is wrong : {e}"); }
                if (services.services.Count == 0)
                    Console.WriteLine("config file is empty");
                return services;
            }
            return services;
        }



        /// <summary>
        /// Retourne tous les services
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Service GetService(string name)
        {
            Services services = new Services();
            using (StreamReader r = new StreamReader(ABSOLUTEPATH))
            {
                string json;
                try { json = r.ReadToEnd(); } catch (Exception e) { throw new Exception("Can't read json file"); }

                try { services = JsonConvert.DeserializeObject<Services>(json); } catch (Exception e) { throw new Exception($"Could Not parse Json file, service-config.json format is wrong : {e}"); }
                if (services.services.Count == 0)
                    Console.WriteLine("config file is empty");

                foreach(Service service in services.services)
                {
                    if (service.name == name)
                        return service;
                }
                return null;
            }
            return null;
        }



        //injection du manager
        public static void InjectJsonService(this IServiceCollection services)
        {
            services.AddScoped<JsonServiceManager>();
        }


    }

    /// <summary>
    /// Manager de services json
    /// </summary>
    public class JsonServiceManager
    {

        public Services GetServices()
        {
            return JsonExtension.GetServices();
        }
        public Service GetService(string name)
        {
            return JsonExtension.GetService(name);
        }

    }
}
