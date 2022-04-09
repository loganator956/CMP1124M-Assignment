using System;
using System.Collections.Generic;

namespace CMP1124M_Assignment
{
    public class MessagePrompt
    {
        public string Message { get; private set; }

        private List<string> _options = new List<string>();

        public MessagePrompt(string message)
        {
            Message = message;
        }

        public void ShowMessage(bool showOptions)
        {
            Console.WriteLine(Message);
            if (showOptions)
            {
                for (int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine($"{i} - {_options[i]}");
                }
            }
        }

        public void AddOption(string option)
        {
            _options.Add(option);
        }

        public int[] ShowPromptMultiSelect()
        {
            ShowMessage(true);
            while (true)
            {
                try
                {
                    string response = Console.ReadLine() ?? "0";
                    List<int> responses = new List<int>();
                    
                    foreach (char c in response)
                    {
                        int cint = 0;
                        if (!int.TryParse(c.ToString(), out cint))
                        {
                            throw new ResponseInputException("Unrecognised character");
                        }
                        if (cint < 0 || cint >= _options.Count)
                        {
                            throw new ResponseInputException("Input doesn't correspond to a proper option");
                        }
                        responses.Add(cint);
                    }
                    return responses.ToArray();
                }
                catch(ResponseInputException except)
                {
                    Console.WriteLine(except);
                }
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
}