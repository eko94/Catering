using System;
using Newtonsoft.Json;
using System.Text;
using Reqnroll;
using SpecFlow.Internal.Json;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Application.OrdenesTrabajo.EtiquetarComidas;
using Catering.Application.OrdenesTrabajo.CancelarOrden;

namespace Catering.Tests.Integrations.StepDefinitions.OrdenTrabajo
{
    [Binding]
    public class GenerarOrdenCompletaStepDefinitions
    {
        private string _baseAddress = "http://localhost:5142/api/OrdenTrabajo";

        private HttpResponseMessage _response;
        private CrearOrdenCommand _crearOrdenCommand;
        private PrepararRecetaCommand _prepararRecetaCommand;
        private EmpaquetarComidasCommand _empaquetarComidasCommand;
        private EtiquetarComidasCommand _etiquetarComidasCommand;
        private Guid _idOrdenTrabajo;

        #region Crear Orden Trabajo
        [Given("Datos para una nueva Orden de Trabajo")]
        public void GivenDatosParaUnaNuevaOrdenDeTrabajo(DataTable dataTable)
        {
            var idUsuarioCocinero = Guid.Parse(dataTable.Rows[0].Values.ElementAt(1));
            var idReceta = Guid.Parse(dataTable.Rows[1].Values.ElementAt(1));
            var cantidad = int.Parse(dataTable.Rows[2].Values.ElementAt(1));
            List<string> clientesStr = JsonConvert.DeserializeObject<List<string>>(dataTable.Rows[3].Values.ElementAt(1));

            List<Guid> clientes = new List<Guid>();
            foreach(var clienteStr in clientesStr)
            {
                clientes.Add(Guid.Parse(clienteStr));
            }

            _crearOrdenCommand = new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, clientes);
        }

        [When("Crear Orden de Trabajo")]
        public async Task WhenCrearOrdenDeTrabajo()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_crearOrdenCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress, content);
        }

        [Then("Orden de Trabajo creado con exito")]
        public async Task ThenOrdenDeTrabajoCreatedSuccessfully()
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

        #region Preparar Receta
        [Given("Orden de Trabajo creado")]
        public void GivenOrdenDeTrabajoCreado()
        {
            _prepararRecetaCommand = new PrepararRecetaCommand(_idOrdenTrabajo);
        }

        [When("Preparar la Receta de la Orden")]
        public async Task WhenPrepararLaRecetaDeLaOrden()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_prepararRecetaCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress + "/preparar-receta", content);
        }

        [Then("Receta preparada con éxito")]
        public async Task ThenRecetaPreparadaConExito()
        {
            if (!_response.IsSuccessStatusCode)
            {
                Assert.Fail("Error al preparar Receta de Orden de Trabajo");
            }
            var resultStr = await _response.Content.ReadAsStringAsync();
            var isResultGuid = Guid.TryParse(resultStr.Trim('"'), out Guid idOrdenTrabajoPreparado);

            if(_idOrdenTrabajo == Guid.Empty)
            {
                Assert.Fail("Error al obtener Id de Orden de Trabajo");
            }
            if(_idOrdenTrabajo != idOrdenTrabajoPreparado)
            {
                Assert.Fail("El ID de la Orden de Trabajo preparada no es igual a la solicitada");
            }

            Assert.True(isResultGuid, "Preparado correctamente");
        }
        #endregion

        #region Empaquetar Comidas
        [Given("Orden de Trabajo preparado")]
        public void GivenOrdenDeTrabajoPreparado()
        {
            _empaquetarComidasCommand = new EmpaquetarComidasCommand(_idOrdenTrabajo);
        }

        [When("Empaquetar las Comidas de la Orden")]
        public async Task WhenEmpaquetarLasComidasDeLaOrden()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_empaquetarComidasCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress + "/empaquetar-comidas", content);
        }

        [Then("Comidas empaquetadas con éxito")]
        public async Task ThenComidasEmpaquetadasConExito()
        {
            if (!_response.IsSuccessStatusCode)
            {
                Assert.Fail("Error al empaquetar las comidas de Orden de Trabajo");
            }
            var resultStr = await _response.Content.ReadAsStringAsync();
            var isResultGuid = Guid.TryParse(resultStr.Trim('"'), out Guid idOrdenTrabajoPreparado);

            if (_idOrdenTrabajo == Guid.Empty)
            {
                Assert.Fail("Error al obtener Id de Orden de Trabajo");
            }
            if (_idOrdenTrabajo != idOrdenTrabajoPreparado)
            {
                Assert.Fail("El ID de la Orden de Trabajo empaquetada no es igual a la solicitada");
            }

            Assert.True(isResultGuid, "Empaquetadas correctamente");
        }
        #endregion

        #region Etiquetar Comidas
        [Given("Comidas empaquetadas")]
        public void GivenComidasEmpaquetadas()
        {
            _etiquetarComidasCommand = new EtiquetarComidasCommand(_idOrdenTrabajo);
        }

        [When("Etiquetar las Comidas de la Orden")]
        public async Task WhenEtiquetarLasComidasDeLaOrden()
        {
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(_etiquetarComidasCommand), Encoding.UTF8, "application/json");
            _response = await httpClient.PostAsync(_baseAddress + "/etiquetar-comidas", content);
        }

        [Then("Comidas etiquetadas con éxito")]
        public async Task ThenComidasEtiquetadasConExito()
        {
            if (!_response.IsSuccessStatusCode)
            {
                Assert.Fail("Error al etiquetar las comidas de Orden de Trabajo");
            }
            var resultStr = await _response.Content.ReadAsStringAsync();
            var isResultGuid = Guid.TryParse(resultStr.Trim('"'), out Guid idOrdenTrabajoPreparado);

            if (_idOrdenTrabajo == Guid.Empty)
            {
                Assert.Fail("Error al obtener Id de Orden de Trabajo");
            }
            if (_idOrdenTrabajo != idOrdenTrabajoPreparado)
            {
                Assert.Fail("El ID de la Orden de Trabajo etiquetadas no es igual a la solicitada");
            }

            Assert.True(isResultGuid, "Etiquetadas correctamente");
        }
        #endregion
    }
}
