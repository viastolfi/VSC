﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClassesVSC
{
    public class ArmePassive:Arme
    {
    public ArmePassive(string nom, string desc = "N/A", string image = "N/A", byte niveau = 1, Amelioration amelioration=null)
            : base(nom, desc, image, niveau) 
        {
            Amelioration = amelioration;
        }
        Amelioration Amelioration { get; set; }
        public void AffichAmelioration()
        {
            Console.WriteLine("Amelioration : " + this.Amelioration.Nom);
        }
    }
}
