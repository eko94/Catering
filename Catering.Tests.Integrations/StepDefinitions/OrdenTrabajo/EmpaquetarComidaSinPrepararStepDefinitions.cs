using System;
using System.Text;
using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Application.OrdenesTrabajo.CancelarOrden;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Newtonsoft.Json;
using Reqnroll;

namespace Catering.Tests.Integrations.StepDefinitions.OrdenTrabajo
{
    [Binding]
    public class EmpaquetarComidaSinPrepararStepDefinitions
    {
        private string _baseAddress = "http://localhost:5142/api/OrdenTrabajo";

        private HttpResponseMessage _response;
        private CrearOrdenCommand _crearOrdenCommand;
        private EmpaquetarComidasCommand _empaquetarComidasCommand;
        private Guid _idOrdenTrabajo;

        #region Crear Orden Trabajo
        [Given("Datos para una nueva Orden de Trabajo para empaquetar")]
        public void GivenDatosParaUnaNuevaOrdenDeTrabajoParaEmpaquetar(DataTable dataTable)
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

        [When("Crear Orden de Trabajo para empaquetar")]
        public async Task WhenCrearOrdenDeTrabajoParaEmpaquetar()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_crearOrdenCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress, content);
        }

        [Then("Orden de Trabajo creado con exito para empaquetar")]
        public async Task ThenOrdenDeTrabajoCreadoConExitoParaEmpaquetar()
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

        #region Empaquetar Comida
        [Given("Orden de Trabajo creado sin preparado")]
        public void GivenOrdenDeTrabajoCreadoSinPreparado()
        {
            _empaquetarComidasCommand = new EmpaquetarComidasCommand(_idOrdenTrabajo);
        }

        [When("Empaquetar las Comidas de la Orden sin preparar")]
        public async Task WhenEmpaquetarLasComidasDeLaOrdenSinPreparar()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_empaquetarComidasCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress + "/empaquetar-comidas", content);
        }

        [Then("No se puede empaquetar una comidas sin preparar")]
        public async Task ThenNoSePuedeEmpaquetarUnaComidasSinPreparar()
        {
            if (_response.IsSuccessStatusCode)
            {
                Assert.Fail("Error al intentar fallar el empaquetado de las comidas de Orden de Trabajo sin preparar");
            }

            Assert.True(_response.StatusCode == System.Net.HttpStatusCode.InternalServerError,
                "Cancelada correctamente");
        }
        #endregion
    }
}
