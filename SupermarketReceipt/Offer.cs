namespace SupermarketReceipt
{
    public class Offer
    {
        public Offer(SpecialOfferType offerType, double argument)
        {
            OfferType = offerType;
            Argument = argument;
        }

        public SpecialOfferType OfferType { get; }

        public double Argument { get; }
    }
}