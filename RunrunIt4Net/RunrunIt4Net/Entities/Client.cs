using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RunrunIt4Net.Attributes;

namespace RunrunIt4Net.Entities
{
    public class Client
    {
        [GetColumn]
        [PostColumn]
        public int Id { get; set; }
        [PostColumn]
        public string  Name { get; set; }
        [GetColumn]
        public bool Is_Visible { get; set; }
        public IEnumerable<int> Project_Ids { get; set; }

        //Criar atributo para filtra-los na hora do Post e do Get na API;
    }
}