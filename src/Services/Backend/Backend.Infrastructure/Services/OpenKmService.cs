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
using System.Threading;


namespace backend.Infrastructure.Services
{
    public class OpenKmService : IOpenKmService
    {
        public bool SendOpenKm(List<string> documents, List<string> documentsNames)
        {
            var host = "http://localhost:8080/openkm";
            var username = "usropenkm";
            var password = "Temporal0penkm1";
            var filePath = "/home/openkm/temp";
            var ws = OKMWebservicesFactory.newInstance(host);
            try
            {
                for (int i = 0; i < documents!.Count; i++)
                {
                    Guid code;
                    code = Guid.NewGuid();
                    var documentSplit = documents.ElementAt(i).Split(',');
                    var contentTypeSplit = documentSplit[0].Split(':');
                    var document = new DocumentEntity
                    {
                        Document64 = documentSplit[1],
                        Document64Name = documentsNames!.ElementAt(i),
                        ContextType = contentTypeSplit[1].Split(';')[0],
                    };
                    ws.login(username, password);
                    byte[] documentBuffer = Convert.FromBase64String(document.Document64);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    fileStream.Write(documentBuffer, 0, documentBuffer.Length);
                    long nodeClass = 0;

                    ws.document.createDocument(code.ToString(), document.Document64Name, fileStream, nodeClass);
                    fileStream.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
