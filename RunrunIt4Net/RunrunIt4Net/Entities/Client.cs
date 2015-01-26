using System;
using System.Collections.Generic;
using RunrunIt4Net.Attribute;

namespace RunrunIt4Net.Entities
{
    public class Client
    {
        [GetColumn]
        public int Id { get; set; }
        public string  Name { get; set; }
        public bool Is_Visible { get; set; }
        public IEnumerable<int> Project_Ids { get; set; }

        Criar atributo para filtra-los na hora do Post e do Get na API;
    }
}