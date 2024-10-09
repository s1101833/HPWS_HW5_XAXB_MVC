using System;
namespace CoreMVC002.Models
{
    public class GuessModel
    {

        public string Guess { get; set; }
        public string Result { get; set; }

        public GuessModel(string guess, string result)
        {
            Guess = guess;
            Result = result;
        }
    }

}