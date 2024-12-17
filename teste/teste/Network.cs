namespace JeanHenrique
{
    class Network
    {
        private int MaxNumber;
        public Dictionary<int, List<int>> Numbers = [];

        public Network(int maxNumber)
        {
            if (maxNumber <= 0)
                throw new Exception("Número máximo inválido");

            MaxNumber = maxNumber;
        }

        public void Connect(int numberOne, int numberTwo)
        {
            if (numberOne > MaxNumber || numberTwo > MaxNumber)
                throw new Exception("O número informado é maior que o máximo permitido");

            if (numberOne == numberTwo)
                return;

            if (!Numbers.ContainsKey(numberOne))
            {
                Numbers.Add(numberOne, [numberTwo]);
            }
            else
            {
                if (Numbers[numberOne].Contains(numberTwo))
                    return;

                Numbers[numberOne].Add(numberTwo);
            }

            Connect(numberTwo, numberOne);

            foreach (var number in new List<int>(Numbers[numberTwo]))
            {
                Connect(numberOne, number);
            }
        }

        public bool Query(int numberOne, int numberTwo)
        {
            return Numbers.ContainsKey(numberOne) && Numbers[numberOne].Contains(numberTwo);
        }
    }
}