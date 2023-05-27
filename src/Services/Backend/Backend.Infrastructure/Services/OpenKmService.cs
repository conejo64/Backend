using Backend.Domain.Interfaces.Services;
using com.openkm.sdk4csharp.impl;
using com.openkm.sdk4csharp;
using com.openkm.sdk4csharp.bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities;


namespace backend.Infrastructure.Services
{
    public class OpenKmService : IOpenKmService
    {
        public bool SendOpenKm(List<string> documents, List<string> documentsNames)
        {
            var host = "http://localhost:8080/openkm";
            var username = "usropenkm";
            var password = "Temporal0penkm1";
            var ws = OKMWebservicesFactory.newInstance(host);
            try
            {
                ws.login(username, password);
                FileStream fileStream = new("E:\\logo.png", FileMode.Open);
                long nodeClass = 0;
                ws.document.createDocument("4b88cbe9-e73d-45fc-bac0-35e0d6e59e43", "logo.png", fileStream, nodeClass);
                fileStream.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
