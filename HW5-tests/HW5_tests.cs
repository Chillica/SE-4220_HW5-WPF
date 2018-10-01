using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW5.ViewModel;
using HW5;

namespace HW5_tests
{
    [TestFixture]

    public class HW5_tests
    {

        [Test]
        public void IsCharSelected()
        {
            var character = new Character();
            var vm = new MainViewModel();
            vm.SelectedCharacter = character;
            Assert.IsNotNull(vm.SelectedCharacter);
        }

        [Test]
        public void IsCharListOpen()
        {
            var vm = new MainViewModel();
            vm.IsCharListOpen = true;
            Assert.True(vm.IsCharListOpen);
        }
    }
}