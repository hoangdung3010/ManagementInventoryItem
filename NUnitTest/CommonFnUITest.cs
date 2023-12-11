using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    [TestFixture]
    public class CommonFnUITest
    {
        [TestCase] public void ConvertsMaVachToObject_sMaVachEmpty_ReturnException()
        {
            //Arrange
            string sMaVach = string.Empty;

            //Act

            var ex=Assert.Throws<Exception>(() => FormUI.CommonFnUI.ConvertsMaVachToObject(sMaVach));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Thông tin mã vạch không được trống"));
        }

        [TestCase]
        public void ConvertsMaVachToObject_sMaVachLengthOther16_ReturnException()
        {
            //Arrange
            string sMaVach = "0001000100001216";

            //Act

            var ex = Assert.Throws<Exception>(() => FormUI.CommonFnUI.ConvertsMaVachToObject(sMaVach));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Mã vạch không đúng định dạng 15 số"));
        }

        [TestCase]
        public void ConvertsMaVachToObject_sMaVachLength15_ReturnObjectMaVachValid()
        {
            //Arrange
            string sMaVach = "123456789101123";

            //Act

            var result = FormUI.CommonFnUI.ConvertsMaVachToObject(sMaVach);

            //Assert
            Assert.That(result.sNguon, Is.EqualTo("1"));
            Assert.That(result.sNhaCungCap, Is.EqualTo("2"));
            Assert.That(result.sMaNhomTrangBi, Is.EqualTo("34"));
            Assert.That(result.sMaSanPham, Is.EqualTo("5678"));
            Assert.That(result.sSoSeries, Is.EqualTo("91011"));
            Assert.That(result.sNam, Is.EqualTo("23"));
        }
    }
}
