using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


{
    public class ApiJsonHelper<EntityVM>
    {
        public static EntityVM GetEntity(string method)// sonucu tek nesne gelen
        {
            string jsonEntity = HttpService<EntityVM>.Get(method).Result;
            return JsonConvert.DeserializeObject<EntityVM>(jsonEntity);
        }

        public static List<EntityVM> GetEntityList(string method)// sonucu liste gelen
        {
            string jsonEntity = HttpService<List<EntityVM>>.Get(method).Result;
            return JsonConvert.DeserializeObject<List<EntityVM>>(jsonEntity);
        }

        public static void PostEntity(string method,EntityVM entityVM)//tek nesne post işlemi isteğe bağlı void döner isterseniz ihtiyacınıza göre dönüşü değiştirebilirsiniz.
        {
            string jsonEntity = HttpService<EntityVM>.Post(method, entityVM).Result;           
        }
    }
}
