using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Bll.RegraNegocio;
using WebAppMVC.Entity;

namespace WebAppMVC.UI.Controllers
{
    public class TimeController : Controller
    {

        #region "Get"

        [HttpGet]
        public ActionResult Index()
        {
            regranegocio_Time regranegocio_Time = null;

            try
            {
                regranegocio_Time = new regranegocio_Time();

                var lstTimes = regranegocio_Time.Pesquisar();

                ModelState.Clear();

                return View(lstTimes);
            }
            catch (Exception)
            {
                throw;
            }



        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View(new entity_Time());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            regranegocio_Time regranegocio_Time = null;
            try
            {
                regranegocio_Time = new regranegocio_Time();
                var time = regranegocio_Time.Pesquisar().Find(t => t.TimeID == id);
                return View(time);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            regranegocio_Time regranegocio_Time = null;
            entity_Time objTime = null;

            try
            {
                regranegocio_Time = new regranegocio_Time();
                objTime = new entity_Time();

                objTime.TimeID = id;

                if (regranegocio_Time.Deletar(objTime))
                {
                    ViewBag.Mensagem = "Time Excluido com Sucesso.";

                }


                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

        #endregion

        #region "Post"

        [HttpPost]
        public ActionResult Create(entity_Time objTime)
        {
            regranegocio_Time regranegocio_Time = null;

            try
            {
                if (ModelState.IsValid)
                {
                    regranegocio_Time = new regranegocio_Time();


                    if (regranegocio_Time.Adicionar(objTime))
                    {
                        ViewBag.Mensagem = "Time Cadastrado com Sucesso.";
                    }

                }

                return View();
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Update(int id, entity_Time objTime)
        {
            regranegocio_Time regranegocio_Time = null;

            try
            {
                regranegocio_Time = new regranegocio_Time();

                regranegocio_Time.Atualizar(objTime);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Index");
            }
        }


        #endregion


    }
}