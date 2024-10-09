namespace CoreMVC002.Models
{
    public class XAXBEngine
    {

        public string Secret { get; set; }
        public string Guess { get; set; }
        public string Result { get; set; }
        public string Records { get; set; }

        public XAXBEngine()
        {
            // TODO 0 - randomly 
            //bool[] numbers = { false, false, false, false, false, false, false, false, false, false };
            //string randomSecret = "";
            //var rand = new Random();

            //int randInt = rand.Next(0, 10);
            //numbers[randInt] = true;
            //randomSecret += randInt.ToString();

            //for (int i = 1; i < 4; i++)
            //{
            //    randInt = rand.Next(0, 10);

            //    while (numbers[randInt])
            //    {
            //        if (++randInt >= 10)
            //        {
            //            randInt = 0;
            //        }
            //    }
            //    numbers[randInt] = true;
            //    randomSecret += randInt.ToString();
            //}

            string randomSecret = "1234";

            //
            Secret = randomSecret;
            Guess = null;
            Result = null;
            Records = "";
        }

        public XAXBEngine(string secretNumber)
        {
            Secret = secretNumber;
            Guess = null;
            Result = null;
            Records = "";
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
