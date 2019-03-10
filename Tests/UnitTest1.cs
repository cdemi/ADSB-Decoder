using SBS_Decoder;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]

        public void TestMessageDecode()
        {
            Message message = Message.GetMessage("MSG,5,1,1,4D2150,1,2019/03/10,19:14:03.701,2019/03/10,19:14:03.743,AXY1011 ,2675,,,,,,,0,,0,");


            Assert.Equal(Type.MSG, message.Type);
            Assert.Equal("4D2150", message.HexIdent);
        }
    }
}
