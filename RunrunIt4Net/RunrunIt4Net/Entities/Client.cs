using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using RunrunIt4Net.Attributes;

namespace RunrunIt4Net.Entities
{
    public class Client
    {
        [GetColumn]
        public int Id { get; set; }

        [GetColumn]
        [PostColumn]
        [RequiredColumn]
        public string  Name { get; set; }
        
        [GetColumn]
        [PostColumn]
        [RequiredColumn]
        public bool Is_Visible { get; set; }
        
        [GetColumn]
        public IEnumerable<int> Project_Ids { get; set; }

        [PostColumn]
        public int Budgeted_Hours_Month { get; set; }

        [PostColumn]
        public decimal Budgeted_Cost_Month { get; set; }
    }
}