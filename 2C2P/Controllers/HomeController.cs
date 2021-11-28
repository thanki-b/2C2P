﻿using _2C2P.Database;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace _2C2P.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index(List<Transaction> lisdata)
        {
            return View(lisdata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(HttpPostedFileBase upload, string btn)
        {
            try
            {
                if (btn == "Upload")
                {
                    if (upload == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }

                    else if(upload.ContentLength > 1000000)
                    {
                        ModelState.AddModelError("File", "File size is max 1 MB");
                    }

                    else if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();

                        using (CsvReader csvReader = new CsvReader(new StreamReader(stream), false))
                        {
                            csvTable.Load(csvReader);
                        }

                        return View("Index", GenerateSaveDataCSV(csvTable));
                    }
                    else if (upload.FileName.EndsWith(".xml"))
                    {
                        Stream stream = upload.InputStream;
                        XElement xmlRaw = XElement.Load(stream);
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(xmlRaw.ToString());

                        string data = JsonConvert.SerializeXmlNode(xmlDoc);

                        return View("Index", GenerateSaveDataXML(data));
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Unknown format");
                    }

                    return View("Index");
                }
                else
                {
                    return View("index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("File", e.Message);
                return View("Index");
            }                   
        }

        public List<Transaction> GenerateSaveDataCSV(DataTable csvTable)
        {
            List<Transaction> lisdata = new List<Transaction>();

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                DataRow dRow = csvTable.Rows[i];

                Transaction data = new Transaction();

                data.TransactionID = dRow["Column1"].ToString();
                data.Amount = Convert.ToDecimal(dRow["Column2"].ToString());
                data.CurrencyCode = dRow["Column3"].ToString();
                data.TransactionDate = DateTime.ParseExact(dRow["Column4"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                data.Status = dRow["Column5"].ToString();
                data.UploadDate = DateTime.Now;

                if (data.Status == "Approved")
                {
                    data.Status = "A";
                }
                else if (data.Status == "Failed")
                {
                    data.Status = "R";
                }
                else
                {
                    data.Status = "D";
                }

                lisdata.Add(data);
            }

            db.Transactions.AddRange(lisdata);
            db.SaveChanges();

            return (lisdata);
        }

        public List<Transaction> GenerateSaveDataXML(string jsonDat)
        {
            List<Transaction> lisdata = new List<Transaction>();

            JObject a = JObject.Parse(jsonDat);
            JToken b = JToken.Parse((a["Transactions"]).ToString());
            JToken c = JToken.Parse((b["Transaction"]).ToString());

            foreach (JObject d in c)
            {
                Transaction data = new Transaction();

                data.TransactionID = (d["@id"]).ToString();
                data.TransactionDate = Convert.ToDateTime((d["TransactionDate"]).ToString());
                data.Status = (d["Status"]).ToString();

                JObject e = JObject.Parse((d["PaymentDetails"]).ToString());

                data.Amount = Convert.ToDecimal((e["Amount"]).ToString());
                data.CurrencyCode = (e["CurrencyCode"]).ToString();

                if (data.Status == "Approved")
                {
                    data.Status = "A";
                }
                else if (data.Status == "Rejected")
                {
                    data.Status = "R";
                }
                else
                {
                    data.Status = "D";
                }

                lisdata.Add(data);
            };

            db.Transactions.AddRange(lisdata);
            db.SaveChanges();

            return lisdata;
        }
    }
}
