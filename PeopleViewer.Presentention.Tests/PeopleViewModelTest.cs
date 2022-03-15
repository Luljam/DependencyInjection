
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleViewer.Presentation;
using System.Linq;

namespace PeopleViewer.Presentention.Tests
{
    [TestClass]
    public class PeopleViewModelTest
    {
        [TestMethod]
        public void People_OnRefreshPeople_IsPopulated()
        {
            // Arrange
            var reader = new FakeReader();
            var viewModel = new PeopleViewModel(reader);

            // Act
            viewModel.RefreshPeople();

            // Assert
            Assert.IsNotNull(viewModel);
            Assert.Equals(2, viewModel.People.Count());
        }

        [TestMethod]
        public void People_OnClearPeople_IsEmpty()
        {
            // Arrange
            var reader = new FakeReader();
            var viewModel = new PeopleViewModel(reader);

            // Act
            viewModel.ClearPeople();

            // Assert
            Assert.Equals(0, viewModel.People.Count());
        }
    }
}
