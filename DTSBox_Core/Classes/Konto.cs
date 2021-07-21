namespace DTSBox_Core.Models
{
    public class Konto
    {
        private double _kontoStand;

        public int KontoNummer { get; set; }

        public string Kontoinhaber = "";

        public Konto()
        {
            KontoNummer = 10000;
            _kontoStand = 0;
            Kontoinhaber = "Denis";
        }

        public bool Einzahlen(double value)
        {
            return true;
        }

        public bool Auszahlen(double Value)
        {
            return true;
        }
    }
}
