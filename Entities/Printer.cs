//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Api.Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Printer
    {
        public int Id_printer { get; set; }
        public string Serial_number_printer { get; set; }
        public string Type_oborudovaniya { get; set; }
        public string Nazvanie { get; set; }
        public string Type_printera { get; set; }
        public string Cvetnost_pechati { get; set; }
        public int Max_speed_pechati { get; set; }
        public string Max_format_pechati { get; set; }
        public int Item_Id { get; set; }
        [JsonIgnore]
        public virtual Sklad Sklad { get; set; }
    }
}