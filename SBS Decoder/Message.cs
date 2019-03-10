using System;

namespace SBS_Decoder
{
    public class Message
    {
        public SBS_Decoder.Type Type { get; set; }
        public string AircraftID { get; set; }
        public string HexIdent { get; set; }
        public string FlightID { get; set; }

        public static Message GetMessage(string stringMessage)
        {
            string[] splitMessage = stringMessage.Split(',');

            Message message = new Message();

            Enum.TryParse<Type>(splitMessage[0], out Type messageType);
            message.Type = messageType;

            message.AircraftID = splitMessage[3];
            message.HexIdent = splitMessage[4];
            message.FlightID = splitMessage[5];

            return message;
        }
    }
}
