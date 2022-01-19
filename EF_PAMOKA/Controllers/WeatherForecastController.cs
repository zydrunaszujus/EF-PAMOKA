using EF_PAMOKA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EF_PAMOKA.Controllers

{
    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly PavyzdinisDbContext _dbContext; public WeatherForecastController(PavyzdinisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/daiktai")]
        public List<Daiktas> VisiDaiktai()
        {
            return _dbContext.Daiktai.Where(x => x.Pavadinimas != "kazkas").ToList();
        }

        [HttpGet]
        [Route("/automobiliai")]
        [Authorize]//prieisim tik prisijungus
        public List<Automobilis> VisiAutomobiliai()
        {
            return _dbContext.Automobiliai.Where(x => x.Marke != "kazkas").ToList();
        }

        [HttpGet]
        [Route("/daiktai/{daiktoId}")]
        public ActionResult<Daiktas?> GautiDaikta(int daiktoId)
        {
            var daiktas= _dbContext.Daiktai.Where(x => x.Id == daiktoId).FirstOrDefault();
            if (daiktas==null)
            {
                return NotFound();//jei naudojam NotFound, reikia rasyti ActionRezult<ka norima grazint is tikruju>
            }
            return daiktas;
        }

        [HttpGet]
        [Route("/savininkai")]
        public List<Savininkas> VisiSavininkai()
        {
            return _dbContext.Savininkai.Where(x => x.Vardas != "kazkas").ToList();
        }

        [HttpGet]
        [Route("/savinikai/{savininkoId}")]
        public ActionResult<Savininkas> GautiSavininka(int savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();
            if (savininkas==null)
            {
                return NotFound();   
            }
            return savininkas;
        }

        [HttpGet]
        [Route("/pridetiDaikta/{savininkoId}")]
        public void PridetiDaikta(int? savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();
            _dbContext.Daiktai.Add(new Daiktas() { Pavadinimas = "Telefonas", SavininkoId = savininkas != null ? savininkas.Id : 1 });
            _dbContext.SaveChanges();
        }

        [HttpGet]
        [Route("/pridetiSavininka")]
        public void PridetiSavininka()
        {
            _dbContext.Savininkai.Add(new Savininkas() { Vardas = "Jonas" });
            _dbContext.SaveChanges();
        }
   
        [HttpDelete]
        [Route("/daiktas/{daiktoId:int?}")]
        public void IstirntiDaikta(int? daiktoId)
        {
            var daiktas =_dbContext.Daiktai.Where(x => x.Id == daiktoId).FirstOrDefault();
            if (daiktas!=null)
            {
                _dbContext.Daiktai.Remove(daiktas);
                _dbContext.SaveChanges();
            }
        }
    
        [HttpDelete]
        [Route("/savininkas/{savininkoId}")]
        public void IstrintiSavininka(int savininkoId)
        {
            var savininkas = _dbContext.Savininkai.Where(x => x.Id == savininkoId).FirstOrDefault();
            if (savininkas!=null)
            {
                _dbContext.Savininkai.Remove(savininkas);//pasalinam
                _dbContext.SaveChanges();//issaugom duomenu bazeje pakeitimus
            }
        }

        [HttpPost]
        [Route("/pridetiDaikta")]               //klase     tipas
        public void PridetiDaiktaPOST([FromBody] DaiktaiJson daiktas)//kad nesidubliuotu dvi klases Daiktai,
                                                                     //sukureme klase DaiktaiJason
        {
            var savininkas = _dbContext.Savininkai
                .Where(x => x.Id == daiktas.SavininkoId)
                .FirstOrDefault();
            _dbContext.Daiktai.Add(new Daiktas() 
            {//i klase Daiktas dedame naujus Daiktai
                Pavadinimas = daiktas.Pavadinimas,
                SavininkoId = daiktas.SavininkoId

            });
            _dbContext.SaveChanges();
        }

    }
}


  