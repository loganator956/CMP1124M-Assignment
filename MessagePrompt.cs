using System;

namespace CMP1124M_Assignment
{
    public class MessagePrompt
    {
        public string Message { get; private set; }
        public MessagePrompt(string message)
        {
            Message = message;
        }

        public void ShowMessage()
        {
            Console.WriteLine(Message);
        }

        public int ShowMessageNumericalResponse(int min, int max)
        {
            Console.WriteLine(Message);
            while (true)
            {
                try
                {
                    int val = _processNumericalResponse();
                    if (val >= min && val <= max)
                    {
                        return val;
                    }
                    else
                    {
                        throw new ResponseInputException($"Input out of expected range ({min}:{max})");
                    }
                }
                catch (ResponseInputException except)
                {
                    Console.WriteLine($"Error parsing input: {except.Message}");
                }
            }
        }

        private int _processNumericalResponse()
        {
            string response = Console.ReadLine() ?? "0";
            int responseCode = 0;
            if (!int.TryParse(response.Trim(), out responseCode))
            {
                throw new ResponseInputException("Could not parse value");
            }
            return responseCode;
        }
    }

    [System.Serializable]
    public class ResponseInputException : System.Exception
    {
        public ResponseInputException() { }
        public ResponseInputException(string message) : base(message) { }
        public ResponseInputException(string message, System.Exception inner) : base(message, inner) { }
        protected ResponseInputException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}