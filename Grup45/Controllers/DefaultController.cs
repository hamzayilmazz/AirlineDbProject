using Grup45.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Grup45.Controllers
{
    public class DefaultController : Controller
    {

        // GET: Default
        public async System.Threading.Tasks.Task<ActionResult> Liste()
        {
            List<Customer> cList = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:1337/All");
            if (response.IsSuccessStatusCode)
            {
                cList = await response.Content.ReadAsAsync<List<Customer>>();
            }
           
            return View(cList);
        }

        // GET: Default
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<Customer> cList = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:1337/All");
            if (response.IsSuccessStatusCode)
            {
                cList = await response.Content.ReadAsAsync<List<Customer>>();
            }
            List<Home> aList = null;
            HttpClient client1 = new HttpClient();
            HttpResponseMessage response1 = await client1.GetAsync("http://localhost:1337/Home");
            if (response.IsSuccessStatusCode)
            {
                aList = await response1.Content.ReadAsAsync<List<Home>>();
            }
            aList[0].CustomerList = cList;
            return View(aList[0]);
        }

        // GET: Default/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(string id)
        {
            List<Customer> cus = null;
            HttpClient client1 = new HttpClient();
            HttpResponseMessage response = await client1.GetAsync("http://localhost:1337/Customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                cus = await response.Content.ReadAsAsync<List<Customer>>();
            }
            return View(cus[0]);
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(Customer c)
        {
            
            try
            {
                Customer temp = c;

                string json = JsonConvert.SerializeObject(c);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost:1337/Add/";
                var client = new HttpClient();

                var response = await client.PostAsync(url, data);


                client.Dispose();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        
        public async System.Threading.Tasks.Task<ActionResult> Edit(string id)
        {
            List<Customer> cus = null;
            HttpClient client1 = new HttpClient();
            HttpResponseMessage response = await client1.GetAsync("http://localhost:1337/Customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                cus = await response.Content.ReadAsAsync<List<Customer>>();
            }
            return View(cus[0]);
        }

        // POST: Default/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(Customer c, string id)
        {
            try
            {
                Customer temp = c;
                // HttpClient client = new HttpClient();
                string json = JsonConvert.SerializeObject(c);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost:1337/Edit/" + id;
                var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = await response.Content.ReadAsStringAsync();
                client.Dispose();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Delete(string id)
        {
            var url = "http://localhost:1337/Delete/" + id;
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            string result = await response.Content.ReadAsStringAsync();
            client.Dispose();
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Default/Delete/5
        
    }
}
