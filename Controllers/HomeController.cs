using Animales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Animales.Controllers
{
    public class HomeController : Controller
    { 
      ANIMALESEntities cnx; 
    public HomeController()
       {
        cnx = new ANIMALESEntities();
       }
     
    public ActionResult Formulario()
        {
            return View();
        }
    public ActionResult Listado()
        {
            /*cnx.Database.Connection.Open();

            List<ANIMAL> animales = cnx.ANIMAL.ToList();
            cnx.Database.Connection.Close();*/
            return View("Listado", ListadoAnimales());
        }
    public ActionResult Guardar(string dio, string nombre, string sexo, string raza, string edad, string tipo, string rebaño)
        {
            ANIMAL animalito = new ANIMAL()
            {
                DIO = dio,
                Nombre = nombre,
                Sexo = sexo,
                Raza = raza,
                Edad = edad,
                Tipo = tipo,
                Rebaño = rebaño
            };

            cnx.ANIMAL.Add(animalito);
            cnx.SaveChanges();
            return View("Listado", ListadoAnimales());


        }
    private List<Animales.Models.ANIMAL> ListadoAnimales()
        {
            cnx.Database.Connection.Open();
            List<Animales.Models.ANIMAL> vaca = cnx.ANIMAL.ToList();

            cnx.Database.Connection.Close();

            return vaca;
        }

        
    public ActionResult Ficha(string dio)
        {
            
            return View(BuscarAnimal(dio));
        }

        public ANIMAL BuscarAnimal(string dio)
        {
            ANIMAL nueva = new ANIMAL();
            foreach (ANIMAL animalito in cnx.ANIMAL.ToList())
            {
                if (animalito.DIO.Equals(dio))
                {
                    nueva = animalito;
                }
            }
            return nueva;
        }
        /*public ActionResult Visualizar(string dio)
        {
            ANIMAL nueva = BuscarAnimal(dio);

            if (nueva != null)
            {
                return View("Ficha", nueva);
            }
            return View("Listado", cnx.ANIMAL.ToList());
        }*/
        public ActionResult Ver(string dio)
        {
            return View("Ficha", null);
        }
    }
    
}