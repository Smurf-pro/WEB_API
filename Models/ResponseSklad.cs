using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api.Entities;

namespace Web_Api.Models
{
    public class ResponseSklad
    {
        public ResponseSklad(Sklad sklad )
        {
            ID_item = sklad.ID_item;
            Invent_num = sklad.Invent_num;
            Ser_num = sklad.Ser_num;
            Type_oborudovaniya_ = sklad.Type_oborudovaniya_;
            Nazvanie_ob = sklad.Nazvanie_ob;
            Mesto_Hraneniya = sklad.Mesto_Hraneniya;
            Login = sklad.Login;
            Building = sklad.Building;
            Emp_Id = sklad.Emp_Id;
            //Image = sklad.Image.ToList().FirstOrDefault()?.ImageSource;
        }
        public int ID_item { get; set; }
        public string Invent_num { get; set; }
        public string Ser_num { get; set; }
        public string Type_oborudovaniya_ { get; set; }
        public string Nazvanie_ob { get; set; }
        public string Mesto_Hraneniya { get; set; }
        public string Login { get; set; }
        public string Building { get; set; }
        public int Emp_Id { get; set; }
    
}
}