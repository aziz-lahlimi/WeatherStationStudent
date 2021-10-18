using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WeatherApp.Models;
using WeatherApp.ViewModels;
using Xunit;

namespace WeatherStationTests
{
    public class WindDataViewModelTests : IDisposable
    {
        // System Under Test
        // Utilisez ce membre dans les tests
        WindDataViewModel _sut = new WindDataViewModel();

        public IEqualityComparer<object> CurrentData { get; private set; }

        /// <summary>
        /// Test la fonctionnalité de conversion de mps vers kph
        /// </summary>
        /// <param name="mps">Mètres par seconde</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T01</remarks>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 18)]
        [InlineData(51, 183.6)]
        [InlineData(-10, -36)]
        [InlineData(65, 234)]
        public void MPStoKPH_AlwaysReturnGoodValue(double mps, double expected)
        {
            // Arrange

            // Act       
            double actual = WindDataViewModel.MPStoKPH(mps);
            // Assert
            Assert.Equal(expected, actual);
            /// TODO : git commit -a -m "T01 MPStoKPH_AlwaysReturnGoodValue : Done"
        }

        /// <summary>
        /// Test la fonctionnalité de conversion de kph à mps
        /// </summary>
        /// <param name="kph">km par heure</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T02</remarks>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 2.78)]
        [InlineData(50, 13.89)]
        [InlineData(100, 27.78)]
        [InlineData(126, 35)]
        [InlineData(200, 55.56)]
        public void KPHtoMPS_AlwaysReturnGoodValue(double kph, double expected)
        {
            // Arrange (_sut déclaré en haut)

            // Act       
            double actual = WindDataViewModel.KPHtoMPS(kph);
            // Assert
            Assert.Equal(expected, actual);
            /// TODO : git commit -a -m "T02 KPHtoMPS_AlwaysReturnGoodValue : Done"
        }

        /// <summary>
        /// Lorsqu'exécuté GetDataCommand devrait lancer une NullException
        /// </summary>
        /// <remarks>T03</remarks>
        [Fact]
        public void GetDataCommand_ExecuteIfNullService_ShouldThrowNullException()
        {
            // Arrange
            WindDataViewModel winDataViewModel = new WindDataViewModel();
            // Act       
            winDataViewModel.SetWindDataService(null);
            // Assert
            Assert.ThrowsAsync<NullReferenceException>(() => winDataViewModel.GetDataCommandFtc());
            /// TODO : git commit -a -m "T03 GetDataCommand_ExecuteIfNullService_ShouldThrowNullException : Done"
        }

        /// <summary>
        /// La méthode CanGetData devrait retourner faux si le service est null
        /// </summary>
        /// <remarks>T04</remarks>
        [Fact]
        public void CanGetData_WhenServiceIsNull_ReturnsFalse()
        {
            // Arrange
            WindDataViewModel winDataViewModel = new WindDataViewModel();
            // Act       
            winDataViewModel.SetWindDataService(null);
            bool actual = winDataViewModel.CanGetData();
            // Assert
            Assert.False(actual);
            /// TODO : git commit -a -m "T04 CanGetData_WhenServiceIsNull_ReturnsFalse : Done"
        }

        /// <summary>
        /// La méthode CanGetData devrait retourner vrai si le service est instancié
        /// </summary>
        /// <remarks>T05</remarks>
        [Fact]
        public void CanGetData_WhenServiceIsSet_ReturnsTrue()
        {
            // Arrange
            WindDataViewModel winDataViewModel = new WindDataViewModel();
            // Act
            winDataViewModel.WindDataService = new OpenWeaherService();
            bool actual = winDataViewModel.CanGetData();
            // Assert
            Assert.True(actual);
            /// TODO : git commit -a -m "T05 CanGetData_WhenServiceIsSet_ReturnsTrue : Done"
        }

        /// <summary>
        /// WindDataService ne devrait plus être null lorsque SetWindDataService reçoit un paramètre
        /// </summary>
        /// <remarks>T06</remarks>
        [Fact]
        public void SetWindDataService_WhenExecuted_WindDataServiceIsNotNull()
        {
            // Arrange
            WindDataViewModel winDataViewModel = new WindDataViewModel();
            // Act       
            winDataViewModel.WindDataService = new OpenWeaherService();
            // Assert
            Assert.NotNull(winDataViewModel.WindDataService);
            /// TODO : git commit -a -m "T06 SetWindDataService_WhenExecuted_WindDataServiceIsNotNull : Done"
        }

        /// <summary>
        /// CurrentData devrait avoir une valeur lorsque GetDataCommand est exécutée
        /// </summary>
        /// <remarks>T07</remarks>
        [Fact]
        public void GetDataCommand_HaveCurrentDataWhenExecuted_ShouldPass()
        {
            //// Arrange
            //var _mock = new Mock<IWindDataService>();
            //_mock.Setup(x => x.GetDataAsync()).ReturnsAsync(new WeatherApp.Models.WindDataModel());
            //_sut = new WindDataViewModel();
            //_sut.SetWindDataService(_mock.Object);
            //// Act       

            //// Assert
            //Assert.NotNull(_sut.CurrentData);
            /// TODO : git commit -a -m "T07 GetDataCommand_HaveCurrentDataWhenExecuted_ShouldPass : Done"
        }

        private Task<WindDataModel> MockData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ne touchez pas à ça, c'est seulement pour respecter les standards
        /// de test qui veulent que la classe de tests implémente IDisposable
        /// Mais ça peut être utilisé, par exemple, si on a une connexion ouverte, il
        /// faut s'assurer qu'elle sera fermée lorsque l'objet sera détruit
        /// </summary>
        public void Dispose()
        {
            // Nothing to here, just for Testing standards
        }
    }
}
