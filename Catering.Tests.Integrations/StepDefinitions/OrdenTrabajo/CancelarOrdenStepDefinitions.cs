using System;
using System.Formats.Asn1;
using System.Text;
using Catering.Application.OrdenesTrabajo.CancelarOrden;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using Newtonsoft.Json;
using Reqnroll;

namespace Catering.Tests.Integrations.StepDefinitions.OrdenTrabajo
{
    [Binding]
    public class CancelarOrdenStepDefinitions
    {
        private string _baseAddress = "http://localhost:5142/api/OrdenTrabajo";

        private HttpResponseMessage _response;
        private CrearOrdenCommand _crearOrdenCommand;
        private CancelarOrdenCommand _cancelarOrdenCommand;
        private Guid _idOrdenTrabajo;

        #region Crear Orden Trabajo
        [Given("Datos para una nueva Orden de Trabajo para cancelar")]
        public void GivenDatosParaUnaNuevaOrdenDeTrabajoParaCancelar(DataTable dataTable)
        {
            var idUsuarioCocinero = Guid.Parse(dataTable.Rows[0].Values.ElementAt(1));
            var idReceta = Guid.Parse(dataTable.Rows[1].Values.ElementAt(1));
            var cantidad = int.Parse(dataTable.Rows[2].Values.ElementAt(1));
            List<string> clientesStr = JsonConvert.DeserializeObject<List<string>>(dataTable.Rows[3].Values.ElementAt(1));

            List<Guid> clientes = new List<Guid>();
            foreach (var clienteStr in clientesStr)
            {
                clientes.Add(Guid.Parse(clienteStr));
            }

            _crearOrdenCommand = new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, clientes);
        }

        [When("Crear Orden de Trabajos")]
        public async Task WhenCrearOrdenDeTrabajos()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_crearOrdenCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress, content);
        }

        [Then("Orden de Trabajo creado con exito para cancelar")]
        public async Task ThenOrdenDeTrabajoCreadoConExitoParaCancelar()
        {
            if (!_response.IsSuccessStatusCode)
            {
                Assert.Fail("Error al crear Orden de Trabajo");
            }
            var resultStr = await _response.Content.ReadAsStringAsync();
            var isResultGuid = Guid.TryParse(resultStr.Trim('"'), out _idOrdenTrabajo);

            if (_idOrdenTrabajo == Guid.Empty)
            {
                Assert.Fail("Error al obtener Id de Orden de Trabajo");
            }

            Assert.True(isResultGuid, "El Id creado está correcto");
        }
        #endregion

        #region Cancelar Orden Trabajo
        [Given("Orden de Trabajo creado para cancelar")]
        public void GivenOrdenDeTrabajoCreadoParaCancelar()
        {
            _cancelarOrdenCommand = new CancelarOrdenCommand(_idOrdenTrabajo);
        }

        [When("Cancelar la Orden creada")]
        public async Task WhenCancelarLaOrdenCreada()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_cancelarOrdenCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PutAsync(_baseAddress + "/cancelar-orden", content);
        }

        [Then("Orden cancelada con éxito")]
        public async Task ThenOrdenCanceladaConExito()
        {
            if (!_response.IsSuccessStatusCode)
            {
                Assert.Fail("Error al preparar Cancelar la Orden de Trabajo");
            }
            var resultStr = await _response.Content.ReadAsStringAsync();
            var isResultGuid = Guid.TryParse(resultStr.Trim('"'), out Guid idOrdenTrabajoPreparado);

            if (_idOrdenTrabajo == Guid.Empty)
            {
                Assert.Fail("Error al obtener Id de Orden de Trabajo");
            }
            if (_idOrdenTrabajo != idOrdenTrabajoPreparado)
            {
                Assert.Fail("El ID de la Orden de Trabajo cancelada no es igual a la solicitada");
            }

            Assert.True(isResultGuid, "Cancelada correctamente");
        }
        #endregion
    }
}
