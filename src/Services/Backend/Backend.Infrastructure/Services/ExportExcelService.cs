using Azure;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Services;
using Backend.Domain.SeedWork;
using Backend.Infrastructure;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infrastructure.Services
{
    public class ExportExcelService : IExportExcelService
    {
        public byte[]? GenerateExcel(ExportExcelModel model)
        {
            try
            {
                var db = new BackendDbContext();
                var query = db.CaseEntities.Where(x => x.Status != CatalogsStatus.Deleted);
                if(model.BrandId != null)
                query.Where(x => x.BrandId.Equals(model.BrandId));
                if (model.CaseStatusId != null)
                    query.Where(x => x.CaseStatusId.Equals(model.CaseStatusId));
                if (model.DepartmentId != null)
                    query.Where(x => x.DepartmentId.Equals(model.DepartmentId));
                if (model.InitialDate != null)
                    query.Where(x => x.ReceptionDate >= model.InitialDate);
                if (model.FinalDate != null)
                    query.Where(x => x.ReceptionDate <= model.FinalDate);
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Casos Secretaria");
                worksheet.Cell("A3").Value = "Fecha Recepción";
                worksheet.Cell("B3").Value = "Recibido Fisicamente";
                worksheet.Cell("C3").Value = "Nro Circular";
                worksheet.Cell("D3").Value = "Fecha Circular";
                worksheet.Cell("E3").Value = "Nro Referido SBS";
                worksheet.Cell("F3").Value = "Fecha Emisión";
                worksheet.Cell("G3").Value = "Origen";
                worksheet.Cell("H3").Value = "Dirigido a";
                worksheet.Cell("I3").Value = "Descripcion";
                worksheet.Cell("J3").Value = "Prioridad";
                worksheet.Cell("K3").Value = "Contesta Secretaria";
                worksheet.Cell("L3").Value = "Area Responde";
                worksheet.Cell("M3").Value = "Funcionario Asignado";
                worksheet.Cell("N3").Value = "Requiere mas Informacion";
                worksheet.Cell("O3").Value = "Area Funcionario Mas Informacion";
                worksheet.Cell("P3").Value = "Fecha Traslado";
                worksheet.Cell("Q3").Value = "Lugar Destino";
                worksheet.Cell("R3").Value = "Fecha Vencimiento";
                worksheet.Cell("S3").Value = "Plazo Respuesta";
                worksheet.Cell("T3").Value = "Nro Oficio Respuesta";
                worksheet.Cell("U3").Value = "Fecha Contestacion";
                worksheet.Cell("V3").Value = "Demora Responder";
                worksheet.Cell("W3").Value = "Funcionario Responde";
                worksheet.Cell("X3").Value = "Fecha Respuesta";
                worksheet.Cell("Y3").Value = "Estado Caso";
                worksheet.Cell("Z3").Value = "Fecha Acuse";
                worksheet.Cell("AA3").Value = "Demora Dias";
                worksheet.Cell("AB3").Value = "Nro Juicio";
                worksheet.Cell("AC3").Value = "Observacion";
                var Titulos = worksheet.Range("A1:AC1");
                Titulos.FirstRow().Merge();
                Titulos.LastRow().Merge();
                Titulos.FirstRow().Value = "REGISTROS CASOS SECRETARIA";
                Titulos.LastRow().Value = "FECHA: " + DateTime.Today.ToShortDateString();
                Titulos.Style.Font.Bold = true;
                Titulos.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                Titulos.Style.Font.FontSize = 18;
                var i = 3;
                foreach (var c in query)
                {
                    i++;
                    worksheet.Cell(string.Format("A{0}", i)).Value = c.ReceptionDate;
                    worksheet.Cell(string.Format("B{0}", i)).Value = c.PhysicallyReceived;
                    worksheet.Cell(string.Format("C{0}", i)).Value = c.RequirementNumber;
                    worksheet.Cell(string.Format("D{0}", i)).Value = c.IssueDate;
                    worksheet.Cell(string.Format("E{0}", i)).Value = c.SbsNumber;
                    worksheet.Cell(string.Format("F{0}", i)).Value = c.IssueDate;
                    worksheet.Cell(string.Format("G{0}", i)).Value = !string.IsNullOrEmpty(c.OriginDocument?.Description) ? c.OriginDocument.Description : string.Empty;
                    worksheet.Cell(string.Format("H{0}", i)).Value = !string.IsNullOrEmpty(c.Brand?.Description) ? c.Brand.Description : string.Empty;
                    worksheet.Cell(string.Format("I{0}", i)).Value = c.Description;
                    worksheet.Cell(string.Format("J{0}", i)).Value = "Normal";
                    worksheet.Cell(string.Format("K{0}", i)).Value = "";
                    worksheet.Cell(string.Format("L{0}", i)).Value = !string.IsNullOrEmpty(c.Department?.Description) ? c.Department.Description : string.Empty;
                    worksheet.Cell(string.Format("M{0}", i)).Value = c.User?.FullName;
                    worksheet.Cell(string.Format("N{0}", i)).Value = string.Empty;
                    worksheet.Cell(string.Format("O{0}", i)).Value = "N/A";
                    worksheet.Cell(string.Format("P{0}", i)).Value = c.TransferDate;
                    worksheet.Cell(string.Format("Q{0}", i)).Value = !string.IsNullOrEmpty(c.Province?.Description) ? c.Province.Description : string.Empty;
                    worksheet.Cell(string.Format("R{0}", i)).Value = c.Deadline;
                    worksheet.Cell(string.Format("S{0}", i)).Value = c.Deadline - c.ReceptionDate;
                    worksheet.Cell(string.Format("T{0}", i)).Value = c.RequirementNumber;
                    worksheet.Cell(string.Format("U{0}", i)).Value = c.ResponseDate;
                    worksheet.Cell(string.Format("V{0}", i)).Value = c.ResponseDate - c.ReceptionDate;
                    worksheet.Cell(string.Format("W{0}", i)).Value = c.User?.FullName;
                    worksheet.Cell(string.Format("X{0}", i)).Value = c.ReplyDate;
                    worksheet.Cell(string.Format("Y{0}", i)).Value = !string.IsNullOrEmpty(c.CaseStatus?.Description) ? c.CaseStatus.Description : string.Empty;
                    worksheet.Cell(string.Format("Z{0}", i)).Value = c.AcknowledgmentDate;
                    worksheet.Cell(string.Format("AA{0}", i)).Value = c.AcknowledgmentDate - c.ReceptionDate;
                    worksheet.Cell(string.Format("AB{0}", i)).Value = c.JudgmentNumber;
                    worksheet.Cell(string.Format("AC{0}", i)).Value = c.ObservationDepartment + " / " + c.ObservationExtension;
                }
                var Cabecera1 = worksheet.Range("A3:AC3");
                Cabecera1.Style.Font.Bold = true;
                Cabecera1.Style.Fill.BackgroundColor = XLColor.BeauBlue;
                Cabecera1.Cells().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Cabecera1.Columns().Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                var Tabla1 = worksheet.Range("A3:Z" + (i).ToString());
                Tabla1.Cells().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                Tabla1.Columns().Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                Tabla1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                worksheet.Columns().AdjustToContents();
                using var ms = new MemoryStream();
                workbook.SaveAs(ms);
                var buffer = ms.ToArray();
                return buffer;
            }
            catch {
                return null;
            }
        }
    }
}
