namespace CoreMVC002.Models
{
    public class Record
    {
        public string Guess { get; set; }
        public string Result { get; set; }
        public Record(string guess, string result)
        {
            Guess = guess;
            Result = result;
        }
    }
    public class XAXBEngine
    {

        public string Secret { get; set; }
        public string Guess { get; set; }
        public string Result { get; set; }
        public List<Record> Records { get; set; }

        public XAXBEngine()
        {
            string randomSecret = "1234";

            //
            Secret = randomSecret;
            Guess = null;
            Result = null;
            Records = new List<Record>();
        }

        public XAXBEngine(string secretNumber)
        {
            Secret = secretNumber;
            Guess = null;
            Result = null;
            Records = new List<Record>();
        }
        //
        public int numOfA(string guessNumber)
        {
            // TODO 1
            int countA = 0;

            for (int i=0; i<4; i++)
            {
                //Console.WriteLine($"guessNumber[{i}] = {guessNumber[i]}");
                //Console.WriteLine($"guessNumber[{i}] = {guessNumber[i]}, Secret[{i}] = {Secret[i]}");
                if (guessNumber[i] == Secret[i])
                {
                    
                    countA++;
                }
            }
            return countA;
        }
        //
        public int numOfB(string guessNumber)
        {
            // TODO 2
            int countB = 0;

            for (int i=0; i<4; i++)
            {
                if (Secret.IndexOf(guessNumber[i]) != i && Secret.IndexOf(guessNumber[i]) != -1)
                {
                    //Console.WriteLine($"guessNum[{i}] = {guessNumber[i]} at {Secret.IndexOf(guessNumber[i])}");
                    countB++;
                }
            }
            return countB;
        }
        //
        public bool IsGameOver()
        {
            if (Secret.Equals(Guess))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsGameOver(string guessNumber)
        {
            // TODO 3
            if (Secret.Equals(guessNumber))
                return true;
            else
                return false;
        }

    }

}
