using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prospeccion.Repositorios.Interfaces;
using System.Data;

namespace Prospeccion.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcelController : Controller
    {
        private readonly IGestionRepository _repository;
        
        public ExcelController(IGestionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("ExportarSimple")]
        public async Task<IActionResult> ExportarSimpleAsync()
        {
            var filtro = String.Empty;
            var coleccion = await _repository.ListGestionInfoAsync();

            DataTable table = new DataTable();

            table.Columns.Add("ID");
            table.Columns.Add("GESTOR");
            table.Columns.Add("NOMBRE");
            table.Columns.Add("ACTIVIDAD");
            table.Columns.Add("RESULTADO");
            table.Columns.Add("FECHA");
            table.Columns.Add("HORA");

            foreach (var item in coleccion)
            {
                DataRow fila = table.NewRow();
                fila["ID"] = item.Id;
                fila["GESTOR"] = item.Gestor;
                fila["NOMBRE"] = item.Persona;
                fila["ACTIVIDAD"] = item.Actividad;
                fila["RESULTADO"] = item.Resultado;
                fila["FECHA"] = item.Fecha;
                fila["HORA"] = item.Hora;

                table.Rows.Add(fila);
            }


            using var libro = new XLWorkbook();
            table.TableName = "Registros";

            var hoja = libro.Worksheets.Add(table);

            hoja.ColumnsUsed().AdjustToContents();

            using var memoria = new MemoryStream();
            libro.SaveAs(memoria);
            var nombreExcel = "Reporte.xlsx";
            var archivo = File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreExcel);
            return archivo;

        }


        [HttpGet]
        [Route("ExportarConFormato")]
        public async Task<IActionResult> ExportarConFormatoAsync()
        {
            var filtro = String.Empty;
            var coleccion = await _repository.ListGestionInfoAsync();


            using var libro = new XLWorkbook();
            var hoja = libro.Worksheets.Add("Gestiones");
            hoja.Cell("A1").Value = "Cooperativa Unidos por el Futuro";
            hoja.Cell("E1").Value = "Fecha de Emisión";
            hoja.Cell("F1").Value = DateTime.Today.ToLongDateString();
            hoja.Row(1).Height = 20;
            hoja.Row(1).Style.Font.Bold = true;
            hoja.Row(1).Style.Font.FontSize = 16;
            hoja.Row(1).Style.Fill.BackgroundColor = XLColor.AshGrey;

            hoja.Cell("A2").Value = "Reporte de Gestiones a Prospectos a Socios";
            hoja.Row(2).Height = 20;
            hoja.Row(2).Style.Font.Bold = true;
            hoja.Row(2).Style.Font.FontSize = 14;
            hoja.Row(2).Style.Fill.BackgroundColor = XLColor.AshGrey;

            hoja.Cell("A5").Value = "ID";
            hoja.Cell("B5").Value = "NOMBRE";
            hoja.Cell("C5").Value = "ACTIVIDAD";
            hoja.Cell("D5").Value = "RESULTADO";
            hoja.Cell("E5").Value = "FECHA";
            hoja.Cell("F5").Value = "HORA";
            hoja.Cell("G5").Value = "GESTOR";
            hoja.Row(5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            hoja.Row(5).Style.Font.Bold = true;
            hoja.Row(5).Style.Font.FontSize = 12;
            hoja.Row(5).Style.Font.FontColor = XLColor.WhiteSmoke;
            hoja.Row(5).Style.Fill.BackgroundColor = XLColor.Navy;

            var limite = coleccion.Count + 6;
            var contadorItems = 0;
            for (int i = 6; i < limite; i++)
            {
                hoja.Cell(i, 1).Value = coleccion.ElementAt(contadorItems).Id;
                hoja.Cell(i, 2).Value = coleccion.ElementAt(contadorItems).Persona;
                hoja.Cell(i, 3).Value = coleccion.ElementAt(contadorItems).Actividad;
                hoja.Cell(i, 4).Value = coleccion.ElementAt(contadorItems).Resultado;
                hoja.Cell(i, 5).Value = coleccion.ElementAt(contadorItems).Fecha.ToShortDateString();
                hoja.Cell(i, 6).Value = coleccion.ElementAt(contadorItems).Hora.ToShortTimeString();
                hoja.Cell(i, 7).Value = coleccion.ElementAt(contadorItems).Gestor;

                if (i % 2 == 0) hoja.Row(i).Style.Fill.BackgroundColor = XLColor.GoldenYellow;

                contadorItems++;
            }

            hoja.ColumnsUsed().AdjustToContents();

            using var memoria = new MemoryStream();
            libro.SaveAs(memoria);
            var nombreExcel = "ReporteExt.xlsx";
            var archivo = File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreExcel);
            return archivo;

        }
    }
}
